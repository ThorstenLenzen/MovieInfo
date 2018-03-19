db.movies.insert([
	{ 
		"_id" : "StarWars1977", 
		"Name" : "Star Wars", 
		"Description" : "Luke Skywalker, a young farmer from the desert planet of Tattooine, must save Princess Leia from the evil Darth Vader.",
		"ReleaseDate" : "1977"
	},
	{ 
		"_id" : "Sabrina1995", 
		"Name" : "Sabrina", 
		"Description" : "An ugly duckling having undergone a remarkable change, still harbors feelings for her crush: a carefree playboy, but not before his business-focused brother has something to say about it.",
		"ReleaseDate" : "1995"
	},
	{ 
		"_id" : "PatriotGames1992", 
		"Name" : "Patriot Games", 
		"Description" : "When CIA Analyst Jack Ryan interferes with an IRA assassination, a renegade faction targets him and his family for revenge.",
		"ReleaseDate" : "1992"
	},
	{ 
		"_id" : "BladeRunner1982", 
		"Name" : "Blade Runner", 
		"Description" : "A blade runner must pursue and try to terminate four replicants who stole a ship in space and have returned to Earth to find their creator.",
		"ReleaseDate" : "1982"
	}]
);

var hfDate = new ISODate("1942-07-13T00:00:00Z");
var joDate = new ISODate("1965-01-04T00:00:00Z");
var sbDate = new ISODate("1959-04-17T00:00:00Z");

db.actors.insert([
	{
		"_id": "HarrisonFord1942",
		"FirstName": "Harrison",
		"LastName": "Ford",
		"BirthDate": hfDate,
		"Bio": "Harrison Ford was born on July 13, 1942 in Chicago, Illinois, to Dorothy (Nidelman), a radio actress, and Christopher Ford (born John William Ford), an actor turned advertising executive. His father was of Irish and German ancestry, while his maternal grandparents were Jewish immigrants from Minsk, Belarus. Harrison was a lackluster student at Maine Township High School East in Park Ridge Illinois (no athletic star, never above a C average). After dropping out of Ripon College in Wisconsin, where he did some acting and later summer stock, he signed a Hollywood contract with Columbia and later Universal. His roles in movies and television (Der Chef (1967), Die Leute von der Shiloh Ranch (1962)) remained secondary and, discouraged, he turned to a career in professional carpentry. He came back big four years later, however, as Bob Falfa in American Graffiti (1973). Four years after that, he hit colossal with the role of Han Solo in Krieg der Sterne (1977). Another four years and Ford was Indiana Jones in Jäger des verlorenen Schatzes (1981)."
	},
	{
		"_id": "JuliaOrmond1965",
		"FirstName": "Julia",
		"LastName": "Ormond",
		"BirthDate": joDate,
		"Bio": "The dark and classically beautiful British actress Julia Ormond was born into privileged surroundings as the daughter of a well-to-do laboratory technician. Her parents divorced when she was young; she was the second of five children. She attended Cranleigh, a private school, and showed interest in theatrics way back then. Her grandparents were artists, and she initially intended to be one herself, but after one year of art school, she renewed her dedication to acting and transferred to Webber-Douglas Academy of Dramatic Art, where she graduated in 1988."
	},
	,
	{
		"_id": "SeanBean1959",
		"FirstName": "Sean",
		"LastName": "Bean",
		"BirthDate": sbDate,
		"Bio": "Sean Bean's career since the eighties spans theater, radio, television and movies. Bean was born in Handsworth, Sheffield, West Riding of Yorkshire, to Rita (Tuckwood) and Brian Bean. He worked for his father's welding firm before he decided to become an actor. He attended RADA in London and appeared in a number of West End stage productions including RSC's 'Fair Maid of the West' (Spencer), (1986) and 'Romeo and Juliet' (1987) (Romeo) , as well as 'Deathwatch' (Lederer) (1985) at the Young Vic and 'Killing the Cat' (Danny) (1990) at the Theatre Upstairs."
	}
])