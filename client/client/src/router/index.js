import { createRouter, createWebHistory } from 'vue-router'
import routes from '../config/router.config'



const router=createRouter({
    history: createWebHistory(),
    routes
})
export default router;