import React from "react";
import { Layout, Menu } from 'antd';

const { Sider } = Layout;

class SideBar extends React.Component {
    render() {
        return (
            <>
                <Sider style={{ color: "black", backgroundColor: "lightblue" }}>
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