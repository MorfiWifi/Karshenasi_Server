CREATE TABLE Users (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Tip INTEGER ,
    LastName nvarchar(255),
    FirstName nvarchar(255),
    pass nvarchar(255),
	pass_hash nvarchar(255),
    Kart_meli nvarchar(255) 
);

INSERT INTO dbo.Users
        ( LastName ,
          FirstName ,
          pass ,
          pass_hash ,
          City
        )
VALUES  ( N'Ad' , -- LastName - nvarchar(255)
          N'Morteza' , -- FirstName - nvarchar(255)
          N'123456' , -- pass - nvarchar(255)
          N'notYet' , -- pass_hash - nvarchar(255)
          N'Ahwaz'  -- City - nvarchar(255)
        )


DROP TABLE Users ;

CREATE TABLE Tags (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Tip INTEGER ,
    Matn nvarchar(255) NOT NULL
);

CREATE TABLE Message (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Sender INTEGER ,
	Reciver INTEGER ,
    Tags nvarchar(255),
	Matn NVARCHAR(255),
	Send_Date NVARCHAR(255),
	Read_Date NVARCHAR(255),
	Readed NVARCHAR(255) --As Boolean Thinking!
);

CREATE TABLE Properties (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Std_ID INTEGER ,
    Post_ID nvarchar(255),
	City NVARCHAR(255),
	Birth_Date NVARCHAR(255),
	Adress NVARCHAR(255),
	Roozane_Shabane NVARCHAR(255), -- as Swich
	KartMeli NVARCHAR(255),
	Father_Name NVARCHAR(255),
);
