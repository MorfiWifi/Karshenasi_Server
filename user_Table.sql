CREATE TABLE Users (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Tip INTEGER ,
    LastName nvarchar(255),
    FirstName nvarchar(255),
    pass nvarchar(255),
	pass_hash nvarchar(255),
    Kart_meli nvarchar(255) 
);



DROP TABLE Properties ;

CREATE TABLE Tags (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Tip INTEGER ,
    Matn nvarchar(255) NOT NULL
);

CREATE TABLE Message (
    ID integer PRIMARY KEY IDENTITY NOT NULL,
	Sender INTEGER ,
	Reciver INTEGER ,
	Reciver_Type INTEGER ,
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
	Kart_meli NVARCHAR(255),
	Father_Name NVARCHAR(255),
);

INSERT INTO dbo.Users
        ( Tip ,
          LastName ,
          FirstName ,
          pass ,
          pass_hash ,
          Kart_meli
        )
VALUES  ( NULL , -- Tip - integer
          N'' , -- LastName - nvarchar(255)
          N'' , -- FirstName - nvarchar(255)
          N'' , -- pass - nvarchar(255)
          N'' , -- pass_hash - nvarchar(255)
          N''  -- Kart_meli - nvarchar(255)
        )


INSERT INTO dbo.Tags
        ( Tip, Matn )
VALUES  ( NULL, -- Tip - integer
          N''  -- Matn - nvarchar(255)
          )

INSERT INTO dbo.Message
        ( Sender ,
          Reciver ,
          Reciver_Type ,
          Tags ,
          Matn ,
          Send_Date ,
          Read_Date ,
          Readed
        )
VALUES  ( NULL , -- Sender - integer
          NULL , -- Reciver - integer
          NULL , -- Reciver_Type - integer
          N'' , -- Tags - nvarchar(255)
          N'' , -- Matn - nvarchar(255)
          N'' , -- Send_Date - nvarchar(255)
          N'' , -- Read_Date - nvarchar(255)
          N''  -- Readed - nvarchar(255)
        )

INSERT INTO dbo.Properties
        ( Std_ID ,
          Post_ID ,
          City ,
          Birth_Date ,
          Adress ,
          Roozane_Shabane ,
          Kart_meli ,
          Father_Name
        )
VALUES  ( NULL , -- Std_ID - integer
          N'' , -- Post_ID - nvarchar(255)
          N'' , -- City - nvarchar(255)
          N'' , -- Birth_Date - nvarchar(255)
          N'' , -- Adress - nvarchar(255)
          N'' , -- Roozane_Shabane - nvarchar(255)
          N'' , -- Kart_meli - nvarchar(255)
          N''  -- Father_Name - nvarchar(255)
        )
