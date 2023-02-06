import React from "react";
import PropTypes from "prop-types";
import "./AuthorizationPage.css";
import Background from "../../components/Background/Background";

const AuthorizationPage = ({ component: AuthorizationForm }) => {
    return (
        <div>
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
    component: PropTypes.component
};

export default AuthorizationPage;
