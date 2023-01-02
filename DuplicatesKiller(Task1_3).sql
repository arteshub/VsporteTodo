CREATE PROCEDURE dbo.DuplicatesKillerTask1_3
AS
BEGIN
    -- для начала вычищаем дубли игроков в рамках одного клуба (имя, фамилия)
    CREATE TABLE #PlayersDuplicate -- временная табличка для связи игроков и клубов
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

    ;WITH playersFromTheSameClub AS -- сначала вычищаем игроков, однофамильцев играющих за один и тот же клуб
        (
            SELECT PlayerId, Surname, Name, Number, ClubId,
                ROW_NUMBER() over (PARTITION BY Surname, Name, ClubId ORDER BY PlayerId) AS PlayerGroupNumber
                FROM #PlayersDuplicate
        )
    DELETE FROM PlayerItems
    WHERE PlayerId IN (SELECT PlayerId FROM playersFromTheSameClub WHERE PlayerGroupNumber <> 1)

     CREATE TABLE #ResolvePlayersDupplicate
     (
         PlayerId INT,
         Surname NVARCHAR (50),
         Name NVARCHAR (50),
         Number NVARCHAR (100),
         ClubId INT,
         PlayerGroupNumber INT

        PRIMARY KEY (PlayerId, ClubId, Number)
     )
     INSERT INTO #ResolvePlayersDupplicate -- потом вычищаем игроков, однофамильцев играющих за разные клубы с одинаковым номером
                                           -- оставляем только одну сущность и переносим ее в клуб вместо сущности дубликата
     SELECT PlayerId, Surname, Name, Number, ClubId,
                ROW_NUMBER() over (PARTITION BY Surname, Name, Number ORDER BY ClubId) AS PlayerGroupNumber
                FROM #PlayersDuplicate

    -- перед удалением дубликатов необходимо добавить связь по настоящему игроку в тот клуб из которого мы удалим его дубликат
    ;WITH preparationToPlayersUpdate AS
        (
            SELECT items.PlayerId, items.ClubId, duplicate.Surname, duplicate.Name, duplicate.Number
                FROM #ResolvePlayersDupplicate duplicate
                    INNER JOIN PlayerClubItems items ON items.ClubId = duplicate.ClubId AND items.PlayerId = duplicate.PlayerId
                WHERE PlayerGroupNumber <> 1
        )
    INSERT INTO dbo.PlayerClubItems (PlayerId, ClubId)
    SELECT item.PlayerId,upd.ClubId
        FROM preparationToPlayersUpdate upd
            INNER JOIN dbo.PlayerItems item ON item.Number = upd.Number AND item.Name = upd.Name
                AND dbo.NormalizeName(item.Surname) = dbo.NormalizeName(upd.Surname)
                AND item.PlayerId <> upd.PlayerId
        ORDER BY PlayerId

    DELETE FROM PlayerItems -- вычищаем игроков, однофамильцев играющих за разные клубы с одинаковым номером
    WHERE PlayerId IN (SELECT PlayerId FROM #ResolvePlayersDupplicate WHERE PlayerGroupNumber <> 1)

    -- перед удалением дубликата клуба необходимо перетащить игрока в тот клуб, который останется по факту
    -- в нашем случае Двинятин переезжает в клуб Родина (Москва) ClubId = 1
    ;WITH corrClubs AS -- выбираем клубы, которые не попадут под удаление для переноса в них игроков
    (
        SELECT itemsCorr.ClubId, dbo.NormalizeName(itemsCorr.FullName) FullName, 
               dbo.NormalizeName(itemsCorr.City) City,
           ROW_NUMBER() over (PARTITION BY itemsInCorr.FullName ORDER BY itemsInCorr.City DESC ) CorrClubNumber
        FROM ClubItems itemsInCorr
            INNER JOIN ClubItems itemsCorr ON itemsCorr.ClubId = itemsInCorr.ClubId
        WHERE itemsCorr.FullName IS NOT NULL AND itemsCorr.City IS NOT NULL
    ), itemsToUpdate AS
    (
        SELECT PCI.PlayerId, clIt.ClubId AS OldClubId, corrClubs.ClubId AS CorrClubId, dbo.NormalizeName(clIt.FullName) FullName
            FROM corrClubs
                INNER JOIN ClubItems clIt ON clIt.FullName = corrClubs.FullName
                INNER JOIN PlayerClubItems PCI on clIt.ClubId = PCI.ClubId
            WHERE clIt.City IS NULL
    )

    UPDATE plClIT SET plClIT.ClubId = itemsToUpdate.CorrClubId -- апдейтим актуальный клуб
        FROM PlayerClubItems plClIT
        INNER JOIN itemsToUpdate ON itemsToUpdate.OldClubId = plClIT.ClubId AND itemsToUpdate.PlayerId = plClIT.PlayerId

     ;WITH clubsDuplicateResollve AS -- вычищаю дубли по Имени клуба и Городу
        (
           SELECT ClubId, dbo.NormalizeName(FullName) AS FullName, dbo.NormalizeName(City) AS City,
                  ROW_NUMBER() over (PARTITION BY FullName ORDER BY City DESC ) ClubInfoNumber
                FROM ClubItems
        )

    DELETE FROM ClubItems
    WHERE ClubId IN (SELECT clubsDuplicateResollve.ClubId FROM clubsDuplicateResollve WHERE ClubInfoNumber <> 1)

    -- удаляю связи с неактуальными игроками
     DELETE plClIt
        FROM PlayerClubItems plClIt
            LEFT JOIN PlayerItems plIt ON plIt.PlayerId = plClIt.PlayerId
        WHERE plIt.PlayerId IS NULL;

     DELETE FROM PlayerClubItems -- если остались дубликаты - подчищаем
     WHERE SystemID NOT IN
          (SELECT MIN(SystemID) FROM PlayerClubItems GROUP BY PlayerId, ClubId);

     DROP TABLE #PlayersDuplicate
     DROP TABLE #ResolvePlayersDupplicate
END
go

