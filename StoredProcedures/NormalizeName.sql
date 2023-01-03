CREATE FUNCTION NormalizeName(@validizeItem NVARCHAR(MAX))
        -- В названиях могут быть лишние пробелы, табуляции, могу ошибочно проставляться заглавные буквы или пропущена заглавная буква 
        -- в начале имени, все имена собственные могут быть заполнены в кириллице или латинице, в случае кириллицы считать 
        -- одним и тем же буквы (е - ё) и (и - й). Необходимо учитывать эти исключение в поисках дублей.
RETURNS NVARCHAR(MAX)
AS
BEGIN
    SET @validizeItem = LTRIM(RTRIM(@validizeItem))
    SET @validizeItem = LOWER(@validizeItem)
    SET @validizeItem = REPLACE(@validizeItem, N'ё', N'е')
    SET @validizeItem = REPLACE(@validizeItem, N'й', N'и')
    SET @validizeItem = UPPER(SUBSTRING(@validizeItem, 1, 1)) + SUBSTRING(@validizeItem, 2, LEN(@validizeItem))
    RETURN @validizeItem
END
go

