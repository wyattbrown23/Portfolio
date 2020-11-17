import React from "react";
import { Layout, Menu } from 'antd';
import { Auth0Provider } from "@auth0/auth0-react";
import LoginButton from "./LoginButton";
import LogoutButton from "./LogoutButton";




const {Header} = Layout;

class PageHeader extends React.Component {
    render() {
        return (
            <Header style={{ color: "black", backgroundColor: "lightblue" }}>
                <Auth0Provider
                    domain="dev-k1t7wt86.us.auth0.com"
                    clientId="pFxbAHPaBBetySztx58UeZ0ylWncZW2A"
                    redirectUri={window.location.origin}
                >
                    
                    
                    <LoginButton />
                    <LogoutButton />
                    
                </Auth0Provider>
            </Header>
        );
    }
}

export default PageHeader