<template>
    <div v-if="model">
        <h1 v-once>
            {{model.name}}
        </h1>
        <div class="form-group">
            <label>Name</label>
            <input type="text" class="form-control" v-model="model.name" />
        </div>
        <div class="form-group">
            <label>Text</label>
            <textarea class="form-control" rows="10" v-model="model.text"></textarea>
        </div>
        <div class="form-group">
            <label>Folder</label>
            <select v-model="model.folderId">
                <option v-for="folder in folders" v-bind:value="folder.id">
                    {{ folder.name }}
                </option>
            </select>
            <folder-create @created="folderCreated"></folder-create>
        </div>
        <p>
            <a href="#" @click.prevent="saveDocument" class="btn btn-primary">Save</a>
        </p>
    </div>
</template>

<script>
    import FolderCreate from '@/components/folder-create';

    export default {
        data() {
            return {
                model: null
            }
        },
        props: ['id'],
        components: {
            FolderCreate
        },
        methods: {
            async loadDocument() {
                try {
                    var result = await this.$http.get(`document/${this.id}`)
                    if (result) {
                        this.model = result.data;
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
            },
            async saveDocument() {
                try {
                    var result = await this.$http.put(`document`, this.model)
                    if (result) {
                        // TODO: Change to a toastr or something
                        this.$router.push({name: 'Home'});
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }

            },
            async folderCreated(newFolderId) {
                await this.$store.dispatch("lookups/updateFolders");
                // Wait for UI to catch up
                this.$nextTick(() => {
                    // Set new value
                    this.model.folderId = newFolderId
                })
            }
        },
        async created() {
            await this.loadDocument();
        },
        computed: {
            folders() {
                return this.$store.state.lookups.folders;
            }
        }
    }
</script>

<style>
</style>
