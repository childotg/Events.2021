CREATE FUNCTION [json].[fAsTimespan](@textToClean AS NVARCHAR(MAX))
RETURNS TIME
AS
BEGIN
	RETURN TRY_CAST(TRIM(
		REPLACE(
			REPLACE(
				REPLACE(@textToClean,' ',''),'h',':'),'min',':00')
		)
		AS TIME
	);
END
GO