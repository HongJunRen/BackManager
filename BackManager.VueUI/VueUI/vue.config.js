const path = require('path')
function resolve(dir) {
    return path.join(__dirname, '.', dir)
}

module.exports = {
    publicPath: '/',
    pwa: {
        name: 'vue3-admin'
    },
    devServer: {
        port: 8088, // 端口号
        //host: '127.0.0.1',
        https: false, // https:{type:Boolean}
        proxy: {
            '/api': {
                target: 'https://localhost:44302',
                changeOrigin: true,//是否允许跨越
                secure: false
            }

        },  // 配置多个代理

    },
    chainWebpack: config => {
        config.module
            .rule('svg')
            .exclude.add(resolve('src/icons'))
            .end()

        config.module
            .rule('icons')
            .test(/\.svg$/)
            .include.add(resolve('src/icons'))
            .end()
            .use('svg-sprite-loader')
            .loader('svg-sprite-loader')
            .options({
                symbolId: 'icon-[name]'
            })
    }
}
