import HomePage from '@/components/home-page'
import DocumentCreate from '@/components/document-create'
import DocumentEdit from '@/components/document-edit'
import Folder from '@/components/folder'

export const routes = [
    { name: 'Home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
    { name: 'DocumentCreate', path: '/document/create', component: DocumentCreate, display: 'Add Document', icon: 'plus-square' },
    { name: 'DocumentEdit', path: '/document/edit/:id', component: DocumentEdit, display: 'Document - Edit', icon: 'edit', props: true, meta: { hideFromMenu: true } },
    { name: 'Folder', path: '/folder/:name/:id', component: HomePage, display: 'Home', icon: 'folder', props: true, meta: { hideFromMenu: true } },
]
