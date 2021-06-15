go
select * from Production.Product 
select DaysToManufacture 
from Production.Product 
where name='blade'

--ans

select Name 
from Production.Product 
where DaysToManufacture In
(select DaysToManufacture 
from Production.Product 
where name='blade') 

--2
select * from Production.Product 


select name,Weight 
from Production.Product
where weight >= Any
(select max(Weight)
from Production.Product
Group by ProductModelID )

select name,Weight 
from Production.Product
where weight <> All
(select max(Weight)
from Production.Product
Group by ProductModelID )

select name,Weight 
from Production.Product
where weight >= some
(select max(Weight)
from Production.Product
Group by ProductModelID )

--3
select * from Sales.SalesPerson
select * from Sales.SalesTerritory
select * from Person.Person

select FirstName,LastName,salterr.Name ,salper.SalesLastYear
from Sales.SalesPerson salper
join Sales.SalesTerritory salterr
on salper.TerritoryID=salterr.TerritoryID
join Person.Person p
on p.BusinessEntityID=salper.BusinessEntityID
where salper.SalesLastYear in
(select max(SalesLastYear) from Sales.SalesPerson group by TerritoryID)




--4


select FirstName,LastName,Rate,pay.BusinessEntityID
from HumanResources.EmployeePayHistory pay
join person.person per
on per.BusinessEntityID = pay.BusinessEntityID
where Rate=(select max(Rate) 
from HumanResources.EmployeePayHistory)


select per.LastName,per.FirstName
from Person.Person per
where 250000 in
	(select SalesQuota
	 from Sales.SalesPerson ssp
	 where per.BusinessEntityID=ssp.BusinessEntityID
	)


--5
select sod1.ProductID,OrderQty,UnitPrice,AvgUnitPrice
from Sales.SalesOrderDetail sod1
join
(select ProductID,avg(UnitPrice) AvgUnitPrice
from Sales.SalesOrderDetail
group by ProductID) 
as tle
on sod1.ProductID=tle.ProductID
where UnitPrice<AvgUnitPrice
order by ProductID