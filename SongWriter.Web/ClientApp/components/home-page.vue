<template>
    <div>
      <h1>Song Writer</h1>
      <a href="#" @click="createSong" class="btn btn-primary">Create Song</a>
    </div>
</template>

<script>
export default {
  data () {
    return {}
    },
    methods: {
      createSong() {
        console.log('Create song clicked');
      }
    }
}
</script>
