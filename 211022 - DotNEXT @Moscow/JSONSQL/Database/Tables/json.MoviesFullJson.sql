CREATE TABLE [json].[MoviesFullJson]
(
	movie_id VARCHAR(20) NOT NULL PRIMARY KEY,
	movie NVARCHAR(MAX) NULL,
	reviews NVARCHAR(MAX) NULL
)
