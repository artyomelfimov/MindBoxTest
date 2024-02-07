# Задача на C#
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

- Юнит-тесты

- Легкость добавления других фигур

- Вычисление площади фигуры без знания типа фигуры

- Проверку на то, является ли треугольник прямоугольным

**Решение задачи:**

Здесь [библиотека](https://github.com/artyomelfimov/MindBoxTest/blob/master/ShapeLibrary/Program.cs)

Здесь [тесты](https://github.com/artyomelfimov/MindBoxTest/blob/master/Tests/UnitTest.cs)
# Задача на SQL
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
**Решение задачи:**

Если предполагается дополнительная таблица с отношениями:

SELECT p.name AS product, c.name AS category FROM Products AS p
LEFT JOIN ProdCat AS pc ON p.id = pc.products_id
LEFT JOIN Category AS c ON c.id = pc.category_id
ORDER BY product;

Без таблицы:

SELECT p.name AS product, c.name AS category FROM Products AS p
Left JOIN Category AS c ON c.category_id = c.id
ORDER BY product;
