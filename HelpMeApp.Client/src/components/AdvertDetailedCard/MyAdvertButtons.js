import { React, useState } from "react";
import { Button, Modal } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { checkToken } from "../../services/authorizationServices";
import "bootstrap/dist/css/bootstrap.css";
import PropTypes from "prop-types";
import { baseRequest } from "../../services/axiosServices";
import routingUrl from "../../constants/routingUrl";

const MyAdvertButtons = (props) => {
    const navigate = useNavigate();

    const [alertReportMessage, setAlertResponseMessage] = useState("");

    const deleteAdvert = async () => {
        await baseRequest
            .delete(`/adverts/delete/${props.advertId}`, {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.token
                }
            })
            .then((response) => {
                navigate("/provide-help-board/1");
            })
            .catch(() => {
                setAlertResponseMessage("Could not delete the advert");
            });
    };

    const [show, setShow] = useState(false);

    const handleClose = () => {
        setShow(false);
        setAlertResponseMessage("");
    };
    const handleShow = () => {
        checkToken() ? setShow(true) : navigate("/login");
    };

    return (
        <div className="row mt-auto actions-block">
            <Link to={routingUrl.pathToAdvertUpdateForm + `/${props.advertId}`} className="btn btn-primary col-xs-12 col-md-4 action-button">
                Edit
            </Link>
            <Button
                className="btn btn-danger col-xs-12 col-md-4 action-button"
                onClick={handleShow}
            >
                Delete
            </Button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header>
                    <Modal.Title>
                        Are you sure you want to delete this advert?
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body className="container">
                    <div className="row d-flex justify-content-around">
                        <Button
                            className="col-md-4 btn btn-primary"
                            onClick={handleClose}
                        >
                            No
                        </Button>
                        <Button
                            className="col-md-4 btn btn-danger"
                            onClick={deleteAdvert}
                        >
                            Yes, I`m sure
                        </Button>
                    </div>
                    <div className="error-message mt-3 text-center">
                        {alertReportMessage}
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    );
};

MyAdvertButtons.propTypes = {
    advertId: PropTypes.string
};

export default MyAdvertButtons;
