import { useState, React, useEffect } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import "bootstrap/dist/css/bootstrap.css";
import PropTypes from "prop-types";
import { baseRequestWithToken, baseRequest } from "../../services/axiosServices";
import AdvertForms from "../../validation/AdvertForms";
import { useParams } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";

const AdvertUpdateForm = () => {
    const params = useParams();

    const [generalData, setGeneralData] = useState({});

    const retrieveGeneralData = async () => {
        await baseRequest
            .get("/adverts/general-data")
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setGeneralData(data);
            });
    };

    useEffect(() => {
        retrieveGeneralData();
    }, []);

    const [alertMessage, setAlertMessage] = useState("");

    const submitDataModification = async (values) => {
        const UpdateAdvertData = {
            header: values.header,
            info: values.info,
            categoryId: values.category,
            termsId: values.terms,
            helpTypeId: values.helpType,
            location: values.location
        };

        setAlertMessage("");
        await baseRequestWithToken
            .put(
                `adverts/update/${params.advertId}`,
                UpdateAdvertData
            )
            .then(() => {
                location.href = `${routingUrl.pathToAdvert}/${params.advertId}`;
            })
            .catch(() => {
                setAlertMessage(
                    "An error occured while modifing data"
                );
            });
    }

    return (
        <>
            <Formik
                initialValues={{
                    helpType: "",
                    header: "",
                    info: "",
                    location: "",
                    category: "",
                    terms: "",
                    advertId: ""
                }}
                onSubmit={async (values) => {
                    submitDataModification(values);
                }}
                validationSchema={AdvertForms}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="creation-form">
                            <h1 className="text-center mt-3 mb-3">
                                Update your advert
                            </h1>

                            <div className="mx-auto w-75">
                                <label htmlFor="helpType" className="mb-5">
                                    Help type
                                </label>
                                <br />
                                <Field
                                    as="select"
                                    name="helpType"
                                    className="up form-select drop-down border-primary"
                                >
                                    <option defaultValue={null}>
                                        Choose help type
                                    </option>
                                    {Object.keys(
                                        generalData?.helpTypes ?? []
                                    ).map((key) => (
                                        <option
                                            key={key}
                                            value={key}
                                            className="dropdown-item border"
                                            aria-label="form-select-lg"
                                        >
                                            {generalData.helpTypes[key]}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="helpType" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="header" className="mb-5">
                                    Header
                                </label>
                                <Field
                                    as="textarea"
                                    name="header"
                                    placeholder="Short info about your advert"
                                    className="up form-control border-primary"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="header" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="info" className="mb-5">
                                    Information
                                </label>
                                <Field
                                    as="textarea"
                                    name="info"
                                    placeholder="Some detailed info about your advert"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="info" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="info" className="mb-5">
                                    Location
                                </label>
                                <Field
                                    id="location"
                                    name="location"
                                    placeholder="Your city"
                                    type="text"
                                    className="up form-control border-primary"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="location" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="category" className="mb-5">
                                    Category
                                </label>
                                <br />

                                <Field
                                    as="select"
                                    name="category"
                                    className="up form-select drop-down border-primary"
                                >
                                    <option defaultValue={null}>
                                        Choose category
                                    </option>
                                    {Object.keys(
                                        generalData?.categories ?? []
                                    ).map((key) => (
                                        <option
                                            key={key}
                                            value={key}
                                            className="dropdown-item border"
                                            aria-label="form-select-lg"
                                        >
                                            {generalData.categories[key]}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="category" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="terms" className="mb-5">
                                    Terms
                                </label>
                                <br />
                                <Field
                                    as="select"
                                    name="terms"
                                    className="up form-select drop-down border-primary"
                                >
                                    <option defaultValue={null}>
                                        Choose terms
                                    </option>
                                    {Object.keys(generalData?.terms ?? []).map(
                                        (key) => (
                                            <option
                                                key={key}
                                                value={key}
                                                className="dropdown-item border"
                                                aria-label="form-select-lg"
                                            >
                                                {generalData.terms[key]}
                                            </option>
                                        )
                                    )}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="terms" />
                                </div>
                            </div>

                            <div className="error-message">{alertMessage}</div>
                            <br />
                            <button
                                className="mx-auto w-75 mt-4 mb-5 submit-button horizontal-center btn btn-primary mb-3"
                                type="submit"
                                disabled={!(dirty && isValid)}
                            >
                                Create
                            </button>
                        </Form>
                    );
                }}
            </Formik>
        </>
    );
};

AdvertUpdateForm.propTypes = {
    advertId: PropTypes.string
};

export default AdvertUpdateForm;
