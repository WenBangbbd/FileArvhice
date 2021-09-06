import {createRouter,createWebHistory} from 'vue-router'

const routes=[{
    path:'/user',
    component:()=>import('../layout/UserLayout')
}]

export default createRouter({
    history:createWebHistory(),
    routes
})