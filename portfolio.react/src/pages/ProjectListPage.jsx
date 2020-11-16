import React from "react";
import axios from "axios";
import { Button, Layout, Table } from "antd";
import "antd/dist/antd.css";
import AddProjectModal from "../components/AddProjectModal";
import SideBar from "../components/SideBar";
import { render } from "@testing-library/react";

const { Header, Content } = Layout;
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
    {
        title: "Action",
        dataIndex: "slug",
        key: "slug",
        render: (slug) => <a href={["/project?slug="] + slug}>View</a>
    },
];

class ProjectListPage extends React.Component {
    state = {
        projects: [],
        addModalVisability: false,
        isAdmin: false
    };

    componentDidMount() {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/project`)
            .then((res) => {
                const projects = res.data;
                this.setState({ projects });
            });
        this.setState({ isAdmin: false })
    }

    AddProject() {
        //open modal to add project info
        this.setState({ addModalVisability: true });
    }

    HandleOk() {
        this.setState({ addModalVisability: false })
    }
    HandleCancel() {
        this.setState({ addModalVisability: false })
    }

    render() {
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <Header />
                <Layout>
                    <SideBar />
                    <Content>
                        <h1>Projects</h1>
                        <Button
                            onClick={() => this.AddProject()}
                            disabled={this.state.isAdmin}>
                            Add New
                        </Button>
                        <div>
                            <Table dataSource={this.state.projects} columns={columns} />
                        </div>
                        <AddProjectModal
                            visible={this.state.addModalVisability}
                            onOk={() => this.HandleOk()}
                            onCancel={() => this.HandleCancel()} />
                    </Content>
                </Layout>
            </Layout>
        );
    }
}

export default ProjectListPage;