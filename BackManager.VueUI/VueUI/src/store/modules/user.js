import { __decorate } from "tslib";
import { VuexModule, Module, MutationAction, Mutation, Action, getModule } from 'vuex-module-decorators';
import { login, logout, getInfo } from '@/api/login';
import { getToken, setToken, removeToken } from '@/utils/auth';
import store from '@/store';
let User = class User extends VuexModule {
    constructor() {
        super(...arguments);
        this.token = '';
        this.name = '';
        this.avatar = '';
        this.roles = [];
    }
    async Login(userInfo) {
        const username = userInfo.username.trim();
        const { data } = await login(username, userInfo.password);
        setToken(data.token);
        return data.token;
    }
    async FedLogOut() {
        removeToken();
        return '';
    }
    async GetInfo() {
        const token = getToken();
        if (token === undefined) {
            throw Error('GetInfo: token is undefined!');
        }
        const { data } = await getInfo(token);
        if (data.roles && data.roles.length > 0) {
            return {
                roles: data.roles,
                name: data.name,
                avatar: data.avatar,
            };
        }
        else {
            throw Error('GetInfo: roles must be a non-null array!');
        }
    }
    async LogOut() {
        if (getToken() === undefined) {
            throw Error('LogOut: token is undefined!');
        }
        await logout();
        removeToken();
        return {
            token: '',
            roles: [],
        };
    }
    SET_TOKEN(token) {
        this.token = token;
    }
};
__decorate([
    Action({ commit: 'SET_TOKEN' })
], User.prototype, "Login", null);
__decorate([
    Action({ commit: 'SET_TOKEN' })
], User.prototype, "FedLogOut", null);
//__decorate([
//    MutationAction({ mutate: ['roles', 'name', 'avatar'] })
//], User.prototype, "GetInfo", null);
__decorate([
    MutationAction({ mutate: ['token', 'roles'] })
], User.prototype, "LogOut", null);
__decorate([
    Mutation
], User.prototype, "SET_TOKEN", null);
User = __decorate([
    Module({ dynamic: true, store, name: 'user' })
], User);
export const UserModule = getModule(User);
//# sourceMappingURL=user.js.map