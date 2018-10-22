<template>
    <div>
        <h1>Song Writer</h1>
        <a href="#" @click.prevent="createSong" class="btn btn-primary">Create Song</a>
    </div>
</template>
<script>
    export default {
        data() {
            return {}
        },
        methods: {
            createSong() {
                this.$router.push({ name: 'DocumentCreate' });
            }
        }
    }
</script>
