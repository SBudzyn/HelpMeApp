import React from "react";
import Authorized from "./Authorized";
import Unauthorized from "./Unauthorized";
import { checkToken } from "../../services/authorizationServices";

const HeaderAuthorizationChecker = () => {
    if (checkToken()) {
        return <Authorized />;
    } else {
        return <Unauthorized />;
    }
};

export default HeaderAuthorizationChecker;
