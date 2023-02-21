import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import "bootstrap/dist/css/bootstrap.css";
import "./../../styles/pages.css";
import "./AdvertDetailedCard.css";
import { Carousel, Modal } from "react-bootstrap";
import defaultPhoto from "../../media/defaultAdvertPhoto.jpg";
import { baseRequest } from "../../services/axiosServices";
import getFormattedDate from "../../services/getFormattedDate";
import checkRetrievedData from "../../services/checkRetrievedData";
import { Link, useNavigate } from "react-router-dom";
import { Formik, Form, Field } from "formik";
import { checkToken } from "../../services/authorizationServices";
import routingUrl from "../../constants/routingUrl";

const photos = [defaultPhoto];

const AdvertDetailedCard = (props) => {
    const navigate = useNavigate();

    const [show, setShow] = useState(false);
    const [alertReportMessage, setAlertResponseMessage] = useState("");

    const handleClose = () => {
        setShow(false);
        setAlertResponseMessage("");
    };
    const handleShow = () => {
        checkToken() ? setShow(true) : navigate("/login");
    };

    const [data, setData] = useState({});

    const retrieveAdvertById = async (id) => {
        await baseRequest
            .get(`/adverts/${id}`)
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setData(data);
            });
    };

    useEffect(() => {
        retrieveAdvertById(props.advertId);
    }, []);
    
    return (
        <div className="container-fluid common-background">
            <div className="container pt-3">
                <div className="row">
                    <div className="col-md-12 col-lg-3 advert-short-info rounded bg-light ">
                        <Carousel>
                            {photos.map((photo) => {
                                return (
                                    <Carousel.Item key={photo.name}>
                                        <img
                                            className="d-block w-100 img-thumbnail"
                                            src={photo}
                                            alt="slide"
                                        ></img>
                                    </Carousel.Item>
                                );
                            })}
                        </Carousel>
                        <div>
                            <div className="attributes-text mt-3">{`Category: ${data?.category}`}</div>
                            <div className="attributes-text mt-2">{`Terms: ${data?.terms} days`}</div>
                            <div className="attributes-text mt-2">{`Location: ${data.location}`}</div>
                            <div className="attributes-text mt-2">{`Creation Date: ${getFormattedDate(
                                new Date(data?.creationDate ?? "1 1 1970")
                            )}`}</div>
                        </div>
                    </div>
                    <div className="col-md-12 col-lg-9">
                        <div className="container d-flex flex-column h-100">
                            <Link to={routingUrl.pathToOtherUserProfile + `/${data.creatorId}`} className="text-dec-none">
                                <div className="col-xs-12 d-flex author-link">
                                    <img
                                        src={photos}
                                        className="author-photo rounded-circle"
                                    ></img>
                                    <h6 className="author-text">
                                        {checkRetrievedData(data?.creatorName)}
                                    </h6>
                                </div>
                            </Link>
                            <div className="row">
                                <div className="col-xs-12 mb-2">
                                    <h4 className="space-around mt-3">
                                        {checkRetrievedData(data?.header)}
                                    </h4>
                                </div>
                            </div>
                            <div>
                                <p className="description-text">
                                    {checkRetrievedData(data?.info)}
                                </p>
                            </div>
                            <div className="row mt-auto actions-block">
                                <button className="btn btn-primary col-xs-12 col-md-4 action-button">
                                    Chat
                                </button>
                                <button
                                    className="btn btn-danger col-xs-12 col-md-4 action-button"
                                    onClick={handleShow}
                                >
                                    Report
                                </button>
                                <Modal show={show} onHide={handleClose}>
                                    <Modal.Header>
                                        <Modal.Title>
                                            Report this advert
                                        </Modal.Title>
                                    </Modal.Header>
                                    <Modal.Body>
                                        <div>
                                            <Formik
                                                initialValues={{
                                                    text: ""
                                                }}
                                                onSubmit={async (values) => {
                                                    await baseRequest
                                                        .post(
                                                            `/adverts/report/${props.advertId}`,
                                                            values.text,
                                                            {
                                                                headers: {
                                                                    "Content-Type":
                                                                        "application/json",
                                                                    Authorization:
                                                                        "Bearer " +
                                                                        localStorage.token
                                                                }
                                                            }
                                                        )
                                                        .then((response) => {
                                                            handleClose();
                                                        })
                                                        .catch(() => {
                                                            setAlertResponseMessage(
                                                                "Unsuccessful report"
                                                            );
                                                        });
                                                }}
                                            >
                                                <Form>
                                                    <Field
                                                        name="text"
                                                        component="textarea"
                                                        type="text"
                                                        rows="7"
                                                        className="form-control mb-4"
                                                    />
                                                    <div className="d-flex justify-content-center">
                                                        <button
                                                            type="submit"
                                                            className="btn btn-danger mb-1 modal-btn"
                                                        >
                                                            Report
                                                        </button>
                                                    </div>
                                                    <div className="error-message mt-3 text-center">
                                                        {alertReportMessage}
                                                    </div>
                                                </Form>
                                            </Formik>
                                        </div>
                                    </Modal.Body>
                                </Modal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

AdvertDetailedCard.propTypes = {
    advertId: PropTypes.string
};

export default AdvertDetailedCard;
