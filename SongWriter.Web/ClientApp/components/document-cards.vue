<template>
    <div class="card-columns">
        <div class="card" v-for="document in documents">
            <div class="card-header">
                {{document.name}}
            </div>
            <div class="card-body">
                <p class="card-text">{{document.summaryText}}</p>
                <router-link :to="{ name: 'DocumentEdit', params: { id: document.id }}" class="btn btn-primary">Edit</router-link>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        props: {
            documents: {
                type: Array,
                required: true
            }
        }
    }
</script>
