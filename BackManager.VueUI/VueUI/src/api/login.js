import request from '@/utils/request';
export const login = (username, password) => request({
    url: '/Login/login',
    method: 'post',
    data: {
        username,
        password,
    },
});
export const getInfo = (token) => request({
    url: '/user/info',
    method: 'get',
    params: { token },
});
export const logout = () => request({
    url: '/user/logout',
    method: 'post',
});
//# sourceMappingURL=login.js.map