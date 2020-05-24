import { WeatherService } from '@/api/weather.service'
import RoundFilter from '@/common/round.filter'

export const setTemperatureUnit = ({ commit }, unitValue) => {
  commit('SET_UNIT', unitValue)
}

export const addHistory = ({ commit }, payload) => {
  let searchHistory = JSON.parse(localStorage.getItem('searchHistory')) || []
  const newHistoryItem = {
    city: payload.data.city,
    country: payload.data.country,
    temperature: `${RoundFilter(payload.data.dailyForecasts[0].temperature)} ${payload.unit.text}`,
    humidity: `${RoundFilter(payload.data.dailyForecasts[0].humidity)} ${payload.unit.humidity}`,
    windSpeed: `${RoundFilter(payload.data.dailyForecasts[0].windSpeed)} ${payload.unit.speed}`,
    searchedOn: new Date()
  }
  searchHistory = [...searchHistory, newHistoryItem]
  localStorage.setItem('searchHistory', JSON.stringify(searchHistory))
  commit('SET_HISTORY', searchHistory)
}

export const setInitialHistory = ({ commit }) => {
  const searchHistory = JSON.parse(localStorage.getItem('searchHistory')) || []
  commit('SET_HISTORY', searchHistory)
}

export const getWeatherForecasts = ({ commit, dispatch }, { searchString, unit }) => {
  commit('SET_STATUS', 'LOADING')
  return WeatherService.getForecast(searchString, unit.value)
    .then(({ data }) => {
      if (data) {
        commit('SET_FORECAST_INFO', data)
        commit('SET_STATUS', '')
        dispatch('addHistory', { data, unit })
      } else {
        commit('SET_FORECAST_INFO', {})
        commit('SET_STATUS', 'NO_DATA_FOUND')
      }
    })
    .catch(() => {
      commit('SET_STATUS', 'ERROR')
    })
}
