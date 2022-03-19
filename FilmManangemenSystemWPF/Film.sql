CREATE SCHEMA [PRAVEEN]

----------------------------------------------------------
--Creation of Table
CREATE TABLE PRAVEEN.Film 
( 
	FilmID INT PRIMARY KEY IDENTITY(1,1), 
	Description VARCHAR(50), 
	Title VARCHAR(30), 
	ReleaseYear DATE, 
	RentalDuration DATE,
	ReplacementCost MONEY, 
	LanguageId INT FOREIGN KEY REFERENCES 	PRAVEEN.Language(LanguageId) , 
	Length NUMERIC(6,2), 
	Rating NUMERIC(2,1), 
	ActorId INT FOREIGN KEY REFERENCES PRAVEEN.Actor(ActorId), 
	CategoryId int foreign key references 	PRAVEEN.Category(CategoryId)
)

INSERT INTO PRAVEEN.Film VALUES 
('Triller Horror movie of Tapsee', 'Game Over', '2018-12-17','2017-12-17',220000.00, 1, 120.00, 3.5, 2, 1)

INSERT INTO PRAVEEN.Film VALUES 
('Remake of DDLJ in Moderm Form', 'Dilwale', '2016-12-27','2017-12-17',220000.02, 1, 120.50, 3.5, 1, 2)


SELECT * FROM PRAVEEN.Film
---------------------------------------------------------------------------------------------------------

Drop table PRAVEEN.Language

CREATE TABLE PRAVEEN.Actor 
(
	ActorId INT PRIMARY KEY IDENTITY(1,1), 
	FirstName VARCHAR(20), 
	LastName VARCHAR(20)
)
INSERT INTO PRAVEEN.Actor VALUES ('ShahRukh', 'Khan')


INSERT INTO PRAVEEN.Actor VALUES ('Tapsee', 'Pannu')

SELECT * FROM PRAVEEN.Actor
-------------------------------------------------------------------------------------------------------------------------
CREATE TABLE PRAVEEN.Category 
(
	CategoryId int primary key identity(1,1), 
	Name varchar(30)
)

INSERT INTO PRAVEEN.Category VALUES ( 'Thriller')

INSERT INTO PRAVEEN.Category VALUES ( 'Romantic')

Delete from PRAVEEN.Actor Where ActorId = 5;

SELECT * FROM PRAVEEN.Category
-------------------------------------------------------------------------------------------------
CREATE TABLE PRAVEEN.Language 
(
	LanguageId int primary key identity(1,1), 
	Name varchar(20)
)

INSERT INTO PRAVEEN.Language Values('Hindi')

SELECT * FROM PRAVEEN.Language
-------------------------------------------------------------------------------------------------------------
Set Identity_insert PRAVEEN.Actor On 
INSERT INTO PRAVEEN.Actor(ActorId,FirstName,LastName) VALUES (3,'ShahRukh', 'Khan')
Set Identity_insert PRAVEEN.Actor Off

--------------------------------------------------------------------------------------------------------------
--creating Insert procedure
--Actor TAble
CREATE PROCEDURE PRAVEEN.usp_ActorAdd
(
@ActorFName Varchar(20),
@ActorLName VARCHAR(20)
)
AS
BEGIN
INSERT INTO PRAVEEN.Actor
(FirstName, LastName)
VALUES
(@ActorFName, @ActorLName)
END
------------------------------------------------------------------------------
EXEC PRAVEEN.usp_ActorAdd 'Alia','Bhatt'

select * from PRAVEEN.Actor

--Insert on CAt table
CREATE PROCEDURE PRAVEEN.usp_CategoryAdd
(
@CategoryName Varchar(30)
)
AS
BEGIN
INSERT INTO PRAVEEN.Category
(Name)
VALUES
(@CategoryName)
END

EXEC PRAVEEN.usp_CategoryAdd 'Horror'

--insert on lang table
CREATE PROCEDURE PRAVEEN.usp_LanguageAdd
(
@LanguageName Varchar(20)
)
AS	
BEGIN
INSERT INTO PRAVEEN.Language
(Name)
VALUES
(@LanguageName)
END

EXEC PRAVEEN.usp_LanguageAdd 'English'

--creting Update procedure actor
CREATE PROCEDURE PRAVEEN.usp_ActorUpdate 
(
@ActorID int,
@ActorFName Varchar(20),
@ActorLName VARCHAR(20)
)
AS
BEGIN
IF(@ActorID IS NULL OR @ActorID < 0)
BEGIN
RAISERROR('Actor ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT ActorId FROM PRAVEEN.Actor WHERE
ActorId = @ActorID)
BEGIN
UPDATE PRAVEEN.Actor
SET FirstName = @ActorFName, LastName = @ActorLName
WHERE ActorId = @ActorID
END
ELSE
BEGIN
RAISERROR('Actor ID not exists', 1, 1)
END
END
END


EXEC PRAVEEN.usp_ActorUpdate 3, 'Salman','Khan'

select * from PRAVEEN.Actor

--update on lang table
CREATE PROCEDURE PRAVEEN.usp_LanguageUpdate 
(
@LanguageID int,
@LanguageName Varchar(20)
)
AS
BEGIN
IF(@LanguageID IS NULL OR @LanguageID < 0)
BEGIN
RAISERROR('Language ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT LanguageId FROM PRAVEEN.Language WHERE
LanguageId = @LanguageID)
BEGIN
UPDATE PRAVEEN.Language
SET Name = @LanguageName
WHERE LanguageId = @LanguageID
END
ELSE
BEGIN
RAISERROR('Language ID not exists', 1, 1)
END
END
END

EXEC PRAVEEN.usp_LanguageUpdate 2, 'Telugu'

select * from PRAVEEN.Language


--update on category table
CREATE PROCEDURE PRAVEEN.usp_CategoryUpdate 
(
@CategoryID int,
@CategoryName Varchar(30)
)
AS
BEGIN
IF(@CategoryID IS NULL OR @CategoryID < 0)
BEGIN
RAISERROR('Category ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT CategoryId FROM PRAVEEN.Category WHERE
CategoryId = @CategoryID)
BEGIN
UPDATE PRAVEEN.Category
SET Name = @CategoryName
WHERE CategoryId = @CategoryID
END
ELSE
BEGIN
RAISERROR('Category ID not exists', 1, 1)
END
END
END


EXEC PRAVEEN.usp_CategoryUpdate 3, 'Mystery'

select * from PRAVEEN.Category

--creating Delete Procedure Actor
CREATE PROCEDURE PRAVEEN.usp_ActorDelete
(
@ActorId int
)
AS
BEGIN
IF(@ActorId IS NULL OR @ActorId < 0)
BEGIN
RAISERROR('Actor ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT ActorId FROM PRAVEEN.Actor WHERE	
ActorId = @ActorId)
BEGIN
DELETE FROM PRAVEEN.Actor WHERE ActorId = @ActorId
END
ELSE
BEGIN
RAISERROR('Actor ID not exists', 1, 1)
END
END
END

EXEC PRAVEEN.usp_ActorDelete 15

drop proc PRAVEEN.usp_ActorDelete;
select * from PRAVEEN.Actor

--Delete in lang table
CREATE PROCEDURE PRAVEEN.usp_LanguageDelete
(
@LanguageId INT
)
AS
BEGIN
IF(@LanguageId IS NULL OR @LanguageId < 0)
BEGIN
RAISERROR('Language ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT LanguageId FROM PRAVEEN.Language WHERE
LanguageId = @LanguageId)
BEGIN
DELETE FROM PRAVEEN.Language WHERE LanguageId = @LanguageId
END
ELSE
BEGIN
RAISERROR('Language ID not exists', 1, 1)
END
END
END

EXEC PRAVEEN.usp_LanguageDelete 2

select * from PRAVEEN.Language

--delete in cat table
CREATE PROCEDURE PRAVEEN.usp_CategoryDelete
(
@CategoryId INT
)
AS
BEGIN
IF(@CategoryId IS NULL OR @CategoryId < 0)
BEGIN
RAISERROR('Category ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT CategoryId FROM PRAVEEN.Category WHERE
CategoryId = @CategoryId)
BEGIN
DELETE FROM PRAVEEN.Category WHERE CategoryId = @CategoryId
END
ELSE
BEGIN
RAISERROR('Category ID not exists', 1, 1)
END
END
END

EXEC PRAVEEN.usp_CategoryDelete 3

select * from PRAVEEN.Category

-- creating search procedure Actor

CREATE PROCEDURE PRAVEEN.usp_ActorSearch
(
@ActorId INT
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Actor WHERE
ActorId = @ActorId)
BEGIN
SELECT *
FROM PRAVEEN.Actor
WHERE ActorId = @ActorId
END
ELSE
BEGIN
RAISERROR('Actor ID does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_ActorSearch 1

--search in lang table
CREATE PROCEDURE PRAVEEN.usp_LanguageSearch
(
@LanguageId INT
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Language WHERE
LanguageId = @LanguageId)
BEGIN
SELECT *
FROM PRAVEEN.Language
WHERE LanguageId = @LanguageId
END
ELSE
BEGIN
RAISERROR('Language ID does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_LanguageSearch 1

--search on cat table
CREATE PROCEDURE PRAVEEN.usp_CategorySearch
(
@CategoryId INT
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Category WHERE
CategoryId = @CategoryId)
BEGIN
SELECT *
FROM PRAVEEN.Category
WHERE CategoryId = @CategoryId
END
ELSE
BEGIN
RAISERROR('Category ID does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_CategorySearch 1

-- creating Display All procedure actor

CREATE PROCEDURE PRAVEEN.usp_ActorDisplayAll
AS
BEGIN
SELECT ActorId, FirstName, LastName
FROM PRAVEEN.Actor
END


EXEC PRAVEEN.usp_ActorDisplayAll;

-- creating Display All procedure language
CREATE PROCEDURE PRAVEEN.usp_LanguageDisplayAll
AS
BEGIN
SELECT LanguageId, Name
FROM PRAVEEN.Language
END

EXEC PRAVEEN.usp_LanguageDisplayAll;

-- creating Display All procedure category

CREATE PROCEDURE PRAVEEN.usp_CategoryDisplayAll
AS
BEGIN
SELECT CategoryId, Name
FROM PRAVEEN.Category
END


EXEC PRAVEEN.usp_CategoryDisplayAll;

--Film table stored Procedure
CREATE PROCEDURE PRAVEEN.usp_FilmAdd
(
@Description Varchar(50),
@Title VARCHAR(30),
@ReleaseYear date,
@RentalDuration date,
@ReplaceCost money,
@LangId int,
@Length numeric(6,2),
@Rating numeric(2,1),
@ActorId int,
@CategoryId int
)
AS
BEGIN
INSERT INTO PRAVEEN.Film
(Description, Title, ReleaseYear, RentalDuration, ReplacementCost, LanguageId, Length, Rating, ActorId, CategoryId)
VALUES
(@Description, @Title,@ReleaseYear,@RentalDuration,@ReplaceCost,@LangId, @Length, @Rating,@ActorId,@CategoryId)
END

EXEC PRAVEEN.usp_FilmAdd 'Based on Chetan Bhagat Novel','2 States', '2017-02-07', '2017-01-09', 210000, 1, 120.78, 4.0, 3, 2;

select * from PRAVEEN.Film


CREATE PROCEDURE PRAVEEN.usp_FilmDisplayAll
AS
BEGIN
SELECT FilmID, Description, Title, ReleaseYear, RentalDuration, ReplacementCost, LanguageId, Length, Rating, ActorId, CategoryId
FROM PRAVEEN.Film
END


EXEC PRAVEEN.usp_FilmDisplayAll;

CREATE PROCEDURE PRAVEEN.usp_FilmUpdate 
(
@FilmID int,
@Description Varchar(50),
@Title VARCHAR(30),
@ReleaseYear date,
@RentalDuration date,
@ReplaceCost money,
@LangId int,
@Length numeric(6,2),
@Rating numeric(2,1),
@ActorId int,
@CategoryId int
)
AS
BEGIN
IF(@FilmID IS NULL OR @FilmID < 0)
BEGIN
RAISERROR('Film ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT FilmID FROM PRAVEEN.Film WHERE
FilmID = @FilmID)
BEGIN
UPDATE PRAVEEN.Film
SET Description = @Description, Title=@Title, ReleaseYear=@ReleaseYear, RentalDuration=@RentalDuration, ReplacementCost=@ReplaceCost, LanguageId=@LangId, Length=@Length, Rating=@Rating, ActorId=@ActorId, CategoryId=@CategoryId
WHERE FilmID = @FilmID
END
ELSE
BEGIN
RAISERROR('Film ID not exists', 1, 1)
END
END
END



EXEC PRAVEEN.usp_FilmUpdate 3,'Based on Chetan Bhagat Novel','Two States', '2017-02-07', '2016-11-09', 210000, 1, 120.78, 4.0, 3, 2;

select * from PRAVEEN.Film

CREATE PROCEDURE PRAVEEN.usp_FilmDelete
(
@FilmId INT
)
AS
BEGIN
IF(@FilmId IS NULL OR @FilmId < 0)
BEGIN
RAISERROR('Film ID cannot be null or negative', 1, 1)
END
ELSE
BEGIN
IF EXISTS (SELECT FilmID FROM PRAVEEN.Film WHERE
FilmID = @FilmId)
BEGIN
DELETE FROM PRAVEEN.Film WHERE FilmID = @FilmId
END
ELSE
BEGIN
RAISERROR('Film ID not exists', 1, 1)
END
END
END

EXEC PRAVEEN.usp_FilmDelete 5

select * from PRAVEEN.Film

CREATE PROCEDURE PRAVEEN.usp_FilmIdSearch
(
@FilmId INT
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Film WHERE
FilmID = @FilmId)
BEGIN
SELECT *
FROM PRAVEEN.Film
WHERE FilmID = @FilmId
END
ELSE
BEGIN
RAISERROR('Film ID does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmIdSearch 3


CREATE PROCEDURE PRAVEEN.usp_FilmRatingSearch
(
@Rating numeric(2,1)
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Film WHERE
Rating = @Rating)
BEGIN
SELECT *
FROM PRAVEEN.Film
WHERE Rating = @Rating
END
ELSE
BEGIN
RAISERROR('Film with this rating does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmRatingSearch 4

CREATE PROCEDURE PRAVEEN.usp_FilmNameSearch
(
@FilmName varchar(30)
)
AS
BEGIN
IF EXISTS (SELECT * FROM PRAVEEN.Film WHERE
Title = @FilmName)
BEGIN
SELECT *
FROM PRAVEEN.Film
WHERE Title = @FilmName
END
ELSE
BEGIN
RAISERROR('Film ITitle does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmNameSearch 'Two States'

select * from PRAVEEN.Film where ActorId =(select ActorId from PRAVEEN.Actor where FirstName='Alia')

drop proc PRAVEEN.usp_FilmActorName

CREATE PROCEDURE PRAVEEN.usp_FilmActorName
(
@ActorName varchar(30)
)
AS
BEGIN
IF EXISTS (select * from PRAVEEN.Film where ActorId =(select ActorId from PRAVEEN.Actor where FirstName=@ActorName))
BEGIN
select * from PRAVEEN.Film where ActorId = (select ActorId from PRAVEEN.Actor where FirstName=@ActorName)
END
ELSE
BEGIN
RAISERROR('Film with this Actor Name does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmActorName 'Alia'

CREATE PROCEDURE PRAVEEN.usp_FilmLanguageName
(
@LanguageName varchar(20)
)
AS
BEGIN
IF EXISTS (select * from PRAVEEN.Film where LanguageId =(select LanguageId from PRAVEEN.Language where Name=@LanguageName))
BEGIN
select * from PRAVEEN.Film where LanguageId =(select LanguageId from PRAVEEN.Language where Name=@LanguageName)
END
ELSE
BEGIN
RAISERROR('Film with this Language Name does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmLanguageName 'Hindi'

CREATE PROCEDURE PRAVEEN.usp_FilmCategoryName
(
@CategoryName varchar(20)
)
AS
BEGIN
IF EXISTS (select * from PRAVEEN.Film where CategoryId =(select CategoryId from PRAVEEN.Category where Name=@CategoryName))
BEGIN
select * from PRAVEEN.Film where CategoryId =(select CategoryId from PRAVEEN.Category where Name=@CategoryName)
END
ELSE
BEGIN
RAISERROR('Film with this category Name does not exists', 1, 1)
END
END

EXEC PRAVEEN.usp_FilmCategoryName 'Romantic'

-----------------------------------------------------------
DROP TABLE [PRAVEEN].Registration_494
--CREATE TABLE [PRAVEEN].Registration_494
--(
--	ID int primary key identity(1,1),
--	Name varchar(30),
--	Email varchar(30),
--	PhoneNo varchar(10),
--	UserPassword varchar(30)
--)

CREATE TABLE [PRAVEEN].Registration_494
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30),
	LastName VARCHAR(30),
	Email VARCHAR(30),
	Password VARCHAR(30),
	ConfirmPassword VARCHAR(30)
)

DROP PROC [PRAVEEN].USP_Registration
--CREATE PROC [PRAVEEN].USP_Registration
--(
--	@Name varchar(30),
--	@Email varchar(30),
--	@PhoneNo varchar(10),
--	@Password varchar(30)
--)
--AS
--BEGIN
--INSERT INTO [PRAVEEN].Registration_494(Name,Email,PhoneNo,UserPassword) values (@Name,@Email,@PhoneNo,@Password) 
--END

CREATE PROC [PRAVEEN].USP_Registration
(
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@Email VARCHAR(30),
	@Password VARCHAR(30),
	@ConfirmPassword VARCHAR(30)
)
AS
BEGIN
	INSERT INTO [PRAVEEN].Registration_494(FirstName,LastName,Email,Password,ConfirmPassword) values (@FirstName,@LastName,@Email,@Password,@ConfirmPassword)
END

DELETE FROM [PRAVEEN].Registration_494 WHERE ID=1
------------------------------------------------------------------------------------------------------
DROP PROC [PRAVEEN].USP_CheckLogin
--CREATE PROC [PRAVEEN].USP_CheckLogin
--(
--	@Email varchar(30),
--	@Password varchar(30)
--)
--AS
--BEGIN
--	SELECT * FROM [PRAVEEN].Registration_494 WHERE Email=@Email and UserPassword=@Password
--END

CREATE PROC [PRAVEEN].USP_CheckLogin
(
	@Email varchar(30),
	@Password varchar(30)
)
AS
BEGIN
	SELECT * FROM [PRAVEEN].Registration_494 WHERE Email=@Email and Password=@Password
END

