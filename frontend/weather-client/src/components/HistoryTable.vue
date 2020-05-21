<template>
  <div>
    <div v-if="historyData.length === 0">
      <b-alert variant="primary" show>No search history available.</b-alert>
    </div>
    <div v-else>
      <b-table small class="shadow" :fields="fields" :items="historyData" head-variant="light" bordered stacked="sm">
        <template v-slot:cell(#)="data">
          {{ data.index + 1 }}
        </template>
        <template v-slot:cell(citycountry)="data">
          {{ data.item.city }}, {{ data.item.country }}
        </template>
        <template v-slot:cell()="data">
          {{ data.value }}
        </template>
        <template v-slot:cell(searchedOn)="data">
          {{ data.value | date(true) }}
        </template>
      </b-table>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'
export default {
  name: 'HistoryTable',
  beforeMount () {
    this.setInitialHistory()
  },
  data () {
    return {
      fields: [
        '#',
        { key: 'citycountry', label: 'City' },
        'temperature',
        'humidity',
        'windSpeed',
        'searchedOn'
      ]
    }
  },
  computed: {
    ...mapState(['historyData'])
  },
  methods: {
    ...mapActions(['setInitialHistory'])
  }
}
</script>
