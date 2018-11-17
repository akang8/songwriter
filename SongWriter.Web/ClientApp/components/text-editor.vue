<template>
    <div>
        <codemirror v-model="wrappedValue" :options="editorOptions"></codemirror>
        <p>
            <span class="float-right">
                <span class="text-secondary">
                    <icon :icon="['fas', 'info-circle']" />
                </span>
                <span class="cm-annotation">!comment</span>
                <span class="cm-chord">@chord</span>
                <span class="cm-lyric">#lyric</span>
            </span>
        </p>
    </div>
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

    .cm-marker-annotation {
        color: #c3a0a0;
    }

    .cm-marker-chord {
        color: #88b388;
    }

    .cm-marker-lyric {
        color: #b2b2d2;
    }

    .cm-start-annotation {
        color: #b22222;
        background-color: #c3a0a0
    }

    .cm-start-chord {
        color: #0f860f;
        background-color: #88b388;
    }

    .cm-start-lyric {
        color: #00008b;
        background-color: #b2b2d2;
    }


    .cm-annotation {
        color: #b22222
    }

    .cm-chord {
        color: #0f860f
    }

    .cm-lyric {
        color: #00008b
    }
</style>
