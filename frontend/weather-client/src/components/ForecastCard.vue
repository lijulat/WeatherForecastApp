<template>
  <div>
      <b-card class="mx-auto mx-md-2 my-md-2 shadow" style="max-width: 400px;" :title="formattedTitle">
        <b-card-sub-title>{{forecast.forecastDate | date }}</b-card-sub-title>
          <b-card-text>
            <b-row class="justify-content-md-center">
              <b-col class="display-4" cols="12">
                {{ forecast.temperature | round }} {{ forecastUnit.text }}
              </b-col>
              <b-col cols="12">
                <b-img
                  :src="forecast.weatherIconUrl"
                  alt="Sunny image"
                  width="92"
                ></b-img>
              </b-col>
            </b-row>
          </b-card-text>
        <b-card-body>
          <b-row class="justify-content-md-center">
            <b-col class="display-5" cols="6">
              <font-awesome-icon icon="tint" /> {{ forecast.humidity | round }} {{forecastUnit.humidity }}
            </b-col>
            <b-col class="display-5" cols="6">
              <font-awesome-icon icon="wind" /> {{ forecast.windSpeed | round }} {{forecastUnit.speed }}
            </b-col>
          </b-row>
      </b-card-body>
    </b-card>
</div>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'ForecastCard',
  props: ['forecast'],
  computed: {
    ...mapGetters(['forecastCity', 'forecastCountry', 'forecastUnit']),
    formattedTitle () {
      return `${this.forecastCity}, ${this.forecastCountry}`
    }
  }
}
</script>
