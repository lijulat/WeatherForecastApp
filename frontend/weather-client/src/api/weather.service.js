import Api from './api'

const END_POINT = 'weather'

export const WeatherService = {

  getForecastByCity (city, unit) {
    return Api.get(`${END_POINT}/forecast/city?cityName=${city}&unit=${unit}`)
  },

  getForecastByZip (zipCode, unit) {
    return Api.get(`${END_POINT}/forecast/zip?zipCode=${zipCode}&unit=${unit}`)
  },

  getForecast (searchString, unit) {
    var alphabetRegex = /[^a-zA-Z]/

    if (!alphabetRegex.test(searchString)) {
      return this.getForecastByCity(searchString, unit)
    } else {
      return this.getForecastByZip(searchString, unit)
    }
  }
}
