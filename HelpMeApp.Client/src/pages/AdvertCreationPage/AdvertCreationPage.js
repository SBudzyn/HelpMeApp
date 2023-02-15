import React from "react";
import PropTypes from "prop-types";
import "./AdvertCreationPage.css";
import AdvertCreationForm from "../../components/AdvertCreationForm/AdvertCreationForm";
import { Navigate } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import { checkToken } from "../../services/authorizationServices";

const AdvertCreationPage = () => {
    return (
        <div>
            {checkToken()
                ? (
                    <></>
                )
                : (
                    <Navigate to={routingUrl.pathToLoginPage} />
                )}
            <div className="centered-form mb-5 mx-4">
                <AdvertCreationForm />
            </div>
        </div>
    );
};

AdvertCreationPage.propTypes = {
    component: PropTypes.element
};

export default AdvertCreationPage;
