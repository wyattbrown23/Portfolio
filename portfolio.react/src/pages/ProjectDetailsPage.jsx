
import React from "react";
import axios from "axios";
import { Button, Table, Layout } from "antd";
import "antd/dist/antd.css";
import SideBar from "../components/SideBar";
import ReactMarkdown from 'react-markdown'

const { Header, Content, Footer } = Layout;

class ProjectDetailsPage extends React.Component {
    state = {
        project: [],
    };

    componentDidMount() {
        this.GetProjectBySlug(this.props.slug);
    }

    GetProjectBySlug = async (slug) => {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/project/projectdetails/${slug}`)
            .then((res) => {
                const project = res.data;
                this.setState({ project });
            });
    }

   

    render() {
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <Header />

                <Layout>

                    <Layout>
                        <SideBar />
                        <Content>
                            <div>
                                <label>{this.state.project.title}</label>
                                <ReactMarkdown>
                                {this.state.project.requirements}
                                </ReactMarkdown>
                                <label>{this.state.project.design}</label>
                            </div>
                        </Content>
                        <Footer />
                    </Layout>
                </Layout>
            </Layout>
        );
    }
}

export default ProjectDetailsPage;