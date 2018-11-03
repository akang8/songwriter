<template>
    <div>
        <h1>Song Writer</h1>
        <a href="#" @click.prevent="createSong" class="btn btn-primary"><icon :icon="['fas', 'plus-square']" /> Add Document</a>
        <div v-if="documents.length > 0">
            <home-page-document-summary v-for="document in documents" :document="document" :key="document.id"></home-page-document-summary>
        </div>
    </div>
</template>
<script>
    import HomePageDocumentSummary from '@/components/home-page-document-summary';

    export default {
        data() {
            return {
                documents: []
            }
        },
        components: {
            HomePageDocumentSummary
        },
        methods: {
            createSong() {
                this.$router.push({ name: 'DocumentCreate' });
            },
            async loadDocuments() {
                try {
                    var result = await this.$http.get('document')
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
