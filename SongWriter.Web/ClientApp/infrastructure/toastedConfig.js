import Vue from 'vue'
import Toasted from 'vue-toasted';

Vue.use(Toasted);

// Lets Register a Global Error Notification Toast.
Vue.toasted.register('actionSuccess',
    (payload) => {
        if (payload.message) {
            return payload.message;
        }

        return 'Success'
    },
    {
        duration: 5000,
        action: {
            text: 'OK',
            onClick: (e, toastObject) => {
                toastObject.goAway(0);
        }
    }
})
