<template>
    <div>
        <h1>Create Song</h1>
        <div class="form-group">
            <label>Name</label>
            <input type="text" class="form-control" v-model="model.name" />
        </div>
        <div class="form-group">
            <label>Text</label>
            <textarea class="form-control" v-model="model.text"></textarea>
        </div>
        <p>
            <a href="#" @click.prevent="createSong" class="btn btn-primary">Create Song</a>
        </p>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                model: {
                    name: '',
                    text: ''
                }
            }
        },
        methods: {
            async createSong() {
                try {
                    var result = await this.$http.post('document', this.model)
                    if (result && result.data) {
                        this.$router.push({
                            name: 'DocumentEdit',
                            params: {
                                id: result.data
                            }
                        });
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
            }
        }
    }
</script>

<style>
</style>
