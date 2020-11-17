import React from "react";
import axios from "axios";
import { Layout } from "antd";
import "antd/dist/antd.css";
import SideBar from "../components/SideBar";
import PageHeader from "../components/PageHeader";

const { Content } = Layout;


class PlatformPage extends React.Component {
    state = {
        platforms: [],
    };

    componentDidMount() {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/category/GetPlatformsWithProjects`)
            .then((res) => {
                const platforms = res.data;
                this.setState({ platforms });
                console.log(platforms);
            });
    }

    render() {
        const { platforms } = this.state;
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <PageHeader />
                <Layout>
                    <SideBar />
                    <Content>
                        <div>
                            <h1>
                                Platforms
                            </h1>
                        </div>
                        <div>
                            {Array.isArray(platforms) && platforms.map(object => (
                                <li key={object.id}>
                                    {object.name}
                                    {object.projects.map(project => (
                                        <ul key={project.id}>
                                            {project.title}
                                        </ul>
                                    ))}
                                </li>
                            ))}
                        </div>
                    </Content>
                </Layout>
            </Layout>
        );
    }
}

export default PlatformPage;