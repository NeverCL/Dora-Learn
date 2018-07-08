import dva from 'dva';
import createHistory from 'history/createBrowserHistory';
import './global.css';

// 0. prepare
var root = document.createElement('div');
root.id = 'root';
document.body.insertBefore(root, document.body.firstChild);

// 1. Initialize
const app = dva({
    history: createHistory()
});

// 2. Plugins
// app.use({});

// 3. Model
// app.model(require('./models/example').default);

// 4. Router
app.router(require('./router').default);

// 5. Start
app.start('#root');