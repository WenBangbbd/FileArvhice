import requet from '../utils/request';

export function sendVertifyCode(params) {
    return requet({
        url: `api/Login/VertifyCode/${params}`,
        method: 'get',
    })
}

export function register(user) {
    return requet({
        url: `api/Access/User`,
        method: 'post',
        data: user
    })
}

export async function emailVertify(email) {
    return await requet({
        url: `api/Access/User/VertifyEmail/`,
        method: 'post',
        data:email
    })
}

export async function isUserNameInvalid(name) {
    let isValid = false;
    let value = await requet({
        url: `api/Access/User/${name}`,
        method: 'get',
    });
    if (value) {
        console.log(value);
        isValid = false;
    }
    else {
        isValid = true;
    }
    return isValid;
}