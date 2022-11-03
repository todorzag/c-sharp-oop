USE pc

/*SELECT DISTINCT maker
FROM product
JOIN pc
ON product.model = pc.model
WHERE type = 'PC'
AND pc.speed > 500

SELECT 
code,
model,
price
FROM printer
WHERE price = (
	SELECT MAX(price)
	FROM printer)

SELECT *
FROM laptop
WHERE speed < (
	SELECT MIN(speed)
	FROM pc)

SELECT TOP (1) *
FROM (
	SELECT TOP (1) product.model, price
	FROM product
	JOIN pc
	ON product.model = pc.model
	ORDER BY price DESC
	UNION
	SELECT TOP (1) product.model, price
	FROM product
	JOIN laptop
	ON product.model = laptop.model
	ORDER BY price DESC
	UNION
	SELECT TOP (1) product.model, price
	FROM product
	JOIN printer
	ON product.model = printer.model
	ORDER BY price DESC
	) result
ORDER BY price DESC

SELECT TOP (1) maker
FROM product
JOIN printer
ON product.model = printer.model
WHERE product.type = 'Printer'
AND color = 'y'
ORDER BY price 

SELECT maker
FROM product
WHERE model IN (
	SELECT model
	FROM pc
	WHERE ram = (
		SELECT MIN(ram)
		FROM pc
		)
	AND speed = (
		SELECT MAX(speed)
		FROM pc
		WHERE ram = (
			SELECT MIN(ram)
			FROM pc
			)
		)
	)*/