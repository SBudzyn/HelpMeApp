import React from "react";
import PropTypes from "prop-types";
import "./UserProfilePages.css";
import OtherUserProfile from "../../components/Profile/OtherUserProfile";

const UserProfilePages = () => {
    return (
        <div className="page centered-form">
            <OtherUserProfile />
        </div>
    );
};

UserProfilePages.propTypes = {
    component: PropTypes.element
};

export default UserProfilePages;
