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

SELECT HD, MIN(PRICE)
FROM PC
WHERE HD<30 AND HD>10
GROUP BY HD
*/