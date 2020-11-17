import React from "react";
import axios from "axios";
import { Layout } from "antd";
import "antd/dist/antd.css";
import SideBar from "../components/SideBar";
import PageHeader from "../components/PageHeader";

const { Content } = Layout;


class LanguagePage extends React.Component {
    state = {
        languages: [],
    };

    componentDidMount() {
        axios
            .get(`https://myportfolio-wyattb.herokuapp.com/api/category/GetLangaugesWithProjects`)
            .then((res) => {
                const languages = res.data;
                this.setState({ languages });
                console.log(languages);
            });
    }

    render() {
        const { languages } = this.state;
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <PageHeader />
                <Layout>
                    <SideBar />
                    <Content>
                        <div>
                            <h1>
                                Languages
                            </h1>
                        </div>
                        <div>
                            {Array.isArray(languages) && languages.map(object => (
                                <li key={object.id}>
                                    {object.name}
                                    {object.projects.map(project => (
                                        <ul key={project.slug}>
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

export default LanguagePage;