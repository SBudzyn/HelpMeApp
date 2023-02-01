import React from "react";
import { Container } from "react-bootstrap";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";

import routingUrl from "../../constants/routingUrl";

const Header = () => {
    return (
        <Navbar bg="light" expand="lg" >
            <Container>
                <Navbar.Brand href={routingUrl.pathToHomePage}>Help Me App</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href={routingUrl.pathToGiveHelpBoard}>Help someone</Nav.Link>
                        <Nav.Link href={routingUrl.pathToGetHelpBoard}>Get help</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
                <Navbar.Collapse className="justify-content-end">
                    <Nav>
                        <Nav.Link href={routingUrl.pathToChat}>Chat</Nav.Link>
                        <Nav.Link href={routingUrl.pathToProfile}>Profile</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default Header;
