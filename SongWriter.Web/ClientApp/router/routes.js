import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import DocumentCreate from 'components/document-create'
import DocumentEdit from 'components/document-edit'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'fetch-data', path: '/fetch-data', component: FetchData, display: 'Fetch data', icon: 'list' },
  { name: 'DocumentCreate', path: '/document/create', component: DocumentCreate, display: 'Document - Create', icon: 'plus' },
  { name: 'DocumentEdit', path: '/document/edit/:id', component: DocumentEdit, display: 'Document - Edit', icon: 'edit', props: true }
]
