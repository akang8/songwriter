<template>
    <div v-if="model">
        <div v-if="!isFullScreen">
            <router-link :to="{ name: 'Home' }">Home</router-link>
            <h2>
                Edit Document
            </h2>
            <div class="form-group">
                <label>Name</label>
                <input type="text" class="form-control" v-model="model.name" />
            </div>
            <div class="form-group">
                <a href="#" @click.prevent="isFullScreen = true" class="float-right"><icon :icon="['fas', 'expand-arrows-alt']"></icon> Full Screen View</a>
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
                <a href="#" @click.prevent="saveDocument" class="btn btn-primary">Save</a>
            </p>
        </div>
        <div v-else>
            <p>
                <strong>
                    {{model.name}}
                </strong>
                <span class="float-right">
                    <a href="#" @click.prevent="saveDocument" class="btn btn-primary btn-sm">Save</a>
                    &nbsp;
                    <a href="#" @click.prevent="isFullScreen = false"><icon :icon="['fas', 'compress']"></icon> Normal View</a>
                </span>
            </p>
            <text-editor-full-screen v-model="model.text"></text-editor-full-screen>
        </div>
    </div>
</template>

<script>
    import FolderSelect from '@/components/folder-select';
    import TextEditor from '@/components/text-editor';
    import TextEditorFullScreen from '@/components/text-editor-full-screen';

    export default {
        data() {
            return {
                model: {
                },
                isFullScreen: false
            }
        },
        props: ['id'],
        components: {
            FolderSelect,
            TextEditor,
            TextEditorFullScreen
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
                    var result = await this.$http.put('document', this.model)
                    if (result) {
                        this.$toasted.global.actionSuccess({ message: 'Document saved' });
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }

            },
            fullScreen() {
                this.isFullScreen = true;
            }
        },
        async created() {
            await this.loadDocument();
        }
    }
</script>
