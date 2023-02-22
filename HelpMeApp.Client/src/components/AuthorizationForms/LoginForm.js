import React, { useState } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import Authorization from "../../validation/Authorization";
import "bootstrap/dist/css/bootstrap.css";
import "./AuthorizationForms.css";
import { baseRequest } from "../../services/axiosServices";

const LoginForm = () => {
    const [alertMessage, setAlertMessage] = useState("");

    return (
        <div className="auth-form">
            <div className="header-button-wrapper">
                <Link to={routingUrl.pathToLoginPage}>
                    <button className="current-form-type header-button left-button">
                        login
                    </button>
                </Link>
                <Link to={routingUrl.pathToSignUpPage}>
                    <button className="other-form-type header-button right-button">
                        registration
                    </button>
                </Link>
            </div>
            <Formik
                initialValues={{
                    email: "",
                    password: ""
                }}
                validationSchema={Authorization}
                onSubmit={async (values) => {
                    setAlertMessage("");
                    await baseRequest
                        .post("/authentication/login", values)
                        .then((response) => {
                            if (response.data.isSuccessful) {
                                localStorage.setItem(
                                    "token",
                                    response.data.token
                                );

                                localStorage.setItem(
                                    "userId",
                                    response.data.userId
                                );
                                location.href = routingUrl.pathToHomePage;
                            }
                        })
                        .catch(() => {
                            setAlertMessage("Unsuccessful login");
                        });
                }}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="form">
                            <div className="mb-3 row">
                                <label
                                    htmlFor="email"
                                    className="col-sm-2 col-form-label up label"
                                >
                                    Email
                                </label>

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
                            <div className="error-message">{alertMessage}</div>
                            <br />
                            <button
                                className="submit-button horizontal-center btn btn-primary up"
                                type="submit"
                                disabled={!(dirty && isValid)}
                            >
                                Submit
                            </button>
                        </Form>
                    );
                }}
            </Formik>
        </div>
    );
};

export default LoginForm;
