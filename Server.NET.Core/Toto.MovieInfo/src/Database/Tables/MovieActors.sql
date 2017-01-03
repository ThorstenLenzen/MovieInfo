CREATE TABLE [dbo].[MovieActors]
(
    [MovieId] UNIQUEIDENTIFIER NOT NULL,
	[ActorId] UNIQUEIDENTIFIER NOT NULL, 
    [IsMainCast] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_MovieActors] PRIMARY KEY ([MovieId], [ActorId]), 
    CONSTRAINT [FK_MovieActors_Movies] FOREIGN KEY (MovieId) REFERENCES [Movies]([Id]),
	CONSTRAINT [FK_MovieActors_Actors] FOREIGN KEY ([ActorId]) REFERENCES [Actors]([Id])
)
