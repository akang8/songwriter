<template>
    <div>
        <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 border-bottom header">
            <h5 class="my-0 mr-md-auto font-weight-normal">
                <router-link class="navbar-brand" to="/"><icon :icon="['fas', 'music']" /> SongWriter</router-link>
            </h5>
            <nav-menu params="route: route"></nav-menu>
        </div>

        <div class="container-fluid">
            <router-view :key="$route.fullPath"></router-view>

            <footer class="pt-4 my-md-5 pt-md-5 border-top">
                <div class="row">
                    <div class="col-12 col-md">
                        <small class="d-block mb-3 text-muted">&copy; 2018</small>
                    </div>
                </div>
            </footer>
        </div>
    </div>
</template>
<script>
    import NavMenu from './nav-menu'

    export default {
        components: {
            'nav-menu': NavMenu
        },

        data() {
            return {}
        }
    }
</script>
<style>


</style>
