import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as Yup from "yup";

const AdvertCreationForm = () => {
    const [setShow] = useState(false);

    const [photo, setPhoto] = useState(null);

    const handleClose = () => setShow(false);

    const helpTypes = ["Need help", "Can help"];
    const locations = ["Kharkiv", "Lviv", "Kyiv", "Odesa", "Dnipro"];
    const categories = ["Food", "Clothes", "Evacuation", "Repairs"];
    const terms = ["1", "2-3", "5-7", "10-20", "21-30"];

    const AdvertCreationSchema = Yup.object().shape({
        helpType: Yup.string()
            .oneOf(
                helpTypes,
                "Invalid help type"
            )
            .required("Required!"),
        header: Yup.string()
            .max(45, "Must be 45 characters or less")
            .required("Required!"),
        info: Yup.string()
            .max(200, "Must be 200 characters or less")
            .required("Required!"),
        location: Yup.string()
            .oneOf(
                locations,
                "Invalid location"
            )
            .required("Required!"),
        category: Yup.string()
            .oneOf(
                categories,
                "Invalid category"
            )
            .required("Required!"),
        terms: Yup.string()
            .oneOf(
                terms,
                "Invalid terms"
            )
            .required("Required!")
    });

    return (
        <>
            <h1>Create new advert</h1>
            <Formik
                initialValues={{
                    helpType: "",
                    info: "",
                    location: "",
                    category: "",
                    terms: ""
                }}
                onSubmit={async (values) => {
                    const allData = {
                        helpType: values.helpType,
                        info: values.info,
                        location: values.location,
                        category: values.category,
                        terms: values.terms,
                        photo: photo.name
                    };
                    alert(JSON.stringify(allData));
                    handleClose();
                }}
                validationSchema={AdvertCreationSchema}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="form">
                            <div className="mb-4 row">
                                <label
                                    htmlFor="helpType"
                                    className="col-sm-5 col-form-label"
                                >
                                    Help Type
                                </label>
                                <br />

                                <Field
                                    as="select"
                                    name="helpType"
                                    className="form-select mb-3 drop-down border border-primary">
                                    <option defaultValue={null}>Choose help type</option>
                                    {helpTypes.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="helpType" />
                                </div>
                            </div>

                            <div className="mb-2 row">
                                <label
                                    htmlFor="header"
                                    className="col-sm-2 col-form-label up"
                                >
                                    Header
                                </label>
                                <Field
                                    id="header"
                                    name="header"
                                    placeholder="Short info about your advert"
                                    type="text"
                                    className="form-control up"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="header" />
                                </div>
                            </div>

                            <div className="mb-2 row">
                                <label
                                    htmlFor="info"
                                    className="col-sm-2 col-form-label up"
                                >
                                    Information
                                </label>
                                <Field
                                    id="info"
                                    name="info"
                                    placeholder="Some detailed info about your advert"
                                    type="text"
                                    className="form-control up"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="info" />
                                </div>
                            </div>

                            <div className="mb-3 row">
                                <label
                                    htmlFor="location"
                                    className="col-sm-2 col-form-label"
                                >
                                    Location
                                </label>
                                <br />

                                <Field
                                    as="select"
                                    name="location"
                                    className="form-select mb-3 drop-down border border-primary">
                                    <option defaultValue={null}>Choose help type</option>
                                    {locations.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="location" />
                                </div>
                            </div>

                            <div className="mb-2 row">
                                <label
                                    htmlFor="category"
                                    className="col-sm-2 col-form-label"
                                >
                                    Category
                                </label>
                                <br />

                                <Field
                                    as="select"
                                    name="category"
                                    className="form-select mb-3 drop-down border border-primary">
                                    <option defaultValue={null}>Choose help type</option>
                                    {categories.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="category" />
                                </div>
                            </div>

                            <div className="mb-2 row">
                                <label
                                    htmlFor="terms"
                                    className="col-sm-2 col-form-label"
                                >
                                    Terms
                                </label>
                                <br />

                                <Field
                                    as="select"
                                    name="terms"
                                    className="form-select mb-3 drop-down border border-primary">
                                    <option defaultValue={null}>Choose help type</option>
                                    {terms.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="terms" />
                                </div>
                            </div>

                            <div className="mb-3 bm-3">
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
                                    onChange={(event) => {
                                        setPhoto(
                                            event.currentTarget.files[0]
                                        );
                                    }}
                                ></input>
                            </div>
                            <br />
                            <button
                                className="submit-button horizontal-center btn btn-primary mb-3 up"
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

export default AdvertCreationForm;
