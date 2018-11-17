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
            <codemirror v-model="code" :options="cmOptions"></codemirror>
        </div>
        <folder-select v-model="model.folderId"></folder-select>
        <p>
            <a href="#" @click.prevent="saveDocument" class="btn btn-primary">Save</a>
        </p>
    </div>
</template>

<script>
    import FolderSelect from '@/components/folder-select';
    import { codemirror } from 'vue-codemirror'
    import 'codemirror/lib/codemirror.css'
    import CodeMirror from 'codemirror';

    export default {
        data() {
            return {
                model: {
                },
                code: '', //HACK: codemirror cant get deep property w/o error
                cmOptions: {
                    // codemirror options
                    tabSize: 4,
                    mode: 'songwriter',
                    lineNumbers: false,
                    line: true,
                }
            }
        },
        props: ['id'],
        components: {
            FolderSelect,
            codemirror
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
        watch: {
            code(newValue) {
                if (this.model) {
                    this.model.text = newValue;
                }
            }
        },
        async created() {
            await this.loadDocument();
        }
    }
</script>

<style>
    div.CodeMirror{
        border: 1px solid #ccc;
        border-radius: 5px;
    }
    .cm-annotation{
        color: darkred
    }
    .cm-chord{
        color: seagreen
    }
    .cm-lyric{
        color: darkblue
    }
</style>
