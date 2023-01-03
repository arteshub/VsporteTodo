-- =============================================
-- Author:		Шубович Артём
-- Create date:	01.01.2023
-- Description:	Процедура, отсекающая дубликаты в таблицах ( dbo.ClubItems, dbo.PlayerItems, dbo.PlayerClubItems)
-- без использования связи игрок - клуб
-- =============================================
CREATE PROCEDURE dbo.DuplicatesKillerTask1_2
AS
BEGIN
    CREATE TABLE #PlayersDuplicate -- временная таблица для связи игроков и клубов
    (
        PlayerId INT,
        Surname NVARCHAR (50),
        Name NVARCHAR (50),
        Number INT,
        ClubId INT

        PRIMARY KEY (PlayerId, ClubId)
    )

    INSERT INTO #PlayersDuplicate
    SELECT palyers.PlayerId, dbo.NormalizeName(palyers.Surname) AS Surname, dbo.NormalizeName(palyers.Name) AS Name,
           Number, ClubId
        FROM PlayerItems palyers
        INNER JOIN PlayerClubItems clubPlayers ON clubPlayers.PlayerId = palyers.PlayerId

    ;WITH playersFromTheSameClub AS -- удаление игроков, однофамильцев играющих за один и тот же клуб
        (
            SELECT PlayerId, Surname, Name, Number, ClubId,
                ROW_NUMBER() over (PARTITION BY Surname, Name, ClubId ORDER BY PlayerId) AS PlayerGroupNumber
                FROM #PlayersDuplicate
        )
    DELETE FROM dbo.PlayerItems
    WHERE PlayerId IN (SELECT PlayerId FROM playersFromTheSameClub WHERE PlayerGroupNumber <> 1)

    ;WITH resolvePlayersDupplicate AS -- удаление игроков, однофамильцев играющих за разные клубы с одинаковым номером
        (
            SELECT PlayerId, Surname, Name, Number, ClubId,
                ROW_NUMBER() over (PARTITION BY Surname, Name, Number ORDER BY ClubId) AS PlayerGroupNumber
                FROM #PlayersDuplicate
        )

    DELETE FROM dbo.PlayerItems
    WHERE PlayerId IN (SELECT PlayerId FROM resolvePlayersDupplicate WHERE PlayerGroupNumber <> 1)

    ;WITH clubsDuplicateResollve AS -- устранение дублей по Имени клуба и Городу
        (
           SELECT ClubId, dbo.NormalizeName(FullName) AS FullName, dbo.NormalizeName(City) AS City,
                  ROW_NUMBER() over (PARTITION BY FullName ORDER BY City DESC ) ClubInfoNumber
                FROM ClubItems
        )

    DELETE FROM ClubItems
    WHERE ClubId IN (SELECT clubsDuplicateResollve.ClubId FROM clubsDuplicateResollve WHERE ClubInfoNumber <> 1)

    DELETE playerItem FROM PlayerClubItems playerItem --  устранение связей с неактуальными игроками
    LEFT JOIN PlayerItems plIt ON plIt.PlayerId = playerItem.PlayerId
    WHERE plIt.PlayerId IS NULL

    DROP TABLE #PlayersDuplicate
END
go

