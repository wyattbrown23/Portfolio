import * as React from "react";
import { Button, Layout, Table } from "antd";
import SideBar from "../components/SideBar";
import PageHeader from "../components/PageHeader";
import "antd/dist/antd.css";

const { Header, Content } = Layout;

class HomePage extends React.Component {
    render() {
        return (
            <Layout style={{ minHeight: "100vh" }}>
                <PageHeader />
                <Layout>
                    <SideBar />
                    <Content>
                        <h3>Welcome To My Portfolio!</h3>
                    </Content>
                </Layout>
            </Layout>
        
            );
    }
}
export default HomePage;