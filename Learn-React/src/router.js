import React from 'react';
import { LocaleProvider } from 'antd';
import { Router, Route, Switch, Link } from 'dva/router';

let zhCN = null;
if (process.env.NODE_ENV === 'production') {
    // let antd = require('antd'); // 生产环境
    zhCN = antd.locales.zh_CN;
    console.log('production')
} else {
    zhCN = require('antd/lib/locale-provider/zh_CN'); // 开发环境
    console.log('develop')
}

function RouterConfig({ history }) {
    return (
        <LocaleProvider locale={zhCN}>
            <Router history={history}>
                <Switch>
                    <Route path='/' component={() => (<div>hello <Link to="/app">app</Link></div>)} exact />
                    <Route path='/app' component={() => (<div>App Page <Link to="/world">world</Link></div>)} />
                    <Route path='/world' component={() => (<div>World Page  <Link to="/app">app</Link></div>)} />
                </Switch>
            </Router>
        </LocaleProvider>
    );
}

export default RouterConfig;