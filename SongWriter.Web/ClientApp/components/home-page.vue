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
        async created() {
            await this.loginUser();
            // Fire and forget, no need for await here?
            this.loadDocuments();
        },
        methods: {
            createSong() {
                this.$router.push({ name: 'DocumentCreate' });
            },
            async loginUser() {
                // HACK: login write away from now
                try {
                    var result = await this.$http.post('/api/account', { userName: "john", password: "john1" })
                    if (result) {
                        console.log(result);
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
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
        }
    }
</script>
