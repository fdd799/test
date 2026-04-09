import { createRouter, createWebHistory } from 'vue-router'
import HelloView from '../views/HelloView.vue'
import TableView from '../views/TableView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'HelloView',
            component: HelloView,
        },
        {
            path: '/table',
            name: 'TableView',
            component: TableView,
        }
    ],
})

export default router
