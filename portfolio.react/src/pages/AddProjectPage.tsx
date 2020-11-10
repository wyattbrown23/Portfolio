import * as React from "react";
import axios from "axios";
import { Table } from "antd";
import "antd/dist/antd.css";
import AddProjectForm from "../AddProjectForm";


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

class AddProjectPage extends React.Component {
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
            <div>
                <h1>Projects</h1>
                <div>
                    <Table dataSource={this.state.persons} columns={columns} />
                </div>
                <AddProjectForm />
            </div>
        );
    }
}


export default AddProjectPage;