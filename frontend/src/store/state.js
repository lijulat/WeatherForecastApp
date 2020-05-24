export default {
  units: [
    {
      value: '',
      text: 'K',
      speed: 'm/s',
      humidity: '%'
    },
    {
      value: 'metric',
      text: '°C',
      speed: 'm/s',
      humidity: '%'
    },
    {
      value: 'imperial',
      text: '°F',
      speed: 'mph',
      humidity: '%'
    }
  ],
  unit: null,
  forecastInfo: {
    unit: {},
    data: {}
  },
  historyData: [],
  status: ''
}
