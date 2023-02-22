import React from "react";
import PropTypes from "prop-types";
import "./AdvertUpdatingPage.css";
import AdvertUpdateForm from "../../components/AdvertUpdateForm/AdvertUpdateForm";

const AdvertUpdatingPage = () => {
    return (
        <div className="centered-form mb-5 mx-4">
            <AdvertUpdateForm />
        </div>
    );
};

AdvertUpdatingPage.propTypes = {
    component: PropTypes.element
};

export default AdvertUpdatingPage;
