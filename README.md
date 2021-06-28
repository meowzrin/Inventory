Steps to run project:
1. Go to appsettings.json and change the server name in the connection string to "ProductDBConnection": "server=YOUR_SERVERNAME;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;database=ProductDB"
  },
  "AllowedHosts": "*"

}
"
2. In Visual Studio Go to View->Other Windows Package Manager Console
3. In Package Manager Console - Type Add-Migration initial
4. Once successful type - Update-Database
5. Click F5 and set up fiddler with the below endpoints




# Inventory
Web API crud operations

https://localhost:44302/Inventory/getProducts
https://localhost:44302/Inventory/removeProducts/2

https://localhost:44302/Inventory/editProducts/1
User-Agent: Fiddler
Host: localhost:44302
Content-Length: 65

{"name":"Wardrobe","description":"Grey cupboard","price":2350}

https://localhost:44302/Inventory/addProducts
User-Agent: Fiddler
Host: localhost:44302
Content-Length: 65

{"name":"Cupboard","description":"Grey cupboard","price":2350}
