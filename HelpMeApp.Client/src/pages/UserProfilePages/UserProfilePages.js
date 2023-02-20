import React from "react";
import PropTypes from "prop-types";
import "./UserProfilePages.css";
// import routingUrl from "../../constants/routingUrl";
// import { Navigate } from "react-router-dom";

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
