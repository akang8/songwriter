<template>
    <div>
        <h1>Song Writer</h1>
        <a href="#" @click.prevent="createSong" class="btn btn-primary"><icon :icon="['fas', 'plus-square']" /> Add Document</a>
        {{documents}}
    </div>
</template>
<script>
    export default {
        data() {
            return {
                documents: []
            }
        },
        methods: {
            createSong() {
                this.$router.push({ name: 'DocumentCreate' });
            },
            async loadDocuments() {
                try {
                    var result = await this.$http.get('/api/document')
                    if (result) {
                        this.documents = result.data;
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
            }
        },
        async created() {
            // Fire and forget, no need for await here?
            this.loadDocuments();
        }
    }
</script>
