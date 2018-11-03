<template>
    <div class="card-deck">
        <div class="card" v-for="folder in folders">
            <div class="card-body">
                <router-link :to="{ name: 'Folder', params: { id: folder.id, name: folder.name }}">
                    <icon :icon="['fas', 'folder']" />
                    {{folder.name}}
                </router-link>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        props: {
            folders: {
                type: Array,
                required: true
            }
        }
    }
</script>
