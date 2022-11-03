USE pc

/*
SELECT DISTINCT maker
FROM product
WHERE maker IN (
	SELECT maker
	FROM product
	WHERE type = 'laptop'
)
AND type = 'printer'

WITH CTE_AVG AS (
	SELECT maker, AVG(price) AS AVG_PRICE
	FROM product
	JOIN printer ON printer.model = product.model
	GROUP BY maker
), CTE_MODELS AS (
	SELECT model
	FROM product
	WHERE type = 'PC'
	AND maker IN (
		SELECT maker 
		FROM CTE_AVG
		WHERE AVG_PRICE > 800
	)
)

UPDATE pc
SET price -= (price * 0.05)
FROM pc
WHERE model IN (
	SELECT model
	FROM CTE_MODELS
)

SELECT HD, MIN(PRICE)
FROM PC
WHERE HD<30 AND HD>10
GROUP BY HD
*/