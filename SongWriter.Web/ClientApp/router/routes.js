import HomePage from '@/components/home-page'
import Login from '@/components/login'
import DocumentCreate from '@/components/document-create'
import DocumentEdit from '@/components/document-edit'

export const routes = [
    { name: 'Home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
    { name: 'Login', path: '/login', component: Login, display: 'Login', icon: 'user', meta: { hideFromMenu: true } },
    { name: 'DocumentCreate', path: '/document/create', component: DocumentCreate, display: 'Add Document', icon: 'plus-square' },
    { name: 'DocumentEdit', path: '/document/edit/:id', component: DocumentEdit, display: 'Document - Edit', icon: 'edit', props: true, meta: { hideFromMenu: true } }
]
