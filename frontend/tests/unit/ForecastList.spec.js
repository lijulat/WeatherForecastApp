import { shallowMount, createLocalVue } from '@vue/test-utils'
import ForecastList from '@/components/ForecastList.vue'
import Vuex from 'vuex'
import BootstrapVue from 'bootstrap-vue'

const localVue = createLocalVue()

localVue.use(BootstrapVue)

localVue.use(Vuex)

describe('ForecastList.vue', () => {
  let getters
  let store

  const mockData = [
  {
    forecastDate: '',
    temperature: '',
    weatherIconUrl: '',
    humidity: '',
    windSpeed: ''
  }]

  let actions = {
    setInitialStatus: jest.fn()
  }

  it('component renders correctly', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: ''
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })
    expect(wrapper.element).toMatchSnapshot()
  })

  it('renders loading spinner', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: 'LOADING'
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })

    const spinner = wrapper.find('b-spinner-stub')
    expect(spinner.exists()).toBe(true)
  })

  it('renders no date text', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: 'NO_DATA_FOUND'
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })

    const alert = wrapper.find('b-alert-stub')
    expect(alert.exists()).toBe(true)
    expect(alert.text()).toBe('Weather forecast for the search could not be found.')
  })

  it('renders api error text correctly', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: 'API_ERROR'
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })

    const alert = wrapper.find('b-alert-stub')
    expect(alert.exists()).toBe(true)
    expect(alert.text()).toBe('An Error occurred. Please try again.')
  })

  it('renders empty search param error text correctly', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: 'EMPTY_SEARCH_PARAM'
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })

    const alert = wrapper.find('b-alert-stub')
    expect(alert.exists()).toBe(true)
    expect(alert.text()).toBe('City or zipcode must be entered.')
  })

  it('renders forecast list correctly', () => {
    getters = {
      forecastData: () => mockData
    }

    const state = {
      status: ''
    }

    store = new Vuex.Store({
      state,
      getters,
      actions
    })

    const wrapper = shallowMount(ForecastList, {
      store,
      localVue
    })

    const spinner = wrapper.find('b-spinner-stub')
    expect(spinner.exists()).toBe(false)

    const alert = wrapper.find('b-alert-stub')
    expect(alert.exists()).toBe(false)
  })
})
