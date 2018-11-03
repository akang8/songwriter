import http from '@/infrastructure/httpHelper';
import _ from 'lodash';
import Vue from 'vue';

export default {
    namespaced: true,
    state: {
        folders: [],
        loaded: false
    },
    getters: {
        getItem: state => (lookupName, id) => {
            if (state[lookupName]) {
                var lookupItem = _.chain(state[lookupName])
                    .filter(item => { return item.id == id })
                    .head()
                    .value;

                if (lookupItem) {
                    return lookupItem;
                }

                return null                
            }
        },
        isLoaded: state => () => {
            return state.loaded;
        }
    },
    mutations: {
        SET_DATA_ITEM(state, { lookupName, lookup }) {
            state[lookupName] = lookup;
        },
        SET_LOADED(state) {
            state.loaded = true;
        }
    },
    actions: {
        init({ commit, dispatch }) {
            return dispatch('updateFolders')
                .then(result => {
                    commit("SET_LOADED");

                    return result;
                });
        },
        updateFolders({ commit, state }) {
            return http.get("Lookup/Folders")
                .then(response => {
                    commit("SET_DATA_ITEM", { lookupName: 'folders', lookup: response.data })
                })
        }
    }
}
