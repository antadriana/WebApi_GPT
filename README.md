Application Description
This Web API application serves as a comprehensive interface for querying and manipulating country data, backed by the REST Countries API. Built on the robust .NET 6 platform and utilizing ASP.NET Core, the application aims to provide an easy-to-use, high-performance solution for developers and businesses. It offers various functionalities like data fetching, filtering, sorting, and limiting the number of records.

The application exposes a single endpoint that allows users to fetch a list of countries with different query parameters for customizing the output. You can filter countries based on their name or population size, sort them in ascending or descending order, and limit the number of records returned. Whether you are building a global dashboard, integrating country data into your app, or need rapid access to country information, this API is designed to meet a broad spectrum of needs efficiently.# WebApi_GPT4

Running the Application Locally
Prerequisites
Install .NET 6 SDK
Clone the repository or download the source code
A suitable IDE like Visual Studio 2019 or later, or Visual Studio Code
Steps
Using Visual Studio
Open the solution file WebApi_GPT.sln in Visual Studio.
Right-click on the WebApi_GPT project in the Solution Explorer and set it as the StartUp Project.
Press F5 or click on the Start Debugging button to run the application.
Open a web browser and navigate to http://localhost:<port>/api/countries to test the API.
Using Command Line
Open a terminal and navigate to the directory where the WebApi_GPT.csproj file is located.
Run dotnet restore to restore the necessary packages.
Run dotnet build to compile the application.
Run dotnet run to start the application.
Open a web browser and navigate to http://localhost:5000/api/countries or https://localhost:5001/api/countries to test the API.
Using the API
You can use various query parameters to filter, sort, and limit the countries returned by the API. For example:

To filter countries by name: http://localhost:<port>/api/countries?nameFilter=ind
To filter countries by population: http://localhost:<port>/api/countries?populationFilterInMillions=1000
To sort countries: http://localhost:<port>/api/countries?sortOrder=ascend
To limit the number of records: http://localhost:<port>/api/countries?limit=10
Replace <port> with the port number where the application is running.

Examples
1.Fetch All Countries
http://localhost:<port>/api/countries

2.Filter Countries by Name (Partial match for "United")
http://localhost:<port>/api/countries?nameFilter=United

3.Filter Countries by Population (Countries with less than 2 million population)
http://localhost:<port>/api/countries?populationFilterInMillions=2

4.Sort Countries by Name in Ascending Order
http://localhost:<port>/api/countries?sortOrder=ascend

5.Sort Countries by Name in Descending Order
http://localhost:<port>/api/countries?sortOrder=descend

6.Limit the Number of Records to 5
http://localhost:<port>/api/countries?limit=5

7.Filter Countries by Name ("India") and Sort in Ascending Order
http://localhost:<port>/api/countries?nameFilter=India&sortOrder=ascend

8.Filter Countries by Population (less than 1 million) and Sort in Descending Order
http://localhost:<port>/api/countries?populationFilterInMillions=1&sortOrder=descend

9.Filter Countries by Population (less than 1 million) and Limit Records to 3
http://localhost:<port>/api/countries?populationFilterInMillions=1&limit=3

10.Composite Query: Filter by Name ("Aus"), Sort in Ascending Order, and Limit Records to 2
http://localhost:<port>/api/countries?nameFilter=Aus&sortOrder=ascend&limit=2


