import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import Ant from 'ant-design-vue'
import  Less from 'less'
import "ant-design-vue/dist/antd.css";


createApp(App)
.use(router)
.use(Ant)
.use(Less)
.mount('#app')
