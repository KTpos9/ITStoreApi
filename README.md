# ITStoreApi
Web API for [ITStore_Angular](https://github.com/KTpos9/ITStore_Angular). Build with ASP.NET Core.
## APIs

### Auth

| Name     | Request Url        | Method | Parameter | Respond Body                             |
| -------- | ------------------ | ------ | --------- | ---------------------------------------- |
| Register | /api/Auth/register | POST   | -         | [int,string,string,string,string,string] |
| Login    | /api/Auth/login    | POST   | -         | [string]                                 |

### Cart

| Name        | Request Url          | Method | Parameter | Respond Body               |
| ----------- | -------------------- | ------ | --------- | -------------------------- |
| GetCart     | /api/Cart/get        | GET    | -         | [int,string,string,string] |
| InsertCarrt | /api/Cart/post       | POST   | -         | -                          |
| DeleteCart  | /api/Cart/delete/:id | DELETE | -         | -                          |

### Member

| Name             | Request Url                   | Method | Parameter | Respond Body                             |
| ---------------- | ----------------------------- | ------ | --------- | ---------------------------------------- |
| GetMember        | /api/Member/get               | GET    | -         | [int,string,string,string,string,string] |
| GetMemberById    | /api/Member/GetById/:id       | GET    | :id       | [int,string,string,string,string,string] |
| GetMemberByEmail | /api/Member/GetByEmail/:email | GET    | :email    | [int,string,string,string,string,string] |
| UpdateMember     | /api/Member/put               | PUT    | -         | -                                        |
| DeleteMember     | /api/Member/Delete            | DELETE | -         | -                                        |

### Order

| Name         | Request Url            | Method | Parameter | Respond Body                             |
| ------------ | ---------------------- | ------ | --------- | ---------------------------------------- |
| GetOrder     | /api/Order/get         | GET    | -         | [int,string,string,string,string,string] |
| GetOrderById | /api/Order/getById/:id | GET    | -         | [int,string,string,string,string,string] |
| InsertOrder  | /api/Order/post        | POST   | -         | -                                        |
| UpdateOrder  | /api/Order/put         | PUT    | -         | -                                        |
| DeleteOrder  | /api/Order/delete      | DELETE | -         | -                                        |

### Product

| Name         | Request Url            | Method | Parameter | Respond Body                             |
| ------------ | ---------------------- | ------ | --------- | ---------------------------------------- |
| GetOrder     | /api/Product/get       | GET    | -         | [int,string,string,string,string,string] |
| GetOrderById | /api/Order/getById/:id | GET    | -         | [int,string,string,string,string,string] |
| InsertOrder  | /api/Product/post      | POST   | -         | -                                        |
| UpdateOrder  | /api/Product/put       | PUT    | -         | -                                        |
| DeleteOrder  | /api/Product/delete    | DELETE | -         | -                                        |
