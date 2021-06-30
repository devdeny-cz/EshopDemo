# Introduction
This is demo web application which can get all (fake) or one product and edit product description. It is easy demo - serving as interview task.  
I haven't got extensive experience with ASP, so my main goal was show abstract design idea.  

# Usage

Call rest api (any client or dev swaggerUI)

## Get product by id
https://[server address]api/ProductController?id=[productId]  
Type: Get  
success result: Product serialize to Json  
bad result: bad request with error message - catch exception  
not found: product not exist (404)

## Get all existing products
https://[server address]/ProductController/getall
Type: Get  
success result: Products serialize to Json  (200)
bad result: bad request with error message (400)
Not found: if not exist any product or catch exception (404)

## UpdateProductDescription
https://[server address]/ProductController/update/[product id]&description=[new product description]  
Type: Pul  
succes result: 200
bad result: bad request with error message or catch exception
Not found:  product for update not exist (404)

# Installion/Run

## Demo
1. Download solution codes
1. Start developer command prompt for VS 2019
1. use command dotnet `run --project [your folder]/EshopDemoService/EshopDemoService.`csproj
1. get service url address from console and use: `[address]/swagger/index.html`
1. choose function and try it

## Test
1. Download solution codes
1. Start developer command prompt for VS 2019
1. use command: `dotnet test "[your folder]\EshopDemo.sln"`
1. you get test results


# Technologies
.ASP core WebApi

## Test
* Moq - for mocking virtual entities and dependency  
* FluentAssertion - compare equivalent of object (test assertion)

## Design Pattern 
* MVC
* UnitOfWork
* Repository

# Development information
* I'm not sure with all asp configuration - I  don't have extensive experience with ASP. My experiences are like backend without ASP aplications. 
* I don't use google (or another search engine) for help during case study. Just documentation of https://github.com/domaindrivendev/Swashbuckle.WebApi

