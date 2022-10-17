use pc

/*SELECT maker, speed
FROM laptop
	JOIN product
	ON laptop.model = product.model
	WHERE hd >= 9;

SELECT product.model, price
FROM product
	JOIN laptop
	ON product.model = laptop.model
	WHERE maker = 'B'
UNION
SELECT product.model, price
FROM product
	JOIN pc
	ON product.model = pc.model
	WHERE maker = 'B'
UNION
SELECT product.model, price
FROM product
	JOIN printer
	ON product.model = printer.model
	WHERE maker = 'B';

SELECT maker
FROM product
	JOIN laptop
	ON product.model = laptop.model
	AND maker NOT IN 
		(SELECT maker
		FROM product, pc
		WHERE product.model = pc.model);

SELECT hd
FROM pc
GROUP BY hd
HAVING COUNT(hd) >= 2

SELECT DISTINCT PC1.model, PC2.model
FROM pc PC1, pc PC2
WHERE PC1.model < PC2.model
AND PC1.speed = PC2.speed
AND PC1.ram = PC2.ram

SELECT maker
FROM product
	JOIN pc
	ON product.model = pc.model
	WHERE pc.speed >= 400
	GROUP BY product.maker
	HAVING COUNT(*) >= 2*/