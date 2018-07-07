var express = require('express');
var app = express();

app.use(express.static('dist'));

app.use(function (req, res) {
    res.sendFile('index.html', { root: 'dist' });
});

app.listen(8080);

console.log('listen http://localhost:8080 ok')