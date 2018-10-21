<template>
    <div>
        <h1>Weather forecast</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <div v-if="!items" class="text-center">
            <p><em>Loading...</em></p>
            <h1><icon icon="spinner" pulse/></h1>            
        </div>

        <template v-if="items">
          {{items}}
        </template>
    </div>
</template>

<script>
export default {
  data () {
    return {
      items: null
    }
  },
  methods: {
    async loadPage () {
      try {
        let response = await this.$http.get('/api/document')
        console.log(response.data)
        this.items = response.data
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
  },
  async created () {
    this.loadPage()
  }
}
</script>

<style>
</style>
