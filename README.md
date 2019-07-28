# DynamicLoadingAspNetCore

Just small playground project, what it does:
* Open SSMS/Azure Data Studio (or any program that allow you to connect to a database), connect to the local server: (localdb)\MSSQLLocalDB
* Open the Solution and go to the WebsiteFolder\bin\Debug\netcoreapp3.0\plugins\Payments
* Move both dlls to another folder / desktop
* Run the project (the database will be created with the Payments tables)
* Run this query:

```sql
SELECT *
FROM [DynamicWebsite].[Payments].[Providers]

SELECT *
FROM [DynamicWebsite].[Payments].[ProvidersConfiguration]
```
* Move one or both dlls to the Payments Folder and re-run the query and refresh the database tables.
* Refresh the website
* Press Activate
