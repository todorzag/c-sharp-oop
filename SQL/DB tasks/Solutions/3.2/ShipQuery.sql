USE ships

/*SELECT TOP (1) COUNTRY
FROM CLASSES
ORDER BY NUMGUNS DESC

SELECT DISTINCT CLASS
FROM SHIPS
JOIN OUTCOMES
ON OUTCOMES.SHIP = SHIPS.NAME
WHERE RESULT = 'sunk'

SELECT NAME, SHIPS.CLASS
FROM SHIPS
JOIN CLASSES
ON CLASSES.CLASS = SHIPS.CLASS
WHERE BORE = 16
ORDER BY NAME

SELECT DISTINCT BATTLE
FROM OUTCOMES
JOIN SHIPS
ON OUTCOMES.SHIP = SHIPS.NAME
WHERE CLASS = 'Kongo'

SELECT CLASS, NAME
FROM SHIPS
WHERE CLASS IN (
	SELECT CLASS
	FROM CLASSES CLASS1
	WHERE NUMGUNS >= (
		SELECT MAX(NUMGUNS)
		FROM CLASSES
		WHERE BORE = CLASS1.BORE))
ORDER BY CLASS*/