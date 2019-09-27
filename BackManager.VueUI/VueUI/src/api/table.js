import request from '@/utils/request';
export const getList = (params) => request({
    url: '/table/list',
    method: 'get',
    params,
});
//# sourceMappingURL=table.js.map