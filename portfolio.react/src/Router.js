import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import ProjectDetailsPage from "./pages/ProjectDetailsPage";
import HomePage from "./pages/HomePage";
import ProjectListPage from "./pages/ProjectListPage";
import qs from "query-string";
import LanguagePage from "./pages/LanguagePage";
import PlatformPage from "./pages/PlatformPage";
import TechnologyPage from "./pages/TechnologyPage";

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
                        path="/languages"
                        exact
                        render={() => {
                            return this.renderRoute(<LanguagePage />);
                        }}
                    />
                    <Route
                        path="/platforms"
                        exact
                        render={() => {
                            return this.renderRoute(<PlatformPage />);
                        }}
                    />
                    <Route
                        path="/technologies"
                        exact
                        render={() => {
                            return this.renderRoute(<TechnologyPage />);
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
