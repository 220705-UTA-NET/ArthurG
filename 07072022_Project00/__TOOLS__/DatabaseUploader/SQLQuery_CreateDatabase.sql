CREATE SCHEMA Project00_Wordle;
DROP SCHEMA Project00_Wordle;

CREATE TABLE Project00_Wordle.WordDB_Classic
(
    ID INT PRIMARY KEY IDENTITY,
    Word NVARCHAR(64) NOT NULL
);

DROP TABLE Project00_Wordle.WordDB_Classic;

SELECT *
FROM Project00_Wordle.WordDB_Classic;

DELETE *
FROM Project00_Wordle.WordDB_Classic;