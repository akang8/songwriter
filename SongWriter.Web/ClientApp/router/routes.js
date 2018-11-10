import HomePage from '@/components/home-page'
import DocumentCreate from '@/components/document-create'
import DocumentEdit from '@/components/document-edit'
import FolderContent from '@/components/folder-content'

export const routes = [
    { name: 'Home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
    { name: 'DocumentCreate', path: '/document/create/:folderId', component: DocumentCreate, display: 'Add Document', icon: 'plus-square', props: true },
    { name: 'DocumentEdit', path: '/document/edit/:id', component: DocumentEdit, display: 'Document - Edit', icon: 'edit', props: true, meta: { hideFromMenu: true } },
    { name: 'Folder', path: '/folder/:name/:id', component: FolderContent, display: 'Home', icon: 'folder', props: true, meta: { hideFromMenu: true } },
]
