import React, { useState, useEffect } from "react";
import photo1 from "../../media/defaultAdvertPhoto.jpg";
import "bootstrap/dist/css/bootstrap.css";
import { Link, useNavigate } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import "./UserProfile.css";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
import { baseRequestWithToken } from "../../services/axiosServices";

const UserProfile = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [userData, setGeneralData] = useState({});
    const [userHelpsCounter, setUserHelpsCounter] = useState({});

    const [alertMessage, setAlertMessage] = useState("");
    const [successMessage, setSuccessMessage] = useState("");

    const navigate = useNavigate();
    const NavigateToUserProfile = () => {
        navigate(routingUrl.pathToLoginPage);
    };

    const retrieveUserHelpsCounter = async () => {
        await baseRequestWithToken
            .get("/profile/count-user-helps")
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setUserHelpsCounter(data);
            });
    };

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
                localStorage.token = "";
                NavigateToUserProfile();
            } else {
                console.log(response.data.success);
                setAlertMessage(response.data.message);
                handleClose();
            }
        });
    };

    useEffect(() => {
        retrieveUserData();
        retrieveUserHelpsCounter();
    }, []);
    return (
        <div className="container">
            <div className="row mt-3 col-sm-12 ">
                <div className="col-lg-4">
                    {" "}
                    <img
                        src={photo1}
                        style={{ width: "18rem" }}
                        className="border border-dark"
                    ></img>
                </div>
                <div className="col-lg-8">
                    <div className="row">
                        <div className="col-lg-3 col-md-3">
                            <h1>{userData.name ?? "No data"}</h1>
                        </div>

                        <div className="col-lg-4 col-md-4 mx-1">
                            <h1>{userData.surname ?? "No data"}</h1>
                        </div>
                    </div>
                    <div className="row">
                        <h2>{userData.phoneNumber ?? "No data"}</h2>
                    </div>
                    <h5 className="mt-2">
                        helped {userHelpsCounter.userHelpsCount ?? "No data"}{" "}
                        times
                    </h5>
                    <div className="row mt-2">
                        <div className="col-lg-4 col-sm-12 my-2 col-md-12">
                            <Link to={routingUrl.pathToUsersAdverts}>
                                <button className="btn btn-warning btn-block btn-lg w-100 ">
                                    View users adverts
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4 col-sm-12 my-2">
                            <Link to={routingUrl.pathToProfileModification}>
                                <button className="btn btn-warning btn-lg w-100">
                                    Modify profile data
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4 col-sm-12 mt-2">
                            <button
                                className="btn btn-warning btn-lg w-100"
                                onClick={handleShow}
                            >
                                Delete an account
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="row mt-4 bg-light col-sm-12 mt-3">
                <div className="col-xs-12">
                    <p className="mt-4">
                        {userData.info ?? "No data provided"}
                    </p>
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

export default UserProfile;
