import { mount, createLocalVue } from '@vue/test-utils'
import HeaderNav from '@/components/HeaderNav.vue'
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

describe('HeaderNav.vue', () => {

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
      setTemperatureUnit: jest.fn()
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

    const wrapper = mount(HeaderNav, {      
      store, 
      localVue
    })
    expect(wrapper.element).toMatchSnapshot()
  })

  it('setTemperatureUnit action is called', () => {
    const wrapper = mount(HeaderNav, {
      store, 
      localVue
    })

    wrapper.find('.dropdown-item').trigger('click')    
    expect(actions.setTemperatureUnit).toHaveBeenCalled()
  })
})
