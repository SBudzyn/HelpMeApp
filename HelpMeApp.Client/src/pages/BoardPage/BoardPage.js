import React from "react";
import { Formik, Field, Form } from "formik";
import AdvertContainer from "../../components/AdvertContainer/AdvertContainer";
import "bootstrap/dist/css/bootstrap.css";
import "./BoardPage.css";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";

const categories = ["clothes", "food", "healthcare"];

const terms = ["1 day", "2-3 days", "4-5 days"];

const location = ["Kharkiv", "Lviv", "Kyiv"];

const sortBy = ["terms", "rating"];

const BoardPage = () => {
    return (
        <div className="page">
            <Formik
                initialValues={{
                    category: "",
                    terms: "",
                    location: "",
                    sortBy: "terms"
                }}
                onSubmit={(values) => {
                    alert(JSON.stringify(values));
                }}
            >
                <div className="container">
                    <div className="row justify-content-end"></div>
                    <Form>
                        <div className="row mt-3">
                            <div className=" col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="category"
                                    className="form-select mb-3 drop-down border border-primary"
                                >
                                    <option defaultValue={null}>
                                        Choose category
                                    </option>
                                    {categories.map((o) => (
                                        <option
                                            key={o}
                                            value={o}
                                            className="dropdown-item border"
                                            aria-label="form-select-lg"
                                        >
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="location"
                                    className="form-select mb-3 drop-down border border-warning"
                                >
                                    <option defaultValue={null}>
                                        Choose location
                                    </option>
                                    {location.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="terms"
                                    className="form-select mb-3 drop-down border border-primary"
                                >
                                    <option defaultValue={null}>
                                        Choose terms
                                    </option>
                                    {terms.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="sortBy"
                                    className="form-select mb-3 drop-down border border-warning"
                                >
                                    <option defaultValue={null}>SortBy</option>
                                    {sortBy.map((o) => (
                                        <option key={o} value={o}>
                                            {o}
                                        </option>
                                    ))}
                                </Field>
                            </div>
                        </div>
                        <div className="row justify-content-between">
                            <div className="mb-3 col-lg-3">
                                <Link to={routingUrl.pathToAdvertCreation}>
                                    <button
                                        style={{
                                            height: "100%",
                                            width: "100%"
                                        }}
                                        type="button"
                                        className="btn btn-outline-warning btn-lg"
                                    >
                                        New Advert
                                    </button>
                                </Link>
                            </div>
                            <div className="mb-3 col-lg-3">
                                <button
                                    style={{
                                        height: "100%",
                                        width: "100%"
                                    }}
                                    type="submit"
                                    className="btn btn-outline-primary btn-lg"
                                >
                                    Find
                                </button>
                            </div>
                        </div>
                    </Form>
                </div>
            </Formik>
            <hr />
            <AdvertContainer />
        </div>
    );
};

export default BoardPage;
