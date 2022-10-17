USE pc

/*INSERT INTO pc (code, model, speed, ram, hd, cd, price)
VALUES (12, '1100', 2400, 2048, 500, '52x', 299)

INSERT INTO product (maker, model, type)
VALUES ('C', '1100', 'PC')

DELETE FROM pc
WHERE model = '1100'

DELETE FROM laptop
WHERE model IN (
	SELECT model
	FROM product
	WHERE maker NOT IN (
		SELECT maker
		FROM product
		WHERE type = 'Printer'
	)
)

UPDATE product
SET maker = 'A'
WHERE maker = 'B'

UPDATE pc
SET price /= 2, hd += 20*/