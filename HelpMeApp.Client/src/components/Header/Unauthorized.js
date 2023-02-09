import React from "react";
import { Nav } from "react-bootstrap";

const Unauthorized = () => {
    return (
        <>
            <Nav.Link href="/login">login</Nav.Link>
            <Nav.Link href="/signup">sign up</Nav.Link>
        </>
    );
};

export default Unauthorized;
