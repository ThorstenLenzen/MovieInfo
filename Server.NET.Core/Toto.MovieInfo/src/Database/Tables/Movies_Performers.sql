CREATE TABLE [dbo].[Movies_Performers]
(
    [MovieId] UNIQUEIDENTIFIER NOT NULL,
	[PerformerId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Movies_Performers] PRIMARY KEY ([MovieId], [PerformerId]), 
    CONSTRAINT [FK_Movies_Performers_Movies] FOREIGN KEY (MovieId) REFERENCES [Movies]([Id]),
	CONSTRAINT [FK_Movies_Performers_Performers] FOREIGN KEY ([PerformerId]) REFERENCES [Performers]([Id])
)
