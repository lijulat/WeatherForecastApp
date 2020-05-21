export const selectedTempUnit = (state) => {
  //  default is kelvin
  return state.unit
}

export const forecastCity = (state) => {
  //  default is kelvin
  return state.forecastInfo.data.city
}

export const forecastCountry = (state) => {
  //  default is kelvin
  return state.forecastInfo.data.country
}

export const forecastData = (state) => {
  //  default is kelvin
  return state.forecastInfo.data.dailyForecasts
}

export const forecastUnit = (state) => {
  //  default is kelvin
  return state.forecastInfo.unit
}
