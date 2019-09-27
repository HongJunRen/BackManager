import request from '@/utils/request';

export const login = (username: string, password: string) =>
    request({
        url: '/Login/login',
        method: 'post',
        data: {
            username,
            password,
        },
    });

export const getInfo = (ID: number) =>
    request({
        url: '/user/getuser',
        method: 'get',
        params: { ID },
    });

export const logout = () =>
    request({
        url: '/user/logout',
        method: 'post',
    });
