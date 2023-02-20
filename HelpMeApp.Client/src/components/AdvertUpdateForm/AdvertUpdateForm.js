import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
// import ProfileDataModificationScheme from "../../validation/ProfileDataModification";
import { handleUploadFiles } from "../../services/filesUploading";
// import { baseRequestWithToken } from "../../services/axiosServices";
import "bootstrap/dist/css/bootstrap.css";
import classNames from "classnames";
import advertCreation from "../../constants/advertCreation";
import PropTypes from "prop-types";
import { baseRequestWithToken } from "../../services/axiosServices";

const AdvertUpdateForm = (params) => {
    const [uploadedFiles, setUploadedFiles] = useState([]);
    const [fileLimit, setFileLimit] = useState(false);

    const uploadBtnClass = classNames({
        btn: true,
        disabled: fileLimit,
        "btn-primary": true
    });

    const handleFileEvent = async (e) => {
        const chosenFiles = e.target.files;
        handleUploadFiles(
            chosenFiles,
            setUploadedFiles,
            setFileLimit,
            uploadedFiles
        );
    };

    const [alertMessage, setAlertMessage] = useState("");
    // const [successMessage, setSuccessMessage] = useState("");

    // const [userData, setUserData] = useState({});
    /* useEffect(() => {
        retrieveUserData();
    }, []); */

    const submitDataModification = async (values) => {
        const UpdateAdvertData = {
            helpType: values.helpType,
            header: values.header,
            info: values.info,
            location: values.location,
            category: values.category,
            terms: values.terms,
            files: uploadedFiles
        };

        setAlertMessage("");
        // setSuccessMessage("");
        await baseRequestWithToken
            .put(
                "adverts/update/20",
                UpdateAdvertData
            )
            .then(Response)
            .catch(() => {
                setAlertMessage(
                    "An error occured while modifing data"
                );
            });
    }
    /*
    const retrieveUserData = async () => {
        await baseRequestWithToken
            .get("/profile/get-my-info")
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setUserData(data);
            });
    }; */
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
                    console.log(values.helpType);
                    console.log(values.location);
                    console.log(values.terms);
                    values.advertId = params.userId;
                    submitDataModification(values);
                }}
                // validationSchema={AdvertCreation}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="creation-form">
                            <h1 className="text-center mt-3 mb-3">
                                Create new advert
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
                                    {advertCreation.helpTypes.map(
                                        (helpType) => (
                                            <option
                                                key={helpType}
                                                value={helpType}
                                            >
                                                {helpType}
                                            </option>
                                        )
                                    )}
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
                                    {advertCreation.categories.map(
                                        (category) => (
                                            <option
                                                key={category}
                                                value={category}
                                            >
                                                {category}
                                            </option>
                                        )
                                    )}
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
                                    {advertCreation.terms.map((terms) => (
                                        <option key={terms} value={terms}>
                                            {terms}
                                        </option>
                                    ))}
                                </Field>
                                <div className="error-message">
                                    <ErrorMessage name="terms" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <input
                                    id="fileUpload"
                                    type="file"
                                    accept=".jpg, .jpeg, .png"
                                    onChange={(e) => handleFileEvent(e)}
                                    disabled={fileLimit}
                                    className="d-none"
                                />

                                <label htmlFor="fileUpload">
                                    <a className={uploadBtnClass}>
                                        Upload Photos
                                    </a>
                                </label>

                                <div className="uploaded-files-list">
                                    {uploadedFiles.map((file) => (
                                        <div key={file.name}>{file.name}</div>
                                    ))}
                                </div>
                                <div className="error-message">{alertMessage}</div>
                            </div>
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
