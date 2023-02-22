import React from "react";
import PropTypes from "prop-types";
import "./AdvertCreationPage.css";
import AdvertCreationForm from "../../components/AdvertCreationForm/AdvertCreationForm";

const AdvertCreationPage = () => {
    return (
        <div className="centered-form mb-5 mx-4">
            <AdvertCreationForm />
        </div>
    );
};

AdvertCreationPage.propTypes = {
    component: PropTypes.element
};

export default AdvertCreationPage;
