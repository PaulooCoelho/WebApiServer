CREATE DATABASE QuestionsDB
GO

USE QuestionsDB
GO

CREATE TABLE TQuestions 
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Question NVARCHAR(100) NOT NULL,
	Image_url NVARCHAR(300) NOT NULL,
	Thumb_url NVARCHAR(300) NOT NULL,
	Published_at DATETIME NOT NULL
)

GO

CREATE TABLE TChoices 
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	FK_TQuestion_ID INT NOT NULL,
	Choice NVARCHAR(50) NOT NULL,
	Votes INT NOT NULL
)

GO

ALTER TABLE TChoices  WITH CHECK ADD  CONSTRAINT FK_TChoices_TQuestions FOREIGN KEY(FK_TQuestion_ID)
REFERENCES TQuestions (ID)
GO

ALTER TABLE TChoices CHECK CONSTRAINT FK_TChoices_TQuestions
GO

-- INSERT QUESTIONS
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))
INSERT INTO TQuestions VALUES ('Favourite programming language?', 'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)', 'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)', CONVERT(varchar(50), '2015-08-05T08:40:51.620Z', 127))

-- INSERT QUESTION'S CHOICES
-- ID[1]
INSERT INTO TChoices VALUES (1, 'Swift', 2048)
INSERT INTO TChoices VALUES (1, 'Python', 1024)
INSERT INTO TChoices VALUES (1, 'Objective-C', 512)
INSERT INTO TChoices VALUES (1, 'Ruby', 256)

-- ID[2]
INSERT INTO TChoices VALUES (2, 'Swift', 2048)
INSERT INTO TChoices VALUES (2, 'Python', 1024)
INSERT INTO TChoices VALUES (2, 'Objective-C', 512)
INSERT INTO TChoices VALUES (2, 'Ruby', 256)

-- ID[3]
INSERT INTO TChoices VALUES (3, 'Swift', 2048)
INSERT INTO TChoices VALUES (3, 'Python', 1024)
INSERT INTO TChoices VALUES (3, 'Objective-C', 512)
INSERT INTO TChoices VALUES (3, 'Ruby', 256)

-- ID[4]
INSERT INTO TChoices VALUES (4, 'Swift', 2048)
INSERT INTO TChoices VALUES (4, 'Python', 1024)
INSERT INTO TChoices VALUES (4, 'Objective-C', 512)
INSERT INTO TChoices VALUES (4, 'Ruby', 256)

-- ID[5]
INSERT INTO TChoices VALUES (5, 'Swift', 2048)
INSERT INTO TChoices VALUES (5, 'Python', 1024)
INSERT INTO TChoices VALUES (5, 'Objective-C', 512)
INSERT INTO TChoices VALUES (5, 'Ruby', 256)

-- ID[6]
INSERT INTO TChoices VALUES (6, 'Swift', 2048)
INSERT INTO TChoices VALUES (6, 'Python', 1024)
INSERT INTO TChoices VALUES (6, 'Objective-C', 512)
INSERT INTO TChoices VALUES (6, 'Ruby', 256)

-- ID[7]
INSERT INTO TChoices VALUES (7, 'Swift', 2048)
INSERT INTO TChoices VALUES (7, 'Python', 1024)
INSERT INTO TChoices VALUES (7, 'Objective-C', 512)
INSERT INTO TChoices VALUES (7, 'Ruby', 256)

-- ID[8]
INSERT INTO TChoices VALUES (8, 'Swift', 2048)
INSERT INTO TChoices VALUES (8, 'Python', 1024)
INSERT INTO TChoices VALUES (8, 'Objective-C', 512)
INSERT INTO TChoices VALUES (8, 'Ruby', 256)

-- ID[9]
INSERT INTO TChoices VALUES (9, 'Swift', 2048)
INSERT INTO TChoices VALUES (9, 'Python', 1024)
INSERT INTO TChoices VALUES (9, 'Objective-C', 512)
INSERT INTO TChoices VALUES (9, 'Ruby', 256)

-- ID[10]
INSERT INTO TChoices VALUES (10, 'Swift', 2048)
INSERT INTO TChoices VALUES (10, 'Python', 1024)
INSERT INTO TChoices VALUES (10, 'Objective-C', 512)
INSERT INTO TChoices VALUES (10, 'Ruby', 256)