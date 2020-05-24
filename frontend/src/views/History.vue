<template>
  <b-container>
    <b-row align-h="center" class="mb-3">
      <b-col class="mt-4"><h3>Search History</h3></b-col>
    </b-row>
    <b-row align-h="center">
      <b-col align-self="center">
        <history-table />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
// @ is an alias to /src
import HistoryTable from '@/components/HistoryTable.vue'

export default {
  components: {
    HistoryTable
  }
}
</script>
