import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import ProjectDetailsPage from "./pages/ProjectDetailsPage";
import HomePage from "./pages/HomePage";
import ProjectListPage from "./pages/ProjectListPage";
import qs from "query-string";

export default class CustomRouter extends React.Component {
    renderRoute = (component) => {
        let route = component;
        return route;
    };

    render() {
        let page = (
            <Router>
                <Switch>
                    <Route
                        path="/"
                        exact
                        render={() => {
                            return this.renderRoute(<HomePage />);
                        }}
                    />
                    <Route
                        path="/projectlist"
                        exact
                        render={() => {
                            return this.renderRoute(<ProjectListPage />);
                        }}
                    />
                    <Route
                        path="/project"
                        render={() => {
                            let slug = qs.parse(window.location.search, {
                                ignoreQueryPrefix: true,
                            }).slug;
                            return this.renderRoute(<ProjectDetailsPage slug={slug} />);
                        }}
                    />
                </Switch>
            </Router>
        );
        return page;
    }
}
