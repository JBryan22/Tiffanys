Users
-UserName
-Password

Associates
-AssociateId
-TotalSales
-TotalReturns
-UserId(virtual)

Products
-ProductId
-Name
-Cost
-RetailPrice
-Revenue(static)
-Cost(static)

Items
-ItemId
-Sold
-ProductId

AssociateItems
-Id(create in model)
-AssociateId(relationship created when item is sold)
-ItemId