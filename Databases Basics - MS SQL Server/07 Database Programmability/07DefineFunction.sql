CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @isComprised BIT = 1;
	DECLARE @index INT = 1;
	WHILE(@index <= LEN(@word))
	BEGIN
	    DECLARE @currentLetter NVARCHAR = SUBSTRING(@word, @index, 1);
		DECLARE @currentLetterIndex INT = CHARINDEX(@currentLetter, @setOfLetters)
		IF(@currentLetterIndex = 0)
		BEGIN
			SET @isComprised = 0;
		END
		SET @index += 1;
	END
	RETURN @isComprised
END

--Executing

SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS [Result]