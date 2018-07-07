import React from 'react';
import {
    BrowserRouter as Router,
    Route,
    Link,
    NavLink,
    Switch
} from 'react-router-dom';

export default function () {
    return (
        <Router>
            <div>
                <Route component={() => (<div>home</div>)} />
                <Switch>
                    <Route path='/' component={() => (<div>hello <Link to="/app" /></div>)} exact />
                    <Route path='/app' component={() => (<div>App Page <Link to="/world">world</Link></div>)} />
                    <Route path='/world' component={() => (<div>World Page  <Link to="/app">app</Link></div>)} />
                </Switch>
            </div>
        </Router>
    )
}