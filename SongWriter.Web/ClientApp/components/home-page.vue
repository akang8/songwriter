<template>
    <div>
        <h1>Song Writer</h1>
        <a href="#" @click.prevent="createSong" class="btn btn-primary"><icon :icon="['fas', 'plus-square']" /> Add Document</a>
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
