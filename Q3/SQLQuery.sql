select productname,quantity,totalamount from [Products].[dbo].[OrderItem] join [Products].[dbo].[Order] on ([Products].[dbo].[Order].OrderId=[Products].[dbo].[OrderItem].OrderId)
join [Products].[dbo].[Product] on ([Products].[dbo].[Product].ProductId=[Products].[dbo].[OrderItem].ProductId)