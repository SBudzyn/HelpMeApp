import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import baseRequest from "../../services/axiosServices";
import Modal from "react-bootstrap/Modal";
import Authorization from "../../validation/Authorization";
import Registration from "../../validation/Registration";
import "bootstrap/dist/css/bootstrap.css";
import "./AuthorizationForms.css";
import { convertToBase64 } from "../../services/convertors.js";

const RegistrationForm = () => {
    const [alertMessage, setAlertMessage] = useState("");
    const [successMessage, setSuccessMessage] = useState("");
    const [registrationData, setRegistrationData] = useState({
        email: "",
        password: ""
    });
    const [photo, setPhoto] = useState("");

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => {
        setShow(true);
        setAlertMessage("");
    };

    const submitRegistration = async (values) => {
        console.log(photo);
        const fullRegistrationData = {
            email: registrationData.email,
            password: registrationData.password,
            name: values.name,
            surname: values.surname,
            phoneNumber: values.phoneNumber,
            info: values.info,
            photo
        };
        await baseRequest
            .post("/authentication/register", fullRegistrationData)
            .then((response) => {
                if (response.data.isSuccessful) {
                    handleClose();
                    setSuccessMessage("Success! Now you can login");
                } else {
                    setAlertMessage("error");
                }
            })
            .catch(() => {
                setAlertMessage("Unsuccessful registration");
            });
    };

    return (
        <div className="auth-form">
            <div className="header-button-wrapper">
                <Link to={routingUrl.pathToLoginPage}>
                    <button className="other-form-type header-button left-button">
                        login
                    </button>
                </Link>
                <Link to={routingUrl.pathToSignUpPage}>
                    <button className="current-form-type header-button right-button">
                        registration
                    </button>
                </Link>
            </div>
            <Formik
                initialValues={{
                    email: "",
                    password: ""
                }}
                onSubmit={async (values) => {
                    setRegistrationData(values);
                    handleShow();
                }}
                validationSchema={Authorization}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="form">
                            <div className="mb-3 row">
                                <label
                                    htmlFor="email"
                                    className="col-sm-2 col-form-label up"
                                >
                                    Email
                                </label>
                                <br />

                                <Field
                                    id="email"
                                    name="email"
                                    placeholder="name@gmail.com"
                                    type="email"
                                    className="form-control up"
                                    required
                                />
                                <div className="error-message">
                                    <ErrorMessage name="email" />
                                </div>
                            </div>

                            <div className="mb-3 row">
                                <label
                                    htmlFor="password"
                                    className="col-sm-2 col-form-label up"
                                >
                                    Password
                                </label>
                                <Field
                                    id="password"
                                    name="password"
                                    type="password"
                                    className="form-control up"
                                    required
                                />
                                <div className="error-message">
                                    <ErrorMessage name="password" />
                                </div>
                            </div>
                            <br />
                            <button
                                className="submit-button horizontal-center btn btn-primary mb-3 up"
                                type="submit"
                                disabled={!(dirty && isValid)}
                            >
                                Next
                            </button>
                            <div className="success-message">
                                {successMessage}
                            </div>
                        </Form>
                    );
                }}
            </Formik>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Fill in personal data</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div>
                        <Formik
                            initialValues={{
                                name: "",
                                surname: "",
                                phoneNumber: "",
                                info: ""
                            }}
                            validationSchema={Registration}
                            onSubmit={submitRegistration}
                        >
                            <Form>
                                <div className="mb-3 row modal-group">
                                    <label
                                        htmlFor="name"
                                        className="col-sm-2 col-form-label"
                                    >
                                        Name
                                    </label>
                                    <br />

                                    <Field
                                        id="name"
                                        name="name"
                                        placeholder="John"
                                        type="text"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className="error-message">
                                    <ErrorMessage name="name" />
                                </div>
                                <div className="mb-3 row modal-group">
                                    <label
                                        htmlFor="surname"
                                        className="col-sm-2 col-form-label"
                                    >
                                        Surname
                                    </label>
                                    <br />

                                    <Field
                                        id="surname"
                                        name="surname"
                                        placeholder="Bobkin"
                                        type="text"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className="error-message">
                                    <ErrorMessage name="surname" />
                                </div>
                                <div className="mb-3 row modal-group">
                                    <label
                                        htmlFor="phoneNumber"
                                        className="col-sm-4 col-form-label"
                                    >
                                        Phone Number
                                    </label>
                                    <br />

                                    <Field
                                        id="phoneNumber"
                                        name="phoneNumber"
                                        placeholder="+380000000000"
                                        type="tel"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className="error-message">
                                    <ErrorMessage name="phoneNumber" />
                                </div>
                                <div className="mb-3 row modal-group">
                                    <label
                                        htmlFor="info"
                                        className="col-sm-2 col-form-label"
                                    >
                                        Info
                                    </label>
                                    <br />

                                    <Field
                                        id="info"
                                        name="info"
                                        placeholder="Some info about you"
                                        type="text"
                                        className="form-control"
                                    />

                                    <div className="bm-3">
                                        <br />
                                        <label
                                            htmlFor="photo"
                                            className="form-label"
                                        >
                                            Select your photo
                                        </label>
                                        <input
                                            className="form-control"
                                            type="file"
                                            id="photo"
                                            accept="image/*"
                                            onChange={async (e) => {
                                                console.log(
                                                    await convertToBase64(
                                                        e.target.files[0]
                                                    )
                                                );
                                                setPhoto(
                                                    await convertToBase64(
                                                        e.target.files[0]
                                                    )
                                                );
                                            }}
                                        ></input>
                                    </div>
                                </div>
                                <br />
                                <div className="d-flex justify-content-center">
                                    <button
                                        type="submit"
                                        className="btn btn-primary mb-1 modal-btn"
                                    >
                                        Register
                                    </button>
                                </div>
                                <div className="d-flex justify-content-center error-message mt-3">
                                    {alertMessage}
                                </div>
                            </Form>
                        </Formik>
                    </div>
                </Modal.Body>
            </Modal>
        </div>
    );
};

export default RegistrationForm;
