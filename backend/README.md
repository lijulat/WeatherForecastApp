# Weather App Backend Rest Api

## Dependencies

- .Net Core Sdk 3.1.300

## Configuration

Configuration for the application is at `WeatherApi/appsettings.json`.
The following open weather map api parameters can be set in config files:

- ApiBaseUrl: The base url for the openweathermap api
- ForecastRoute: the url route for the openweathermap api forecast endpoint
- CurrentWeatherRoute: the url route for the openweathermap api current weather endpoint
- ApiKey: the api key to access the openwethermap api. Key can be obtained from https://openweathermap.org/api
- IconUrl: the url for the openweathermap icons
- DefaultCountryCode: the default country code used to get the weather data from openweathermap api
- TimoutSeconds: the timeout value in seconds for the call to openweathermap api
- RetryCount: the number of retry attempts to the openweathermap api after a http transient error


## Local deployment

- Install dependencies `dotnet restore`
- Build the app `dotnet build`
- Run the app from the WeatherApi folder `dotnet run`
- App is running at `https://localhost:<PORT_NO>/`
- Swagger can be acccessed at `https://localhost:<PORT_NO>/swagger/index.html`


