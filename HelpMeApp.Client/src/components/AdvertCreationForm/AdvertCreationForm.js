import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import "./AdvertCreationForm.css";
import advertCreationConsts from "../../constants/advertCreationConsts";
import AdvertCreationValidationSchema from "./AdvertCreationValidationSchema.js";

const AdvertCreationForm = () => {
    const [setShow] = useState(false);

    const handleClose = () => setShow(false);

    const [uploadedFiles, setUploadedFiles] = useState([]);
    const [fileLimit, setFileLimit] = useState(false);

    var classNames = require("classnames");
    var uploadBtnClass = classNames({
        btn: true,
        disabled: fileLimit,
        "btn-primary": true
    });

    const handleUploadFiles = async (files) => {
        const uploaded = [...uploadedFiles];
        let limitExceeded = false;
        for (const file of files) {
            if (uploaded.findIndex((f) => f.name === file.name) === -1) {
                const base64 = await convertToBase64(file);
                uploaded.push({ name: file.name, base64: base64 });
                if (uploaded.length === 6) setFileLimit(true);
                if (uploaded.length > 6) {
                    setFileLimit(false);
                    limitExceeded = true;
                }
            }
        }
        if (!limitExceeded) setUploadedFiles(uploaded);
    };

    const handleFileEvent = async (e) => {
        const chosenFiles = Array.from(e.target.files);
        handleUploadFiles(chosenFiles);
    };

    const convertToBase64 = (file) => {
        return new Promise((resolve, reject) => {
            const fileReader = new FileReader();
            fileReader.readAsDataURL(file);
            fileReader.onload = () => {
                resolve(fileReader.result);
            };
            fileReader.onerror = (error) => {
                reject(error);
            };
        });
    };

    return (
        <>
            <Formik
                initialValues={{
                    helpType: "",
                    header: "",
                    info: "",
                    location: "",
                    category: "",
                    terms: ""
                }}
                onSubmit={async (values) => {
                    const allData = {
                        helpType: values.helpType,
                        header: values.header,
                        info: values.info,
                        location: values.location,
                        category: values.category,
                        terms: values.terms,
                        files: uploadedFiles
                    };
                    alert(JSON.stringify(allData));
                    handleClose();
                }}
                validationSchema={AdvertCreationValidationSchema}
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
                                    {advertCreationConsts.helpTypes.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
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
                                    {advertCreationConsts.categories.map(
                                        (o) => (
                                            <option key={o} value={o}>
                                                {o}
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
                                    {advertCreationConsts.terms.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
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
                                    className="m-1"
                                />

                                <label htmlFor="fileUpload">
                                    <a className={uploadBtnClass}>
                                        Upload Photos
                                    </a>
                                </label>

                                <div className="uploaded-files-list">
                                    {uploadedFiles.map((file) => (
                                        <div key={file.base64}>{file.name}</div>
                                    ))}
                                </div>
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

export default AdvertCreationForm;
