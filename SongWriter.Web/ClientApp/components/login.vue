<template>
    <div class="col-3">
        <div class="form-group">
            <label for="exampleInputEmail1">User Name</label>
            <input type="email" class="form-control" v-model="model.userName">
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <input type="password" class="form-control" v-model="model.password">
        </div>
        <button type="submit" class="btn btn-primary" @click="loginUser">Submit</button>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                model: {
                    userName: '',
                    password: ''
                }
            }
        },
        methods: {
            async loginUser() {
                // HACK: login right away from now
                try {
                    var result = await this.$http.post('/api/account', this.model)
                    if (result) {
                        console.log(result);
                    }
                } catch (err) {
                    window.alert(err)
                    console.log(err)
                }
            }
        }
    }
</script>
