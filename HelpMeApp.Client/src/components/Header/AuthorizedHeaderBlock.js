import React from "react";
import NavDropdown from "react-bootstrap/NavDropdown";
import routingUrl from "../../constants/routingUrl";
import { logout } from "../../services/authorizationServices";

const AuthorizedHeaderBlock = () => {
    return <NavDropdown title="Profile">
        <NavDropdown.Item href={routingUrl.pathToProfile}>
            View profile info
        </NavDropdown.Item>
        <NavDropdown.Divider />
        <NavDropdown.Item onClick={logout}>
            Logout
        </NavDropdown.Item>
    </NavDropdown>;
};

export default AuthorizedHeaderBlock;
