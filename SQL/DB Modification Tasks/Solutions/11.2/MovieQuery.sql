USE movies
GO

/*
CREATE VIEW vw_RichExec AS
SELECT NAME, ADDRESS, CERT#, NETWORTH
FROM MOVIEEXEC
WHERE NETWORTH >= 10000000

CREATE VIEW vw_ExecutiveStar AS
SELECT
MOVIESTAR.NAME,
MOVIEEXEC.ADDRESS,
GENDER,
BIRTHDATE,
CERT#,
NETWORTH
FROM MOVIESTAR
JOIN MOVIEEXEC
ON MOVIESTAR.NAME = MOVIEEXEC.NAME

SELECT * 
FROM vw_ExecutiveStar
WHERE GENDER = 'F'

SELECT * 
FROM vw_ExecutiveStar
WHERE NETWORTH >= 50000000

DROP VIEW vw_ExecutiveStar
DROP VIEW vw_RichExec
*/