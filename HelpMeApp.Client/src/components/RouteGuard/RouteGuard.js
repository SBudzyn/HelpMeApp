import React from "react";
import PropTypes from "prop-types";
import routingUrl from "../../constants/routingUrl";
import { Navigate } from "react-router-dom";

const RouteGuard = (props) => {
    function hasJWT () {
        return !!localStorage.getItem("token");
    }

    return hasJWT()
        ? (
            <props.element />
        )
        : (
            <Navigate to={routingUrl.pathToLoginPage} />
        );
};

RouteGuard.propTypes = {
    element: PropTypes.elementType
};

export default RouteGuard;
