USE pc

/*SELECT model, code, screen
FROM laptop
WHERE model IN (
	SELECT model
	FROM laptop
	WHERE screen = 11
)
AND model IN (
	SELECT model
	FROM laptop
	WHERE screen = 15
)
AND (screen = 11 OR screen = 15)

SELECT DISTINCT pc.model
FROM pc 
JOIN product PCM
ON pc.model = PCM.model
WHERE price < (
	SELECT MIN(price)
	FROM laptop
	JOIN product LAP
	ON laptop.model = LAP.model
	WHERE PCM.maker = LAP.maker
)

SELECT DISTINCT pc.model, AVG(price)
FROM pc 
JOIN product PCM
ON pc.model = PCM.model
GROUP BY pc.model, PCM.maker
HAVING AVG(price) < (
	SELECT MIN(price)
	FROM laptop
	JOIN product 
	ON laptop.model = product.model
	WHERE PCM.maker = product.maker
	GROUP BY product.maker
)*/

