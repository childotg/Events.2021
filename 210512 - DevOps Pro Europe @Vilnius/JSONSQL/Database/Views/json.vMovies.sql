CREATE VIEW [json].[vMovies] AS (
  SELECT 
	movie_id,
	JSON_VALUE(movie,'$.plot_summary') AS plot_summary,
	[json].[fAsTimespan](JSON_VALUE(movie,'$.duration')) AS duration,
	JSON_QUERY(movie,'$.genre') AS genre,
	CAST(JSON_VALUE(movie,'$.rating') AS DECIMAL(3,1)) AS rating,	
	TRY_CAST(JSON_VALUE(movie,'$.release_date') AS DATE) AS release_date,
	JSON_VALUE(movie,'$.plot_synopsis') AS plot_synopsis
	FROM json.MoviesFullJson
	)
GO

