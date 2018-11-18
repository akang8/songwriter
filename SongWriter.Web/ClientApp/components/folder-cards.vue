<template>
    <div>
        <p v-for="folder in folders">
            <router-link :to="{ name: 'Folder', params: { id: folder.id, name: folder.name }}">
                <icon :icon="['fas', 'folder']" />
                {{folder.name}}
            </router-link>
        </p>
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
