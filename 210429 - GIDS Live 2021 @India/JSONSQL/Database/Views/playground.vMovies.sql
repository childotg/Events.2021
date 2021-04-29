CREATE VIEW [playground].[vMovies] AS (
SELECT 
	JSON_VALUE(value,'$.movie_id') AS movie_id,
	JSON_VALUE(value,'$.plot_summary') AS plot_summary,
	[json].[fAsTimespan](JSON_VALUE(value,'$.duration')) AS duration,
	JSON_VALUE(value,'$.genre[0]') AS genre,
	CAST(JSON_VALUE(value,'$.rating') AS DECIMAL(3,1)) AS rating,
	TRY_CAST(JSON_VALUE(value,'$.release_date') AS DATE) AS release_date,
	JSON_VALUE(value,'$.plot_synopsis') AS plot_synopsis
  FROM [playground].[KeyValue]
  CROSS APPLY OPENJSON(Doc)
  WHERE Id=3
  )
GO