<template>
  <div>
    <h1>Edit Song #{{id}}</h1>
    <div class="form-group">
      <label>Name</label>
      <input type="text" class="form-control" v-model="model.name" />
    </div>
    <div class="form-group">
      <label>Text</label>
      <textarea class="form-control" v-model="model.text"></textarea>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        model: {
          name: '',
          text: ''
        }
      }
    },
    props: {
      id: {
        type: Number,
        required: true
      }
    },
    methods: {
      async loadSong() {
        try {
          var result = await this.$http.get('/api/document')
          if (result) {

          }
        } catch (err) {
          window.alert(err)
          console.log(err)
        }
      }
    },
    async created() {

    }
  }
</script>

<style>
</style>
