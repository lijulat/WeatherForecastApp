import { mount, createLocalVue } from '@vue/test-utils'
import ForecastCard from '@/components/ForecastCard.vue'
import Vuex from 'vuex'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faTemperatureLow, faWind, faTint, faSearch, faCog } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import BootstrapVue from 'bootstrap-vue'

const localVue = createLocalVue()

library.add(faTemperatureLow, faWind, faTint, faSearch, faCog)
localVue.component('font-awesome-icon', FontAwesomeIcon)

localVue.use(BootstrapVue)

localVue.use(Vuex)
localVue.filter('round', () => '123')
localVue.filter('date', () => 'Today')

describe('ForecastCard.vue', () => {
  let getters
  let store

  const mockUnit = {
    value: '',
    text: 'K',
    speed: 'm/s',
    humidity: '%'
  }

  const mockData = {
    forecastDate: '',
    temperature: '',
    weatherIconUrl: '',
    humidity: '',
    windSpeed: ''
  }

  beforeEach(() => {
    getters = {
      forecastCity: () => 'Hamburg',
      forecastCountry: () => 'DE',
      forecastUnit: () => mockUnit
    }
    store = new Vuex.Store({
      getters
    })
  })

  it('component renders correctly', () => {
    const wrapper = mount(ForecastCard, {
      propsData: {
        forecast: mockData
      },
      store,
      localVue
    })
    expect(wrapper.element).toMatchSnapshot()
  })

  it('renders city country correctly', () => {
    const wrapper = mount(ForecastCard, {
      propsData: {
        forecast: mockData
      },
      store,
      localVue
    })
    const card = wrapper.find('.card-title')
    expect(card.exists()).toBe(true)
    expect(card.text()).toBe('Hamburg, DE')
  })

  it('renders date correctly', () => {
    const wrapper = mount(ForecastCard, {
      propsData: {
        forecast: mockData
      },
      store,
      localVue
    })
    const cardSubTitle = wrapper.find('.card-subtitle')
    expect(cardSubTitle.exists()).toBe(true)
    expect(cardSubTitle.text()).toBe('Today')
  })
})
