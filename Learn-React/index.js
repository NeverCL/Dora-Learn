var express = require('express');
var ejs = require('ejs');

var app = express();

app.use(express.static('dist'));

app.engine('.html', ejs.__express);
app.set('view engine', 'html');
app.set('views', "dist");
app.use(function (req, res) {
    res.render('index.html');
});

app.listen(8080);