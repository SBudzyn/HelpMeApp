import React from "react";
import PropTypes from "prop-types";
import "./ProfilePage.css";
import Profile from "../../components/Profile/UserProfile";

const ProfilePage = () => {
    return (
        <div>
            <div className="page centered-form">
                <Profile className="form" />
            </div>
        </div>
    );
};

ProfilePage.propTypes = {
    component: PropTypes.element
};

export default ProfilePage;
