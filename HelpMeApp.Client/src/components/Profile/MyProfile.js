import React, { useState, useEffect } from "react";
import "bootstrap/dist/css/bootstrap.css";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import "./UserProfile.css";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import { baseRequestWithToken } from "../../services/axiosServices";
import { logout } from "../../services/authorizationServices";
import defaultAdvertImage from "../../media/defaultAdvertPhoto.jpg";

const MyProfile = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [userData, setGeneralData] = useState({});

    const [alertMessage, setAlertMessage] = useState("");
    const [successMessage, setSuccessMessage] = useState("");

    const retrieveUserData = async () => {
        await baseRequestWithToken
            .get("/profile/get-my-info")
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setGeneralData(data);
            });
    };

    const submitAccountDeleting = () => {
        setAlertMessage("");
        setSuccessMessage("");
        baseRequestWithToken.get("profile/delete-user").then((response) => {
            if (response.data.success) {
                logout();
            } else {
                setAlertMessage(response.data.message);
                handleClose();
            }
        });
    };

    useEffect(() => {
        retrieveUserData();
    }, []);

    return (
        <div className="container">
            <div className="row mt-3">
                <div className="col-lg-4">
                    <img
                        src={ userData.photo === "" ? (defaultAdvertImage) : (userData.photo)}
                        style={{ width: "18rem" }}
                        className="border border-dark"
                    ></img>
                </div>

                <div className="col-lg-8">
                    <div className="row">
                        <div className="col-lg-9 col-md-3 text-profile">
                            <h1 className="name-surname-profile">{userData.name ?? "No data"} {userData.surname ?? "No data"}</h1>
                        </div>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">Telephone number: <span className="user-data-profile">{userData.phoneNumber ?? "No data"}</span></h4>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">E-mail: <span className="user-data-profile">{userData.email ?? "No data"}</span></h4>
                    </div>
                    <div className="row">
                        <h4 className="text-profile">
                            Helped: <span className="user-data-profile">{userData.advertsUserCanHelp ?? "0"} times </span>
                        </h4>
                    </div>
                    <div className="row mt-2">
                        <div className="col-lg-4 col-sm-12 mt-2 col-md-12">
                            <Link to={routingUrl.pathToUsersAdverts + "/1" + `/${localStorage.userId}`}>
                                <button className="btn btn-warning btn-block btn-lg w-100 link-buttons ">
                                    View users adverts
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4 col-sm-12 mt-2">
                            <Link to={routingUrl.pathToProfileModification}>
                                <button className="btn btn-warning btn-lg w-100 link-buttons">
                                    Modify profile data
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4 col-sm-12 mt-2">
                            <button
                                className="btn btn-warning btn-lg w-100 link-buttons"
                                onClick={handleShow}
                            >
                                Delete an account
                            </button>
                        </div>
                    </div>
                    <div className="row mt-4 bg-light mt-3">
                        <div className="col-xs-12">
                            <h3 className="mt-4 info-profile">
                                {userData.info ?? "No data provided"}
                            </h3>
                        </div>
                    </div>
                </div>
            </div>

            <div className="success-message-profile">{successMessage}</div>
            <div className="error-message-profile">{alertMessage}</div>

            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Account deletion</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Are you sure you want to delete an account?
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        No
                    </Button>
                    <Button variant="primary" onClick={submitAccountDeleting}>
                        I am sure
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default MyProfile;
