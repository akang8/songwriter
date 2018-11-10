<template>
    <span v-if="!creating">
        <a href="#" @click.prevent="creating = true">Create Folder</a>
    </span>
    <span v-else>
        New Folder: <input type="text" class="form-control" v-model="newFolderName" />
        <a href="#" @click.prevent="createFolder">OK</a>
        <a href="#" @click.prevent="creating = false">Cancel</a>
    </span>
</template>
<script>
    export default {
        data() {
            return {
                creating: false,
                newFolderName: ''
            }
        },
        methods: {
            async createFolder() {
                try {
                    var result = await this.$http.post('folder', { id: 0, name: this.newFolderName })
                    if (result && result.data) {
                        this.$emit("created", result.data)
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }

                this.creating = false;
            }
        }
    }
</script>
