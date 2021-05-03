USE DBName

SELECT Good.[Name] AS 'Товар', Category.[Name] AS 'Категория' 
FROM GoodCategory
FULL JOIN Good ON Good.Id = GoodCategory.IdGood
FULL JOIN Category ON Category.Id = GoodCategory.IdCategory
WHERE Good.[Name] = GoodName