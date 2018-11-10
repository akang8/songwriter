import Vue from 'vue'
import Vuex from 'vuex'
import lookups from './lookups'

Vue.use(Vuex)

const modules = {
    lookups
}

const store = new Vuex.Store({
  modules,
  strict: process.env.NODE_ENV !== 'production'
})

for (const moduleName of Object.keys(modules)) {
    if (modules[moduleName].actions.init) {
        store.dispatch(`${moduleName}/init`);
    }
}

export default store
