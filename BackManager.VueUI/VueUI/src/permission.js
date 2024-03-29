import router from './router';
import NProgress from 'nprogress';
import 'nprogress/nprogress.css';
import { Message } from 'element-ui';
import { getToken } from '@/utils/auth';
import { UserModule } from '@/store/modules/user';
NProgress.configure({ showSpinner: false });
const whiteList = ['/login'];
router.beforeEach((to, from, next) => {
    NProgress.start();
    if (getToken()) {
        if (to.path === '/login') {
            next({ path: '/' });
            NProgress.done(); // If current page is dashboard will not trigger afterEach hook, so manually handle it
        }
        else {
            if (UserModule.roles.length === 0) {
                UserModule.GetInfo().then(() => {
                    next();
                }).catch((err) => {
                    UserModule.FedLogOut().then(() => {
                        Message.error(err || 'Verification failed, please login again');
                        next({ path: '/' });
                    });
                });
            }
            else {
                next();
            }
        }
    }
    else {
        if (whiteList.indexOf(to.path) !== -1) {
            next();
        }
        else {
            next(`/login?redirect=${to.path}`); // Redirect to login page
        }
    }
});
router.afterEach(() => {
    NProgress.done();
});
//# sourceMappingURL=permission.js.map