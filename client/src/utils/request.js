import axois from 'axios'

const request = axois.create({
    baseURL: '/api',
    timeout: 1000,
})
request.interceptors.response.use(response=>response.data);
request.interceptors.request.use(request=>{
    return request;
});
export default request