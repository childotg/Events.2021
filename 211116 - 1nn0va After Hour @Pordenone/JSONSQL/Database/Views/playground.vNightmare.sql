CREATE VIEW [playground].[vNightmare] AS (
SELECT * FROM 
(SELECT 
	JSON_VALUE(value,'$.movie_id') AS movie_id,
	TRY_CAST(JSON_VALUE(value,'$.review_date') AS DATE) AS review_date,
	JSON_VALUE(value,'$.user_id') AS user_id,
	CAST(JSON_VALUE(value,'$.is_spoiler') AS BIT) AS is_spoiler,
	JSON_VALUE(value,'$.review_text') AS review_text,
	CAST(JSON_VALUE(value,'$.rating') AS DECIMAL(3,1)) AS review_rating,
	JSON_VALUE(value,'$.review_summary') AS review_summary
  FROM [playground].[KeyValue]
  CROSS APPLY OPENJSON(Doc) 
  WHERE Id=4) AS A,
  (SELECT 
	JSON_VALUE(value,'$.movie_id') AS movie_id_b,
	JSON_VALUE(value,'$.plot_summary') AS plot_summary,
	[json].[fAsTimespan](JSON_VALUE(value,'$.duration')) AS durationw,
	JSON_VALUE(value,'$.genre[0]') AS genre,
	CAST(JSON_VALUE(value,'$.rating') AS DECIMAL(3,1)) AS movie_rating,
	TRY_CAST(JSON_VALUE(value,'$.release_date') AS DATE) AS release_date,
	JSON_VALUE(value,'$.plot_synopsis') AS plot_synopsis
  FROM [playground].[KeyValue]
  CROSS APPLY OPENJSON(Doc)
  WHERE Id=3) AS B
  WHERE A.movie_id=B.movie_id_b
 )
GO

