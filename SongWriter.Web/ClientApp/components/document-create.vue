<template>
    <div>
        <router-link :to="{ name: 'Home' }">Home</router-link>
        <h2>Create Document</h2>
        <div class="form-group">
            <label>Name</label>
            <input type="text" class="form-control" v-model="model.name" />
        </div>
        <div class="form-group">
            <label>Text</label>
            <text-editor v-model="model.text"></text-editor>
        </div>
        <div class="form-row">
            <div class="form-group col-lg-5 col-md-7 col-sm-12">
                <label>Folder</label>
                <folder-select v-model="model.folderId"></folder-select>
            </div>
        </div>
        <p>
            <a href="#" @click.prevent="createSong" class="btn btn-primary">Create Song</a>
        </p>
    </div>
</template>

<script>
    import FolderSelect from '@/components/folder-select';
    import TextEditor from '@/components/text-editor';

    export default {
        data() {
            return {
                model: {
                    name: '',
                    text: '',
                    folderId: 0
                }
            }
        },
        props: ['folderId'],
        components: {
            FolderSelect,
            TextEditor
        },
        methods: {
            async createSong() {
                try {
                    var result = await this.$http.post('document', this.model)
                    if (result && result.data) {
                        this.$router.push({
                            name: 'DocumentEdit',
                            params: {
                                id: result.data
                            }
                        });
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
        created() {
            if (this.folderId) {
                this.model.folderId = this.folderId;
            }
        }
    }
</script>

<style>
</style>
