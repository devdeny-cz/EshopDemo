# Introduction
This is demo web application which can get all (fake) or one product and edit product description. 

# Usage

Call rest api (any client or dev swaggerUI)

## Get product by id
https://[server address]api/ProductController?id=[productId]  
Type: Get  
success result: Product serialize to Json  
bad result: bad request with error message if product or not exist or catch exception  

## Get all existing products
https://[server address]/ProductController/getall
Type: Get  
success result: Products serialize to Json  
bad result: bad request with error message if not exist any product or catch exception

## UpdateProductDescription
https://[server address]/ProductController/update/[product id]&description=[new product description]  
Type: Pul  
succes result: 200
bad result: bad request with error message or catch exception

# Installion/Run
* 

# Technologies
.ASP core WebApi

## Test
Moq - for mocking virtual entities and dependency
FluentAssertion - compare equivalent of object (test assertion)

## Design Pattern 
MVC
UnitOfWork
Repository

# Development information
* I'm not sure with all asp configuration - I  don't have extensive experience with ASP. My experiences are like backend without ASP aplications. 
* I don't use google (or another search engine) for help during case study. Just documentation of https://github.com/domaindrivendev/Swashbuckle.WebApi

