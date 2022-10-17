USE pc

/*SELECT maker, model, type
FROM product
WHERE model NOT IN (
	SELECT model
	FROM pc
	UNION
	SELECT model
	FROM laptop
	UNION
	SELECT model
	FROM printer
)

SELECT P1.maker
FROM product P1
JOIN product P2
ON P1.maker = P2.maker
WHERE P1.type = 'Laptop'
AND P2.type = 'Printer'
GROUP BY P1.maker

SELECT hd
FROM laptop
HAVING COUNT(hd) >= 2
GROUP*/
