# 说明

## 常见问题

1. React-Router 如何实现url路由 而不是hash

两种方式：

    1. html 引擎

    ```js
    var ejs = require('ejs');
    app.engine('.html', ejs.__express);
    app.set('view engine', 'html');
    app.set('views', "dist");
    app.use(function (req, res) {
        res.render('index.html');
    });
    ```

    1. 默认路由

    ```js
    app.use(function (req, res) {
        res.sendFile('index.html', { root: 'dist' });
    });
    ```