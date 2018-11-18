<template>
    <div v-if="model">
        <router-link :to="{ name: 'Home' }">Home</router-link>
        <h2>
            Edit Document
        </h2>
        <div class="form-group">
            <label>Name</label>
            <input type="text" class="form-control" v-model="model.name" />
        </div>
        <div class="form-group">
            <label>Text</label>
            <text-editor v-model="model.text"></text-editor>
        </div>
        <folder-select v-model="model.folderId"></folder-select>
        <p>
            <a href="#" @click.prevent="saveDocument" class="btn btn-primary">Save</a>
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
                }
            }
        },
        props: ['id'],
        components: {
            FolderSelect,
            TextEditor
        },
        methods: {
            async loadDocument() {
                try {
                    var result = await this.$http.get(`document/${this.id}`)
                    if (result) {
                        this.model = result.data;
                        this.code = this.model.text;
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

            }
        },
        async created() {
            await this.loadDocument();
        }
    }
</script>
