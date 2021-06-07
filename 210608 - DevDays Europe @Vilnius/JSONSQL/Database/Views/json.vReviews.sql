CREATE VIEW [json].[vReviews] AS (
  SELECT 
	movie_id,
	JSON_VALUE(movie,'$.plot_summary') AS plot_summary,
	[json].[fAsTimespan](JSON_VALUE(movie,'$.duration')) AS duration,
	JSON_QUERY(movie,'$.genre') AS genre,
	CAST(JSON_VALUE(movie,'$.rating') AS DECIMAL(3,1)) AS rating,
	TRY_CAST(JSON_VALUE(movie,'$.release_date') AS DATE) AS release_date,
	JSON_VALUE(movie,'$.plot_synopsis') AS plot_synopsis,
	TRY_CAST(JSON_VALUE(value,'$.review_date') AS DATE) AS review_date,
	JSON_VALUE(value,'$.user_id') AS user_id,
	CAST(JSON_VALUE(value,'$.is_spoiler') AS BIT) AS is_spoiler,
	JSON_VALUE(value,'$.review_text') AS review_text,
	CAST(JSON_VALUE(value,'$.rating') AS DECIMAL(3,1)) AS rewview_rating,
	JSON_VALUE(value,'$.review_summary') AS review_summary
	FROM json.MoviesFullJson
	CROSS APPLY OPENJSON(reviews)
	)
GO

