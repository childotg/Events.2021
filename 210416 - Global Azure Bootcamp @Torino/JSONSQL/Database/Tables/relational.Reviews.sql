CREATE TABLE [relational].[Reviews]
(
	review_id INT NOT NULL PRIMARY KEY IDENTITY,
	review_date DATE NULL,
	movie_id VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES [relational].[Movies](movie_id),
	[user_id] VARCHAR(20) NULL,
	is_spoiler BIT NULL,
	review_text NVARCHAR(MAX) NULL,
	rating DECIMAL(3,1) NULL,
	review_summary NVARCHAR(MAX) NULL
)
