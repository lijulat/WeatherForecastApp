import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faTemperatureLow, faWind, faTint, faSearch, faCog } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import RoundFilter from '@/common/round.filter'
import DateFilter from '@/common/date.filter'

library.add(faTemperatureLow, faWind, faTint, faSearch, faCog)
Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.use(BootstrapVue)

Vue.config.productionTip = false

Vue.filter('round', RoundFilter)
Vue.filter('date', DateFilter)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
