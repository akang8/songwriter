<template>
    <div>
        <p>
            <a href="#" @click.prevent="createSong" class="btn btn-primary"><icon :icon="['fas', 'plus-square']" /> Add Document</a>
        </p>

        <div class="row">
            <div class="col-8">
                <h3 class="mt-4">Contents</h3>
                <document-cards :documents="documents"></document-cards>
            </div>
            <div class="col-4">
                <div v-if="folders.length > 0">
                    <h3>Folders</h3>
                    <folder-cards :folders="folders"></folder-cards>
                </div>
                <p v-else class="alert alert-info">
                    No documents, click "Add Document" above to get started.
                </p>
            </div>
        </div>

    </div>
</template>
<script>
    import DocumentCards from '@/components/document-cards';
    import FolderCards from '@/components/folder-cards';

    export default {
        data() {
            return {
                documents: []
            }
        },
        props: ['id'],
        components: {
            FolderCards,
            DocumentCards
        },
        methods: {
            createSong() {
                this.$router.push({ name: 'DocumentCreate', params: { folderId: this.id } });
            },
            async loadDocuments() {
                try {
                    var result = await this.$http.get(`document/folder/${this.id}`)
                    if (result) {
                        this.documents = result.data;
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
            }
        },
        computed: {
            folders() {
                return this.$store.state.lookups.folders;
            }
        },
        async created() {
            // Fire and forget, no need for await here?
            this.loadDocuments();
        }
    }
</script>
