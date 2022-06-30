# README

## Bank API

Used to abstract the behavior of the Bank API, specifically for processing payments. 

### URI: http://localhost:5142/api/payment [POST]

#### Sample request
{
 "cardNumber":"22243433434343",
 "cvv":"122",
 "currency":"en-US"
 "amount": 1,
 "expirationDate": "11/01/2025"
}

## Checkout Payment API


### URI: http://localhost:5209/api/payment [POST]
Used to process payment requests from merchants 

#### Sample request:
{
 "cardNumber":"22243433434343",
 "cvv":"122",
 "currency":"en-US"
 "amount": 1,
 "expirationDate": "11/01/2025"
}

URI: http://localhost:5209/api/payment/{id} [GET]
Retrieve information about a payment, given  an {id} - type int


## Data store

Currently, the project is using an in-memory data store with EF. Data pushed to this store will not persist across application lifecycles.git commit

## Run instructions:
1. Pull the project from github
2. Open the Checkout.sln solution in Visual Studio
3. Right click the solution name, select Set Startup Projects
4. Give the configuration a name (the default is fine)
5. Select Bank.Api and Checkout.Payment.Api, select OK 
6. Run the project

## Postman  
Postman samples can be found in Postman/ folder. Import the collection into Postman to test the API.
1. Payment API - Payment POST will process a payment, if the Bank API is running
2. Payment API - Payment GET will retrieve a saved payment, if found.
3. Bank API  - Payment POST will process a payment directly against the vendor bank.

## Testing Bank
There are two implementations of IPaymentService in Bank.Api.Services:
- TestPaymentService.cs - will always return success, with a payment id of 111
- FailingPaymentService.cs - will always return failure
These dependencies are injected in Bank.Api.Program.cs, so we will be easily able to integrate the live version of the service.

## Assumptions made
- We will not be storing cvv in the datastore
- * is used to mask credit card number
- Expiration date can be stored as full date, in lieu of MMYYYY
- Amount is stored as decimal

## Areas for improvement
- Resource naming - this could be more consistent
- Add more robust descriptions to controller actions for swagger generation
- Credit card number and other sensitive fields should likely be stored in encrypted format for increased security
- Data store should be upgraded to a more permanent solution
- More robust error handling and logging across the board, but specifically in the service layer when calls to the BankApi are made
- Introduce Authentication/Authorization for both APIs
- Input validation - currently we are assuming happy path

