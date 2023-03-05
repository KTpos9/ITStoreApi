# ITStoreApi
Web API for [ITStore_Angular](https://github.com/KTpos9/ITStore_Angular). Build with ASP.NET Core.
## APIs

### Auth

| Name     | Request Url        | Method | Parameter | Respond Body                             |
| -------- | ------------------ | ------ | --------- | ---------------------------------------- |
| Register | /api/Auth/register | POST   | -         | [int,string,string,string,string,string] |
| Login    | /api/Auth/login    | POST   | -         | [string]                                 |

### Cart

| Name        | Request Url   | Method | Parameter | Respond Body               |
| ----------- | ------------- | ------ | --------- | -------------------------- |
| GetCart     | /api/Cart/    | GET    | -         | [int,string,string,string] |
| InsertCarrt | /api/Cart/    | POST   | -         | -                          |
| DeleteCart  | /api/Cart/:id | DELETE | -         | -                          |

### Member

| Name             | Request Url                   | Method | Parameter | Respond Body                             |
| ---------------- | ----------------------------- | ------ | --------- | ---------------------------------------- |
| GetMember        | /api/Member/               | GET    | -         | [int,string,string,string,string,string] |
| GetMemberById    | /api/Member/GetById/:id       | GET    | :id       | [int,string,string,string,string,string] |
| GetMemberByEmail | /api/Member/GetByEmail/:email | GET    | :email    | [int,string,string,string,string,string] |
| UpdateMember     | /api/Member/:id           | PUT    | -         | -                                        |
| DeleteMember     | /api/Member/:id         | DELETE | -         | -                                        |

### Order

| Name         | Request Url            | Method | Parameter | Respond Body                             |
| ------------ | ---------------------- | ------ | --------- | ---------------------------------------- |
| GetOrder     | /api/Order/get         | GET    | -         | [int,string,string,string,string,string] |
| GetOrderById | /api/Order/getById/:id | GET    | -         | [int,string,string,string,string,string] |
| InsertOrder  | /api/Order/        | POST   | -         | -                                        |
| UpdateOrder  | /api/Order/:id         | PUT    | -         | -                                        |
| DeleteOrder  | /api/Order/:id      | DELETE | -         | -                                        |

### Product

| Name           | Request Url              | Method | Parameter | Respond Body                             |
| -------------- | ------------------------ | ------ | --------- | ---------------------------------------- |
| GetProduct     | /api/Product/         | GET    | -         | [int,string,string,string,string,string] |
| GetProductById | /api/Product/getById/:id | GET    | -         | [int,string,string,string,string,string] |
| InsertProduct  | /api/Product/        | POST   | -         | -                                        |
| UpdateProduct  | /api/Product/:id         | PUT    | -         | -                                        |
| DeleteProduct  | /api/Product/:id      | DELETE | -         | -                                        |
