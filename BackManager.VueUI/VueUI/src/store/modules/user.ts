import { VuexModule, Module, MutationAction, Mutation, Action, getModule } from 'vuex-module-decorators';
import { login, logout, getInfo } from '@/api/login';
import { getUser, setUser, getToken, setToken, removeToken } from '@/utils/auth';
import store from '@/store';

export interface IUserState {
    ID: number,
    Token: string;
    LoginName: string;
    NiceName: string;
}

@Module({ dynamic: true, store, name: 'user' })
class User extends VuexModule implements IUserState {
    public ID = 0;
    public Token = '';
    public LoginName = '';
    public NiceName = '';

    @Action
    public async Login(userInfo: { username: string, password: string }) {
        debugger
        const username = userInfo.username.trim();
        const { data } = await login(username, userInfo.password);
        setToken(data.token);
        setUser({})
        this.SET_TOKEN(data.token)
    }




    @Mutation
    private SET_TOKEN(token: string) {
        this.Token = token;
    }
}

export const UserModule = getModule(User);
