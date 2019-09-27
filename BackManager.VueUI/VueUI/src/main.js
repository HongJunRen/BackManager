import Vue from 'vue';
import 'normalize.css';
import ElementUI from 'element-ui';
import '@/styles/index.scss';
import '@/permission';
import './icons';
import App from '@/App.vue';
import store from '@/store';
import router from '@/router';
import '@/registerServiceWorker';
Vue.use(ElementUI);
Vue.config.productionTip = false;
new Vue({
    router,
    store,
    render: (h) => h(App),
}).$mount('#app');
//# sourceMappingURL=main.js.map