CREATE TABLE [json].[MoviesHybrid]
(
	movie_id VARCHAR(20) NOT NULL PRIMARY KEY,
	plot_summary NVARCHAR(MAX) NULL,
	duration TIME NULL,
	genre NVARCHAR(MAX) NULL,
	rating DECIMAL(3,1) NULL,
	release_date DATE NULL,
	plot_synopsis NVARCHAR(MAX),
	reviews NVARCHAR(MAX) NULL
)
