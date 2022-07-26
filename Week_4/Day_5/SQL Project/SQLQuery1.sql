--1.1
SELECT CustomerID, CompanyName, Address, City, Region, PostalCode, Country
FROM Customers
WHERE City IN ('Paris', 'London');
--1.2, 1.3
SELECT p.productname, p.quantityperunit, s.companyname, s.country
FROM products p
JOIN suppliers s
	ON p.supplierid = s.supplierid
WHERE quantityperunit LIKE '%bottle%'
--1.4
SELECT c.categoryname, COUNT(p.productid) AS "Total Products"
FROM products p
JOIN categories c
ON p.categoryid = c.categoryid
GROUP BY c.categoryname
ORDER BY "Total Products" DESC;
--1.5
SELECT firstname + ' ' + lastname AS "Full Name", city
FROM employees;
--1.6
SELECT COUNT(orderid) AS "Total Orders"
FROM orders
WHERE freight > 100 AND shipcountry IN ('USA', 'UK')
GROUP BY shipcountry;
--1.7
SELECT TOP 1 *
FROM [order details]
ORDER BY discount DESC;
--1.8
SELECT firstname + ' ' + lastname AS "Full Name", reportsto
FROM employees


