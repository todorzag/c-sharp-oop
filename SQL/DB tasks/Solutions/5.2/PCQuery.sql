USE pc;

/*SELECT AVG(speed) AS 'Average speed'
FROM pc

SELECT maker, AVG(screen) AS 'Average screen size'
FROM product
JOIN laptop
ON product.model = laptop.model
GROUP BY maker

SELECT AVG(speed) AS 'Average speed'
FROM laptop
WHERE price > 1000

SELECT AVG(price) AS 'Average price for A maker'
FROM pc
JOIN product
on pc.model = product.model
WHERE maker = 'A'

WITH cte_prices as (
SELECT 
	AVG(laptop.price) AS 'Average price'
FROM product
LEFT JOIN laptop ON laptop.model = product.model
WHERE maker = 'B'
UNION
SELECT 
	AVG(pc.price) AS 'Average price'
FROM product
LEFT JOIN pc on pc.model = product.model
WHERE maker = 'B'
) SELECT 
	AVG(cte_prices.[Average price]) AS 'Average price of pc and laptop'
FROM cte_prices

SELECT AVG(price) AS 'Average price'
FROM pc
GROUP BY speed

SELECT maker
FROM product
JOIN pc
ON pc.model = product.model
GROUP BY maker
HAVING COUNT(pc.code) >= 3

SELECT maker
FROM product
JOIN pc
ON pc.model = product.model
WHERE price = (
	SELECT MAX(price)
	FROM pc
)

SELECT AVG(price) AS 'Average price'
FROM pc
WHERE speed > 800*/
