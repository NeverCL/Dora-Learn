import React from 'react'
import { render } from 'react-dom';
import { LocaleProvider, Row, Col, DatePicker } from 'antd';
import './index.css';
import Login from './Login';
import RouterDemo from './Router';
import Banner from './Anim/Banner.jsx';

let zhCN = null;
if (process.env.NODE_ENV === 'production') {
    // let antd = require('antd'); // 生产环境
    zhCN = antd.locales.zh_CN;
    console.log('production')
} else {
    zhCN = require('antd/lib/locale-provider/zh_CN'); // 开发环境
    console.log('develop')
}

var root = document.createElement('div');
root.id = 'root';
document.body.insertBefore(root, document.body.firstChild);

render(<LocaleProvider locale={zhCN}>
    <Banner />
</LocaleProvider>, root);