import React from "react";
import { Nav } from "react-bootstrap";

const UnauthorizedHeaderBlock = () => {
    return (
        <>
            <Nav.Link href="/login">login</Nav.Link>
            <Nav.Link href="/signup">sign up</Nav.Link>
        </>
    );
};

export default UnauthorizedHeaderBlock;
