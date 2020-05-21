import { mount, createLocalVue } from '@vue/test-utils'
import HistoryTable from '@/components/HistoryTable.vue'
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

localVue.filter('date', () => 'Today')

describe('HistoryTable.vue', () => {

  let state
  let actions
  let store

  const mockData = [
  {
    city: 'Hamburg',
    country: 'DE',
    temperature: '20 °C',
    humidity: '5 %',
    windSpeed: '8 m/s'
  }]
  
  beforeEach(() => {
    actions = {
      setInitialHistory: jest.fn()
    }
    state = {
      historyData: mockData
    }
    store = new Vuex.Store({
      actions,
      state
    })
  })


  it('component renders correctly', () => {
    const wrapper = mount(HistoryTable, {      
      store, 
      localVue
    })
    expect(wrapper.element).toMatchSnapshot()
  })

  it('setInitialHistory action is called', () => {
    const wrapper = mount(HistoryTable, {
      store, 
      localVue
    })
        
    expect(actions.setInitialHistory).toHaveBeenCalled()
  })

  it('when data is not empty table is rendered', () => {
    const wrapper = mount(HistoryTable, {
      store, 
      localVue
    })
        
    const table = wrapper.find('table')
    expect(table.exists()).toBe(true)

    const alert = wrapper.find('.alert')
    expect(alert.exists()).toBe(false)
  })

  it('when data is empty alert is rendered', () => {
    state = {
      historyData: []
    }
    store = new Vuex.Store({
      actions,
      state
    })

    const wrapper = mount(HistoryTable, {
      store, 
      localVue
    })
        
    const table = wrapper.find('table')
    expect(table.exists()).toBe(false)

    const alert = wrapper.find('.alert')
    expect(alert.exists()).toBe(true)
    expect(alert.text()).toBe('No search history available.')    
  })
})
