
import React from "react";
import axios from "axios";
import { Layout, Descriptions, Badge } from "antd";
import "antd/dist/antd.css";
import SideBar from "../components/SideBar";
import PageHeader from "../components/PageHeader";
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
                console.log(project);
            });
    }

   

    render() {
        const { project } = this.state;
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <PageHeader />

                <Layout>

                    <Layout>
                        <SideBar />
                        <Content>
                            <div>
                                <Descriptions title="Project Details" layout="vertical" bordered>
                                <Descriptions.Item label="Title">{this.state.project.title}</Descriptions.Item>
                                    <Descriptions.Item label="Requirements">
                                        <ReactMarkdown>
                                        {this.state.project.requirements}
                                        </ReactMarkdown>
                                    </Descriptions.Item>
                                <Descriptions.Item label="Design" >
                                        {this.state.project.design}
                                    </Descriptions.Item>
                                    <Descriptions.Item label="Completion Date" span="3">
                                        {this.state.project.completionDate}
                                    </Descriptions.Item>
                                    <Descriptions.Item label="Languages">
                                        {Array.isArray(project.languages) && project.languages.map(language => (
                                            <li key={language.id}>
                                                {language.name}
                                            </li>
                                            ))}
                                    </Descriptions.Item>
                                    <Descriptions.Item label="Platforms">
                                        {Array.isArray(project.platforms) && project.platforms.map(platform => (
                                            <li key={platform.id}>
                                                {platform.name}
                                            </li>
                                        ))}
                                    </Descriptions.Item>
                                    <Descriptions.Item label="Technologies">
                                        {Array.isArray(project.technologies) && project.technologies.map(technology => (
                                            <li key={technology.id}>
                                                {technology.name}
                                            </li>
                                        ))}
                                    </Descriptions.Item>
                              </Descriptions>,
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