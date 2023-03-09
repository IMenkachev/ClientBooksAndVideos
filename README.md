# Description
**BooksAndVideos** is an e-commerce shop where customers can view books and watch online videos. Users 
can have memberships for the book club, the video club or for both clubs (premium).

This is a Code Kata showcase challange that required building an webapi for exposing checkout order functionality.

## Requirements

### Business requirements
- BR1. If the purchase order contains a membership, it has to be activated in the customer account immediately.
- BR2. If the purchase order contains a physical product a shipping slip has to be generated.

## Instructions

When you run the app, it will spinup five containers.

1. *customercommands.api* which exposes port 8001 E.g: `http://localhost:8001/swagger` endpoint. 
  - This API is for writing data only. 
  - When you run the app it will automatically push data into "Customers", "Memberships" and "Products" tables. 
  - Hit the "SyncData" in order to push the data from "customercommands.api" mssql into "customerquery.api" mongodb database.
2. *customerquery.api* which exposes port 8000 E.g: `http://localhost:8000/swagger`.
  - This API is for reading data only.
3. *BooksAndVideosMssqlDb* which exposes the default 1433 mssql port and it is availible at Server Name: `localhost` with credentials that could be found in the `\docker-compose.override.yml` file.
4. *BooksAndVideosMongoDb*.
5. *rabbitmq* which exposes the default 15672 port with credentials "guest"/"guest".

Additionally a public postman collection is available. Please note that the Id's in the requests will be different and could be found by connecting to the mssql database.
