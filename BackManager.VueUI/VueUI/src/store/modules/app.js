import { __decorate } from "tslib";
import Cookies from 'js-cookie';
import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators';
import store from '@/store';
export var DeviceType;
(function (DeviceType) {
    DeviceType[DeviceType["Mobile"] = 0] = "Mobile";
    DeviceType[DeviceType["Desktop"] = 1] = "Desktop";
})(DeviceType || (DeviceType = {}));
let App = class App extends VuexModule {
    constructor() {
        super(...arguments);
        this.sidebar = {
            opened: Cookies.get('sidebarStatus') !== 'closed',
            withoutAnimation: false,
        };
        this.device = DeviceType.Desktop;
    }
    ToggleSideBar(withoutAnimation) {
        return withoutAnimation;
    }
    CloseSideBar(withoutAnimation) {
        return withoutAnimation;
    }
    ToggleDevice(device) {
        return device;
    }
    TOGGLE_SIDEBAR(withoutAnimation) {
        if (this.sidebar.opened) {
            Cookies.set('sidebarStatus', 'closed');
        }
        else {
            Cookies.set('sidebarStatus', 'opened');
        }
        this.sidebar.opened = !this.sidebar.opened;
        this.sidebar.withoutAnimation = withoutAnimation;
    }
    CLOSE_SIDEBAR(withoutAnimation) {
        Cookies.set('sidebarStatus', 'closed');
        this.sidebar.opened = false;
        this.sidebar.withoutAnimation = withoutAnimation;
    }
    TOGGLE_DEVICE(device) {
        this.device = device;
    }
};
__decorate([
    Action({ commit: 'TOGGLE_SIDEBAR' })
], App.prototype, "ToggleSideBar", null);
__decorate([
    Action({ commit: 'CLOSE_SIDEBAR' })
], App.prototype, "CloseSideBar", null);
__decorate([
    Action({ commit: 'TOGGLE_DEVICE' })
], App.prototype, "ToggleDevice", null);
__decorate([
    Mutation
], App.prototype, "TOGGLE_SIDEBAR", null);
__decorate([
    Mutation
], App.prototype, "CLOSE_SIDEBAR", null);
__decorate([
    Mutation
], App.prototype, "TOGGLE_DEVICE", null);
App = __decorate([
    Module({ dynamic: true, store, name: 'app' })
], App);
export const AppModule = getModule(App);
//# sourceMappingURL=app.js.map