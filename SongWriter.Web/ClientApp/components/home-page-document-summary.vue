<template>
    <div class="card" style="width: 20rem;">
        <div class="card-body">
            <h4 class="card-title">{{document.name}}</h4>
            <p class="card-text">{{document.summaryText}}</p>
            <router-link :to="{ name: 'DocumentEdit', params: { id: document.id }}" class="btn btn-primary">Edit</router-link>
        </div>
    </div>
</template>
<script>
    export default {
        props: {
            document: {
                type: Object,
                required: true
            }
        }
    }
</script>
