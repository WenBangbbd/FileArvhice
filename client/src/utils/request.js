import axois from 'axios'

const request = axois.create({
    baseURL: '/api',
    timeout: 6000,
})
request.interceptors.response.use(response=>response.data);
request.interceptors.request.use(req=>req);
export default request