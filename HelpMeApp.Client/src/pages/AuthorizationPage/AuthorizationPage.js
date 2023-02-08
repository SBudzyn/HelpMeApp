import React from "react";
import PropTypes from "prop-types";
import "./AuthorizationPage.css";
import Background from "../../components/Background/Background";
import { Navigate } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";

const AuthorizationPage = ({ component: AuthorizationForm }) => {
    return (
        <div>
            {localStorage.getItem("token")
                ? (
                    <Navigate to={routingUrl.pathToHomePage} />
                )
                : (
                    <></>
                )}
            <div>
                <Background />
            </div>
            <div className="page centered-form">
                <AuthorizationForm className="form" />
            </div>
        </div>
    );
};

AuthorizationPage.propTypes = {
    component: PropTypes.element
};

export default AuthorizationPage;
