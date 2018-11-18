import Vue from 'vue'
import http from '@/infrastructure/httpHelper'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from '@/components/app-root'
import { FontAwesomeIcon } from './icons'

import '@/infrastructure/codeMirrorConfig';
import '@/infrastructure/toastedConfig';

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = http

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
