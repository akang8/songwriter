<template>
    <codemirror v-model="wrappedValue" :options="editorOptions"></codemirror>
</template>
<script>
    import { codemirror } from 'vue-codemirror'
    import 'codemirror/lib/codemirror.css'
    import CodeMirror from 'codemirror';


    export default {
        components: {
            codemirror
        },
        props: ['value'],
        data() {
            return {
                editorOptions: {
                    // codemirror options
                    tabSize: 4,
                    mode: 'songwriter',
                    lineNumbers: false,
                    line: true
                }
            }
        },
        computed: {
            wrappedValue: {
                get() {
                    return this.value;
                },
                set(newValue) {
                    this.$emit('input', newValue);
                }
            }
        }
    }
</script>


<style>

    div.CodeMirror {
        border: 1px solid #ccc;
        border-radius: 5px;
    }

    .cm-annotation {
        color: darkred
    }

    .cm-chord {
        color: seagreen
    }

    .cm-lyric {
        color: darkblue
    }
</style>
