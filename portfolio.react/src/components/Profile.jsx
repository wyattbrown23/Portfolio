import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

const Profile = () => {
    const { user, isAuthenticated, isLoading } = useAuth0();

    if (isLoading) {
        return <div>Loading ...</div>;
    }

    return (
        isAuthenticated && (
            <div>
                <h5>{user.name}</h5>
                <h6>{user.email}</h6>
                {console.log(user)}
            </div>
        )
    );
};

export default Profile;