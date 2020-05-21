import { mount, createLocalVue } from '@vue/test-utils'
import ForecastSearchBar from '@/components/ForecastSearchBar.vue'
import Vuex from 'vuex'
import BootstrapVue from 'bootstrap-vue'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faTemperatureLow, faWind, faTint, faSearch, faCog } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const localVue = createLocalVue()

library.add(faTemperatureLow, faWind, faTint, faSearch, faCog)
localVue.component('font-awesome-icon', FontAwesomeIcon)

localVue.use(BootstrapVue)

localVue.use(Vuex)

describe('ForecastSearchBar.vue', () => {

  let getters
  let actions
  let store

  const mockUnit = {
    value: '',
    text: 'K',
    speed: 'm/s',
    humidity: '%'
  }
  
  beforeEach(() => {
    actions = {
      getWeatherForecasts: jest.fn()
    }
    getters = {
      selectedTempUnit: () => mockUnit
    }
    store = new Vuex.Store({
      getters,
      actions
    })
  })


  it('component renders correctly', () => {    

    const wrapper = mount(ForecastSearchBar, {      
      store, 
      localVue
    })
    expect(wrapper.element).toMatchSnapshot()
  })

  it('search method is called', () => {

    let search = jest.fn()

    const wrapper = mount(ForecastSearchBar, {      
      methods: {
        search
      },            
      store, 
      localVue
    })

    wrapper.find('button').trigger('click')
    expect(search).toHaveBeenCalled()
  })

  it('getWeatherForecasts action is called', () => {
    const wrapper = mount(ForecastSearchBar, {
      store, 
      localVue
    })

    wrapper.find('button').trigger('click')    
    expect(actions.getWeatherForecasts).toHaveBeenCalled()
  })
})
