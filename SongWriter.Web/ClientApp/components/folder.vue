<template>
    <div class="card" style="width: 20rem;">
        <div class="card-body">
            <h4 class="card-title">{{folder.name}}</h4>
            <router-link :to="{ name: 'Folder', params: { id: folder.id, name: folder.name }}" class="btn btn-primary">View</router-link>
        </div>
    </div>
</template>
<script>
    export default {
        props: ['id', 'name']
    }
</script>
