import React from "react";
import PropTypes from "prop-types";
import UsersAdvertsContainer from "../../components/UsersAdvertsContainer/UsersAdvertsContainer";

const UsersAdvertsPage = () => {
    return (
        <div>
            <div className="page centered-form">
                <UsersAdvertsContainer className="form" />
            </div>
        </div>
    );
};

UsersAdvertsPage.propTypes = {
    component: PropTypes.element
};

export default UsersAdvertsPage;
