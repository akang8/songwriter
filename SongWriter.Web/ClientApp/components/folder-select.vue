<template>
    <div class="form-row">
        <div class="form-group col-md-3 col-sm-6">
            <a href="#" v-if="!isCreating" @click.prevent="isCreating = true" class="btn btn-sm btn-outline-primary float-right">Create Folder</a>
            <label>{{fieldLabel}}</label>
            <div v-if="!isCreating">
                <select class="custom-select" v-model="selectedValue">
                    <option v-for="folder in folders" v-bind:value="folder.id">
                        {{ folder.name }}
                    </option>
                </select>
            </div>
            <div v-else class="input-group">
                <input type="text" class="form-control" placeholder="New Folder Name" aria-label="New Folder Name">
                <div class="input-group-append">
                    <a href="#" class="btn btn-outline-success" @click.prevent="createFolder">OK</a>
                    <a href="#" class="btn btn-outline-secondary" @click.prevent="isCreating = false">Cancel</a>
                </div>
            </div>

        </div>

    </div>
</template>
<script>
    export default {
        data() {
            return {
                isCreating: false,
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

                this.isCreating = false;
            }
        },
        computed: {
            fieldLabel() {
                if (this.isCreating) {
                    return "Choose New Folder"
                }
                else {
                    return "Folder"
                }
            },
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
