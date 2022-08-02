CREATE SCHEMA Project01_Snake;
-- DROP SCHEMA Project01_Snake;

CREATE TABLE Project01_Snake.UserData
(
    DB_ID INT PRIMARY KEY IDENTITY,
    DB_Username NVARCHAR(32) NOT NULL UNIQUE,
    DB_Password NVARCHAR(32) NOT NULL,
    DB_Tokens INT,
    DB_ProAccount BIT
);
--DROP TABLE Project01_Snake.UserData

SELECT *
FROM Project01_Snake.UserData

--DELETE FROM Project01_Snake.UserData;

UPDATE Project01_Snake.UserData
SET DB_ProAccount = 'true'
WHERE DB_ID = 1


