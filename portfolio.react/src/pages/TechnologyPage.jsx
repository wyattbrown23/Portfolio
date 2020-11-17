import React from "react";
import axios from "axios";
import { Layout } from "antd";
import "antd/dist/antd.css";
import SideBar from "../components/SideBar";
import PageHeader from "../components/PageHeader";

const { Content } = Layout;


class TechnologyPage extends React.Component {
    state = {
        technologies: [],
    };

    componentDidMount() {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/category/GetTechnologiesWithProjects`)
            .then((res) => {
                const technologies = res.data;
                this.setState({ technologies });
                console.log(technologies);
            });
    }

    render() {
        const { technologies } = this.state;
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <PageHeader />
                <Layout>
                    <SideBar />
                    <Content>
                        <div>
                            <h1>
                                Technologies
                            </h1>
                        </div>
                        <div>
                            {Array.isArray(technologies) && technologies.map(object => (
                                <li key={object.id}>
                                    {object.name}
                                    {object.projects.map(project => (
                                        <ul key={project.id}>
                                            <a href={["/project?slug="] + project.slug}>{project.title}</a>
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

export default TechnologyPage;