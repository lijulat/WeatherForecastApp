export const SET_UNIT = (state, unitValue) => {
  state.unit = state.units.find(unit => {
    return unit.value === unitValue
  })
}

export const SET_FORECAST_INFO = (state, data) => {
  state.forecastInfo.data = data
  state.forecastInfo.unit = state.unit
}

export const SET_HISTORY = (state, history) => {
  state.historyData = history
}

export const SET_STATUS = (state, status) => {
  state.status = status
}
