<template>
    <div class="form-group">
        <label>Folder</label>
        <div v-if="!creating">
            <select v-model="selectedValue">
                <option v-for="folder in folders" v-bind:value="folder.id">
                    {{ folder.name }}
                </option>
            </select>
            <a href="#" @click.prevent="creating = true">Create Folder</a>
        </div>
        <span v-else class="form-inline">
            New Folder: <input type="text" class="form-control" v-model="newFolderName" />
            <a href="#" class="btn btn-primary btn-sm" @click.prevent="createFolder">OK</a>
            <a href="#" class="btn btn-warning btn-sm" @click.prevent="creating = false">Cancel</a>
        </span>

    </div>
</template>
<script>
    export default {
        data() {
            return {
                creating: false,
                newFolderName: ''
            }
        },
        props: ['value'],
        methods: {
            async createFolder() {
                try {
                    var result = await this.$http.post('folder', { id: 0, name: this.newFolderName })
                    if (result && result.data) {
                        // Update folders
                        await this.$store.dispatch("lookups/updateFolders");

                        // Wait for UI and set value
                        this.$nextTick(() => {
                            this.$emit("input", result.data)
                        })
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }

                this.creating = false;
            }
        },
        computed: {
            folders() {
                return this.$store.state.lookups.folders;
            },
            selectedValue: {
                get() {
                    return this.value;
                },
                set(newValue) {
                    this.$emit("input", newValue)
                }
            }
        }
    }
</script>
