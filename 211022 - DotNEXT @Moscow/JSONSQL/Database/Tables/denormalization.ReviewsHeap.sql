CREATE TABLE [denormalization].[ReviewsHeap] (
    [movie_id]       VARCHAR (20)    NOT NULL,
    [plot_summary]   NVARCHAR (4000) NULL,
    [duration]       TIME (7)        NULL,
    [genre]          NVARCHAR (MAX)  NULL,
    [rating]         DECIMAL (3, 1)  NULL,
    [release_date]   DATE            NULL,
    [plot_synopsis]  NVARCHAR (4000) NULL,
    [review_date]    DATE            NULL,
    [user_id]        NVARCHAR (4000) NULL,
    [is_spoiler]     BIT             NULL,
    [review_text]    NVARCHAR (4000) NULL,
    [rewview_rating] DECIMAL (3, 1)  NULL,
    [review_summary] NVARCHAR (4000) NULL
);
GO

