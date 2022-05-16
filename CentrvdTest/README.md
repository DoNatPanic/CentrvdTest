## CentrvdTest - консольное приложение с базой данных SQLite, с подключенным EntityFramework

### SQL Запросы, используемые для решения задачи

##### Задача 1
SELECT extTbl1.Id, extTbl1.Sum, extTbl2.Sum FROM 
(
SELECT Id, Sum FROM Departments
LEFT JOIN 
(SELECT Department_id, SUM(Salary) AS Sum
FROM Employees 
GROUP BY Department_id) AS innerTbl1
ON Departments.Id = innerTbl1.Department_id) AS extTbl1

##### Задача 2
LEFT JOIN
(
SELECT Id, Sum FROM Departments
LEFT JOIN 
(SELECT Department_id, SUM(Salary) AS Sum 
FROM (
SELECT * FROM Employees WHERE id NOT IN 
(SELECT DISTINCT chief_id
FROM Employees ))
GROUP BY Department_id) AS innerTbl2
ON Departments.Id = innerTbl2.Department_id) AS extTbl2

ON extTbl1.Id = extTbl2.Id

##### Задача 3
SELECT Department_id
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees)


SELECT Salary FROM Employees WHERE id IN 
(SELECT DISTINCT chief_id
FROM Employees )
ORDER BY Salary desc

### Для запуска приложения необходимо:
- Выполнить сборку решения в любой IDE (например, Visual Studio)
при этом из источника nuget подтянутся используемые библиотеки (необходимо подкчлючение к интернету)
- Затем перейти в папку bin/Release, найти исполняемый файл с расширением .exe и запустить его (либо запустить из IDE)
- Для просмотра таблиц базы данных SQLite можно использовать, например SQLiteStudio (сама БД будет находиться также в bin/Release)