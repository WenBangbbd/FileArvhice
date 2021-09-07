import {createRouter,createWebHistory} from 'vue-router'

const routes=[{
    path:'/user',
    redirect:'/user/login',
    hidden:true,
    component:()=>import('../layout/UserLayout'),
    children:[
        { 
            name: 'login',
            path:'/user/login',
            component:()=>import('../components/LoginForm'),
        },
        {
            name: 'register',
            path:'/user/register',
            component:()=>import('../components/RegisterForm')
        }
    ]
}]

export default createRouter({
    history:createWebHistory(),
    routes
})