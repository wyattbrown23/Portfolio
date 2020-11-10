import React, { useState } from "react"; 
import axios from "axios";
import { Table } from "antd";
import "antd/dist/antd.css";
import AddProjectForm from './AddProjectForm';
import {
    BrowserRouter as Router,
    Route,
    Switch,
    Link,
    Redirect
} from "react-router-dom";
import ProjectListPage from "./pages/ProjectListPage";
import HomePage from "./pages/HomePage";
import AddProjectPage from "./pages/AddProjectPage";

const columns = [
    {
        title: "Project",
        dataIndex: "title",
        key: "title",
    },
    {
        title: "Completion Date",
        dataIndex: "completionDate",
        key: "completionDate",
    },
];

class App extends React.Component {
    state = {
        persons: [],
        addModalVisability: false,
    };

    componentDidMount() {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/project`)
            .then((res) => {
                const persons = res.data;
                this.setState({ persons });
            });
    }

    AddProject() {
        //open modal to add project info
        this.setState({ addModalVisability: true });
    }

    render() {
        return (
            <Router>
                <Route path="/" component={HomePage} />
                <Route path="/projectlist" component={ProjectListPage} />
                <Route path="/addproject" component={AddProjectPage} />
            </Router>
            //<div>
            //    <h1>Projects</h1>
            //    <div>
            //        <Table dataSource={this.state.persons} columns={columns} />
            //    </div>
            //    <AddProjectForm />
            //</div>
        );
    }
}


export default App;