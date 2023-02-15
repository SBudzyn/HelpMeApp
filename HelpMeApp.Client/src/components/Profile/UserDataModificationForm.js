import { useState, React } from "react";
import { Formik, Field, Form, ErrorMessage } from "formik";
import ProfileDataModificationScheme from "../../validation/ProfileDataModification";
import { handleUploadFiles } from "../../services/filesUploading";
import classNames from "classnames";

const ModifyProfileDataForm = () => {
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

    return (
        <>
            <Formik
                initialValues={{}}
                onSubmit={async (values) => {
                    const allData = {
                        email: values.email,
                        password: values.password,
                        name: values.name,
                        surname: values.surname,
                        phoneNumber: values.phoneNumber,
                        info: values.info,
                        files: uploadedFiles
                    };
                    alert(JSON.stringify(allData));
                }}
                validationSchema={ProfileDataModificationScheme}
            >
                {(formik) => {
                    const { isValid, dirty } = formik;
                    return (
                        <Form className="creation-form">
                            <h1 className="text-center mt-3 mb-3">
                                Edit your info
                            </h1>

                            <div className="mx-auto w-75">
                                <label htmlFor="email" className="mb-5">
                                    Email
                                </label>
                                <Field
                                    as="input"
                                    type="email"
                                    name="email"
                                    className="up form-control border-primary"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="email" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="password" className="mb-5">
                                    Password
                                </label>
                                <Field
                                    as="input"
                                    type="password"
                                    name="password"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="password" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="name" className="mb-5">
                                    Name
                                </label>
                                <Field
                                    as="input"
                                    type="text"
                                    name="name"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="name" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="surname" className="mb-5">
                                    Surname
                                </label>
                                <Field
                                    as="input"
                                    type="text"
                                    name="surname"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="surname" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="phoneNumber" className="mb-5">
                                    Phone number
                                </label>
                                <Field
                                    as="input"
                                    type="tel"
                                    name="phoneNumber"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="phoneNumber" />
                                </div>
                            </div>

                            <div className="mx-auto w-75">
                                <label htmlFor="info" className="mb-5">
                                    Information
                                </label>
                                <Field
                                    as="input"
                                    type="text"
                                    name="info"
                                    className="h-100 up form-control border-primary"
                                    rows="4"
                                />
                                <div className="error-message">
                                    <ErrorMessage name="info" />
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
                            </div>
                            <br />
                            <button
                                className="mx-auto w-75 mt-4 mb-5 submit-button horizontal-center btn btn-primary mb-3"
                                type="submit"
                                disabled={!(dirty && isValid)}
                            >
                                Update
                            </button>
                        </Form>
                    );
                }}
            </Formik>
        </>
    );
};

export default ModifyProfileDataForm;
