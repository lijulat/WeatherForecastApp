<template>
  <div class="mb-3 pl-md-5 pl-lg-4 pl-xl-5">
    <div v-if="status === 'LOADING'" class="d-flex justify-content-center mb-3">
      <b-spinner variant="primary"></b-spinner>
    </div>
    <div v-else>
      <div v-if="status === 'NO_DATA_FOUND'">
        <b-alert variant="warning" show>Weather forecast for the search could not be found.</b-alert>
      </div>
      <div v-else-if="status === 'EMPTY_SEARCH_PARAM'">
        <b-alert variant="danger" show>City or zipcode must be entered.</b-alert>
      </div>
      <div v-else-if="status === 'API_ERROR'">
        <b-alert variant="danger" show>An Error occurred. Please try again.</b-alert>
      </div>
      <b-card-group v-else deck>
        <forecast-card v-for="forecast in forecastData" :key="forecast.forecastDate" :forecast="forecast" />
      </b-card-group>
    </div>
  </div>
</template>

<script>
import ForecastCard from './ForecastCard.vue'
import { mapGetters, mapState, mapActions } from 'vuex'
export default {
  name: 'ForecastList',
  components: {
    ForecastCard
  },
  beforeMount () {
    this.setInitialStatus()
  },
  computed: {
    ...mapState(['status']),
    ...mapGetters(['forecastData'])
  },
  methods: {
    ...mapActions(['setInitialStatus'])
  }
}
</script>
