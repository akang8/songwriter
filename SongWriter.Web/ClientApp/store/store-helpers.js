import { mapState, mapGetters, mapActions } from 'vuex'

export default {
    lookupsMixin: {
        computed: {
            ...mapGetters('lookups', ['getItem'])
        },
        methods: {
            ...mapActions('lookups', ['updateFolders'])
        }
    }
}
