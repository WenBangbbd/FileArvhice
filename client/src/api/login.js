import  requet  from '../utils/request';

export function sendVertifyCode(params) {
    return requet({
        url: `api/Login/VertifyCode/${params}`,
        method: 'get',
    })
}