import React from "react";
import PropTypes from "prop-types";
import "./UserProfilePages.css";

const UserProfilePages = ({ component: ProfileForms }) => {
    return (
        <div className="page centered-form">
            <ProfileForms />
        </div>
    );
};

UserProfilePages.propTypes = {
    component: PropTypes.element
};

export default UserProfilePages;
