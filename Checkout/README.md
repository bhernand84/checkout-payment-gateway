README

Bank API

Used to absttract the behavior of the Bank API, specifically for processing payments. 

URI: http://localhost:5142/api/payment [POST], and expects an object of type ProcessPaymentRequest:

{
 "cardNumber":"22243433434343",
 "cvv":"122",
 "currency":"en-US"
 "amount": 1,
 "expirationDate": "11/01/2025"
}

There are currently two implementations of the IPaymentService, TestPaymentService, which returns success, and FailingPaymentService, which returns an error message. These dependencies are injected in Program.cs, so we will be easily able to integrate the live version of the service.


Checkout Payment API


URI: http://localhost:5209/api/payment [POST]
Used to process payment requests from merchants 

Sample request:

{
 "cardNumber":"22243433434343",
 "cvv":"122",
 "currency":"en-US"
 "amount": 1,
 "expirationDate": "11/01/2025"
}

URI: http://localhost:5209/api/payment/{id} [GET]
Retrieve information about a payment, given  an {id} - type int


Data store

Currently, the project is using an in-memory data store with EF. Data pushed to this store will not persist across application lifecycles.git commit