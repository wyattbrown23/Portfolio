import React from "react";
import { Layout, Menu } from 'antd';
import Profile from "./Profile";
import { Auth0Provider } from "@auth0/auth0-react";

const { Sider } = Layout;

class SideBar extends React.Component {
    render() {
        return (
            <>
                <Sider style={{ color: "black", backgroundColor: "lightblue" }}>
                    <Auth0Provider
                        domain="dev-k1t7wt86.us.auth0.com"
                        clientId="pFxbAHPaBBetySztx58UeZ0ylWncZW2A"
                        redirectUri={window.location.origin}
                    >
                        <Profile />
                    </Auth0Provider>
                    <Menu style={{ color: "blue", backgroundColor: "lightblue" }}>
                        <Menu.Item style={{ borderStyle: "solid" }}><a href="/" >Home</a></Menu.Item>
                        <Menu.Item style={{ borderStyle: "solid"}}><a href="/projectlist" >Project List</a></Menu.Item>
                        <Menu.Item style={{ borderStyle: "solid" }}><a href="/languages">Languages</a></Menu.Item>
                        <Menu.Item style={{ borderStyle: "solid" }}><a href="/platforms"> Platforms</a></Menu.Item>
                        <Menu.Item style={{ borderStyle: "solid" }}><a href="/technologies">Technologies</a></Menu.Item>
                    </Menu>
                </Sider>
            </>
        );
    }
}

export default SideBar