import React from "react";
import PropTypes from "prop-types";
import "./UserDataModificationPage.css";
import ModifyProfileDataForm from "../../components/Profile/UserDataModificationForm";

const ModifyProfileDataPage = () => {
    return (
        <div>
            <div className="page centered-form">
                <ModifyProfileDataForm className="form" />
            </div>
        </div>
    );
};

ModifyProfileDataPage.propTypes = {
    component: PropTypes.element
};

export default ModifyProfileDataPage;
