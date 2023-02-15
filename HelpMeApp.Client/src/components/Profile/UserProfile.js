import React, { useState } from "react";
import photo1 from "../../media/defaultAdvertPhoto.jpg";
import "bootstrap/dist/css/bootstrap.css";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import "./UserProfile.css";
// import DeleteUserConfirmation from "./DeleteUserConfirmation";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";
// import EditProfileDataForm from "./UserDataModificationForm";
const data = {
    name: "Name",
    surname: "Surname",
    phoneNumber: "+38012332144",
    photo: null,
    helpedNtimes: 2,
    info: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmodLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod"
};

const Profile = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    return (
        <div className="container">
            <div className="row mt-3">
                <div className="col-lg-4">
                    {" "}
                    <img
                        src={data?.photo ?? photo1}
                        style={{ width: "18rem" }}
                        className="border border-dark"
                    ></img>
                </div>
                <div className="col-lg-8">
                    <div className="row">
                        <div className="col-lg-2">
                            <h1>{data?.name ?? "No data"}</h1>
                        </div>

                        <div className="col-lg mx-1">
                            <h1>{data?.surname ?? "No data"}</h1>
                        </div>
                    </div>
                    <div className="row">
                        <h2>{data?.phoneNumber ?? "No data"}</h2>
                    </div>
                    <h5 className="mt-2">
                        helped {data?.helpedNtimes ?? "No data"} times
                    </h5>
                    <div className="row mt-4">
                        <div className="col-lg-4 ">
                            <Link to={routingUrl.pathToSignUpPage}>
                                <button className="btn btn-warning btn-block btn-lg">
                                    View users adverts
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4">
                            <Link to={routingUrl.pathToModifyProfileData}>
                                <button className="btn btn-warning btn-lg">
                                    Modify profile data
                                </button>
                            </Link>
                        </div>

                        <div className="col-lg-4">
                            <button
                                className="btn btn-warning btn-lg"
                                onClick={handleShow}
                            >
                                Delete an account
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="row mt-4 bg-light">
                <div className="col-xs-12">
                    <p className="mt-4">{data?.info ?? "No data provided"}</p>
                </div>
            </div>

            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Modal title</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    Are you sure you want to delete an account?
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        No
                    </Button>
                    <Button variant="primary">I am sure</Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default Profile;
