

const routes=[
    {
        path:'/user',
        redirect:'/user/login',
        component:()=>import('../layout/UserLayout'),
        children:[
            {
                path:'/user/login',
                component:()=>import('../components/Login')
            }
        ]
    }
];

export default routes;