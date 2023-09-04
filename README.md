# tripadvisor

# Steps to execute the trip advisor API

# Create Database
    1. Open MS Sql Server and create a database with the name "TripAdvisor"
    2. Open "SQLQuery_Create_Tables.sql" in MS Sql Server. Which is available in "tripadvisor/SqlQueries/" folder of this repository. 
    3. Execute the query in the "SQLQuery_Create_Tables.sql" or press F5 in MS Sql Server.
    4. Now a table ("DistrictTemperatures") is created in "TripAdvisor" database in your MS Sql Server.

# Execute the "TripAdvisor.API.exe"
    1. Download the "tripvisitor.api.zip" file from this repository, which is available in "tripadvisor/tripadvisor.api.release/" folder of this repository.
    2. Unzip the folder in your computer's prefered location.
    3. Open appsettings.json file, nd update "YOUR_SERVER_ADDRESS", "YOUR_USERNAME", "YOUR_PWSSEORD" strings in "ConnectionStrings" section, with your Ms Sql Server values.
    4. Double click on "TripAdvisor.API.exe"
    5. Now go to your favorite browser, and type or paste the url "http://localhost:5000/swagger/index.html"
    6. A swagger page will be loaded with three api

# Fetch data using the API's
    1. Load/Fetch district temperature data using "api/district/fetch-temperature-data", this api will take some time to fetch data.
        - If fetching data is successfull, you will see message like following 
            Data = "Data fetched successfully"
    2. If step 1 skipped, then the "/api/district/coolest10" and "api/trip/suggest" API will not work.
    3. Find the 10 coolest districts using "/api/district/coolest10" api.
    4. Get a trip suggestion using "api/trip/suggest" api.
        - Api Parameters 
          i.   StartingLocation -> a valid district name.
          ii.  Destination -> a valid district name.
          iii. TravelDate -> Desired travel date.  
       
