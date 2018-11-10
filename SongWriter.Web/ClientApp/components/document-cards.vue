<template>
    <div class="card-columns" v-if="documents && documents.length > 0">
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
    <div v-else class="alert alert-info">
        No documents.
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
