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
            component:()=>import('../views/user/LoginForm'),
        },
        {
            name: 'register',
            path:'/user/register',
            component:()=>import('../views/user/RegisterForm')
        },
        {
            name:'vertifyEmail',
            path:'/user/vertifyEmail/:email',
            // path:'/user/vertifyEmail',
            component:()=>import('../views/user/VertifyEmail'),
            props:true
        }
    ]
}]

export default createRouter({
    history:createWebHistory(),
    routes
})