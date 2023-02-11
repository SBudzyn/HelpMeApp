import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import baseRequest from "../../services/axiosServices";
import Modal from "react-bootstrap/Modal";
import AuthorizationValidationSchema from "./validation/AuthorizationValidationSchema";
import RegistrationValidationSchema from "./validation/RegistrationValidationSchema";
import "bootstrap/dist/css/bootstrap.css";
import "./AuthorizationForms.css";

const RegistrationForm = () => {
    const [alertMessage, setAlertMessage] = useState("");
    const [successMessage, setSuccessMessage] = useState("");
    const [registrationData, setRegistrationData] = useState({
        email: "",
        password: ""
    });
    const [show, setShow] = useState(false);
    // const [photo, setPhoto] = useState(null);

    const handleClose = () => setShow(false);
    const handleShow = () => {
        setShow(true);
        setAlertMessage("");
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
                validationSchema={AuthorizationValidationSchema}
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
                            validationSchema={RegistrationValidationSchema}
                            onSubmit={async (values) => {
                                const allData = {
                                    email: registrationData.email,
                                    password: registrationData.password,
                                    name: values.name,
                                    surname: values.surname,
                                    phoneNumber: values.phoneNumber,
                                    info: values.info
                                    // photo: photo.name
                                };

                                const formData = new FormData();

                                formData.append("email", allData.email);
                                formData.append("password", allData.password);
                                formData.append("name", allData.name);
                                formData.append("surname", allData.surname);
                                formData.append(
                                    "phoneNumber",
                                    allData.phoneNumber
                                );
                                formData.append("info", allData.info);

                                await baseRequest
                                    .post("/authentication/register", formData)
                                    .then((response) => {
                                        console.log(response);
                                        if (response.data.isSuccessful) {
                                            handleClose();
                                            setSuccessMessage(
                                                "Success! Now you can login"
                                            );
                                        } else {
                                            setAlertMessage("error");
                                        }
                                    })
                                    .catch((error) => {
                                        console.log(error);
                                        setAlertMessage(
                                            "Unsuccessful registration"
                                        );
                                    });
                            }}
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
                                        id="Surname"
                                        name="Surname"
                                        placeholder="Bobkin"
                                        type="text"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className="error-message">
                                    <ErrorMessage name="Surname" />
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
                                            onChange={(event) => {
                                                // setPhoto(
                                                //     event.currentTarget.files[0]
                                                // );
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
