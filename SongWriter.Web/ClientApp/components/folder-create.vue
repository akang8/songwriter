<template>
    <span v-if="!creating">
        <a href="#" @click.prevent="creating = true">Create Folder</a>
    </span>
    <span v-else class="form-inline">
        New Folder: <input type="text" class="form-control" v-model="newFolderName" />
        <a href="#" class="btn btn-primary btn-sm" @click.prevent="createFolder">OK</a>
        <a href="#" class="btn btn-warning btn-sm" @click.prevent="creating = false">Cancel</a>
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
