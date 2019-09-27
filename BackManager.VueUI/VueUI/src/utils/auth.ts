import Cookies from 'js-cookie';

const TokenKey = 'vue_admin_template_token';
const UserKey = 'vue_admin_template_user';


export const getUser: any = () => {
    let userString: string | undefined = Cookies.get(UserKey)
    if (userString) {


        let us = String(userString);
        return JSON.parse(us)
    }
    return {};
};

export const setUser = (User: any) => Cookies.set(UserKey, JSON.stringify(User));



export const getToken = () => Cookies.get(TokenKey);

export const setToken = (token: string) => Cookies.set(TokenKey, token);

export const removeToken = () => Cookies.remove(TokenKey);
