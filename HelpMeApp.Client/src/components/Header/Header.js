import React from "react";
import { Container, Offcanvas } from "react-bootstrap";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import routingUrl from "../../constants/routingUrl";
import HeaderAuthorizationChecker from "./HeaderAuthorizationChecker";
import "bootstrap/dist/css/bootstrap.css";

const Header = () => {
    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href={routingUrl.pathToHomePage}>
                    Help Me App
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="offcanvasNavbar-expand-sm" />
                <Navbar.Offcanvas
                    id="basic-navbar-nav"
                    aria-labelledby={"offcanvasNavbarLabel-expand-sm"}
                    placement="end"
                >
                    <Offcanvas.Header closeButton>
                        <Offcanvas.Title>Tittle</Offcanvas.Title>
                    </Offcanvas.Header>
                    <Offcanvas.Body>
                        <Nav>
                            <Nav.Link
                                href={routingUrl.pathToGiveHelpBoard + "/1"}
                            >
                                Help someone
                            </Nav.Link>
                            <Nav.Link
                                href={routingUrl.pathToGetHelpBoard + "/1"}
                            >
                                Get help
                            </Nav.Link>
                        </Nav>
                        <Nav className="ms-auto">
                            <HeaderAuthorizationChecker />
                        </Nav>
                    </Offcanvas.Body>
                </Navbar.Offcanvas>
                {/* <Navbar.Collapse className="justify-content-end">
                    <Nav>
                        // <Nav.Link href={routingUrl.pathToChat}>Chat</Nav.Link>
                        // <Nav.Link href={routingUrl.pathToProfile}>
                        //    Profile
                        // </Nav.Link>
                    </Nav>
                </Navbar.Collapse> */}
            </Container>
        </Navbar>
    );
};

export default Header;
