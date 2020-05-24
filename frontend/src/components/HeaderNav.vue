<template>
  <div>
  <b-navbar toggleable="lg" type="dark" variant="primary">
    <b-navbar-brand href="#">
      <img src="../assets/weather-forecast-logo.png" width="50" height="50" class="d-inline-block" alt="Kitten">
      Weather Forecast App
    </b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item :to="{ name: 'Home'}" >Home</b-nav-item>
        <b-nav-item :to="{ name: 'History'}">History</b-nav-item>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">
        <b-nav-item-dropdown variant="outline-primary" no-caret right>
          <template v-slot:button-content>
            <span class="mr-2">{{selectedTempUnit.text}}</span>
            <font-awesome-icon icon="cog" />
          </template>
          <b-dropdown-item @click="setTemperatureUnit('')" href="#">K</b-dropdown-item>
          <b-dropdown-item @click="setTemperatureUnit('metric')" href="#">°C</b-dropdown-item>
          <b-dropdown-item @click="setTemperatureUnit('imperial')" href="#">°F</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'HeaderNav',
  beforeMount () {
    this.setTemperatureUnit('')
  },
  computed: {
    ...mapGetters(['selectedTempUnit'])
  },
  methods: {
    ...mapActions(['setTemperatureUnit'])
  }
}
</script>
