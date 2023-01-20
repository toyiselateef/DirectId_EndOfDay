# DirectID End-Of-Day Project
The main purpose of this repository is to show a simple .NET/React web application that uses .NET Web API technologies and React for UI to present an account End-Of-Day logs for each transaction day of a customer as well as account information of the customer.

# Getting Started


Technologies
C# .NET 6/React
Docker Support


### install npm dependencies
navigate to ./src/Web/ClientApp and run the command below to restore npm dependencies 
```
npm install
```
### install dotnet dependencies 

run  
```
dotnet restore
```


### run docker command 

run the command below at the root ./src/Web folder to execute Dockerfile step-by-step as specified in the dockerfile
```
build -t sample-image -f Dockerfile .
```
run the command below to validate image existence in Docker Image
```
Docker images
```

Create Docker Container
```
docker create --name sample-container sample-image
```

