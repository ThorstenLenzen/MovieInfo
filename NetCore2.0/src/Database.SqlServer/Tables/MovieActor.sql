CREATE TABLE [dbo].[MovieActor]
(
    [MovieId] UNIQUEIDENTIFIER NOT NULL,
	[ActorId] UNIQUEIDENTIFIER NOT NULL, 
    [IsMainCast] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_MovieActor] PRIMARY KEY ([MovieId], [ActorId]), 
    CONSTRAINT [FK_MovieActor_Movie] FOREIGN KEY (MovieId) REFERENCES [Movie]([Id]),
	CONSTRAINT [FK_MovieActor_Actor] FOREIGN KEY ([ActorId]) REFERENCES [Actor]([Id])
)
