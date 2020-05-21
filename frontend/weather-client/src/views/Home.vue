<template>
  <b-container fluid>
    <b-row align-h="center" class="mb-5">
      <b-col class="mt-4" sm="6"><forecast-search-bar /></b-col>
    </b-row>
    <b-row align-h="center">
      <b-col align-self="center">
        <forecast-list />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
// @ is an alias to /src
import ForecastSearchBar from '@/components/ForecastSearchBar.vue'
import ForecastList from '@/components/ForecastList.vue'

export default {
  name: 'Home',
  components: {
    ForecastSearchBar,
    ForecastList
  }
}
</script>
