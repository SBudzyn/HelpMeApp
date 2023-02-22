import React from "react";
import PropTypes from "prop-types";
import "./UserProfilePages.css";
import routingUrl from "../../constants/routingUrl";
import { Navigate } from "react-router-dom";
import { checkToken } from "../../services/authorizationServices";

const UserProfilePages = ({ component: ProfileForms }) => {
    return checkToken()
        ? (
            <div className="page centered-form">
                <ProfileForms />
            </div>
        )
        : (
            <Navigate to={routingUrl.pathToLoginPage} />
        );
};

UserProfilePages.propTypes = {
    component: PropTypes.element
};

export default UserProfilePages;
