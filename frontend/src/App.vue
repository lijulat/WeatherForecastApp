<template>
  <div id="app">
    <header-nav />
    <router-view/>
    <b-navbar id="footer" class="sticky-bottom">
      <b-container>
        <b-row class="justify-content-md-center w-100">
          <b-col>Copyright &copy; Weather App 2020</b-col>
        </b-row>
      </b-container>
    </b-navbar>
  </div>
</template>
<script>
import HeaderNav from '@/components/HeaderNav.vue'
export default {
  name: 'app',
  components: {
    HeaderNav
  }
}
</script>
<style>
#app {
  font-family: "Nunito", -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: #858796;
  text-align: center;
  background-color: #fff;
}
#footer {
  text-align: center;
  background-color: #eee;
  margin-bottom: -150px;
}
.shadow {
  box-shadow: 0 0.15rem 1.75rem 0 rgba(58, 59, 69, 0.15) !important;
}
h3 {
  font-weight: 400 !important;;
  color: #5a5c69 !important;
}
h4 {
  font-weight: 400 !important;
}
h6 {
  font-weight: 400 !important;
}
</style>
