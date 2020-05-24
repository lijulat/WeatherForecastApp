<template>
  <div>
    <b-input-group class="mt-3">
      <b-form-input v-model="searchString" placeholder="Enter a city or zipcode"></b-form-input>
      <b-input-group-append>
        <b-button v-on:click="search" variant="outline-primary"><font-awesome-icon icon="search" /></b-button>
      </b-input-group-append>
    </b-input-group>
</div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'ForecastSearchBar',
  data () {
    return {
      searchString: ''
    }
  },
  computed: {
    ...mapGetters(['selectedTempUnit'])
  },

  methods: {
    ...mapActions(['getWeatherForecasts']),

    search () {
      this.getWeatherForecasts({ searchString: this.searchString, unit: this.selectedTempUnit })
    }
  }
}
</script>
