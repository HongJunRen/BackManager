import axios from 'axios';
import { Message, MessageBox } from 'element-ui';
import { getToken } from '@/utils/auth';
import { UserModule } from '@/store/modules/user';
const baseURL = process.env.VUE_APP_API_URL
const service = axios.create({
    baseURL: baseURL,
    timeout: 5000,
});

// Request interceptors
service.interceptors.request.use(
    (config) => {

        // Add X-Token header to every request, you can add other custom headers here
        //if (UserModule.token) {
        //    config.headers['Authorization'] = 'Bearer ' + UserModule.token // 让每个请求携带自定义token 请根据实际情况自行修改
        //}
        return config;
    },
    (error) => {

        Promise.reject(error);
    },
);

// Response interceptors
service.interceptors.response.use(
    (response) => {


        // Some example codes here:
        // code == 20000: valid
        // code == 50008: invalid token
        // code == 50012: already login in other place
        // code == 50014: token expired
        // code == 60204: account or password is incorrect
        // You can change this part for your own usage.
        const res = response.data;
        if (res.code !== 20000) {
            Message({
                message: res.message,
                type: 'error',
                duration: 5 * 1000,
            });
            if (res.code === 50008 || res.code === 50012 || res.code === 50014) {
                MessageBox.confirm(
                    '你已被登出，可以取消继续留在该页面，或者重新登录',
                    '确定登出',
                    {
                        confirmButtonText: '重新登录',
                        cancelButtonText: '取消',
                        type: 'warning',
                    },
                ).then(() => {
                    UserModule.FedLogOut().then(() => {
                        location.reload();  // To prevent bugs from vue-router
                    });
                });
            }
            return Promise.reject('error with code: ' + res.code);
        } else {
            alert(1)
            return response.data;
        }
    },
    (error) => {

        Message({
            message: error.message,
            type: 'error',
            duration: 5 * 1000,
        });
        return Promise.reject(error);
    },
);

export default service;
