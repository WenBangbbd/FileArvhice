import axois from 'axios'

const request = axois.create({
    baseURL: '/api',
    timeout: 6000,
    headers: {'Content-Type': 'application/json'},
})
request.interceptors.response.use(response=>{
   return response.data
});
request.interceptors.request.use(req=>{
   return req;
});
export default request