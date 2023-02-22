import React, { useState, useEffect } from "react";
import { Formik, Field, Form } from "formik";
import AdvertContainer from "../../components/AdvertContainer/AdvertContainer";
import "bootstrap/dist/css/bootstrap.css";
import { Link, useParams } from "react-router-dom";
import { baseRequest } from "../../services/axiosServices";
import Pagination from "../../components/Pagination/Pagination";
import PropTypes from "react-bootstrap/esm/Image";
import routingUrl from "../../constants/routingUrl";

const BoardPage = (props) => {
    const params = useParams();

    const [generalData, setGeneralData] = useState({});

    const [adverts, setAdverts] = useState([]);

    const retrieveAdverts = async () => {
        await baseRequest
            .get(`/adverts/page/${params.page}`, {
                params: {
                    helpTypeId: props.helpTypeId,
                    categoryId: localStorage.categoryId,
                    termsId: localStorage.termsId,
                    location: localStorage.location,
                    sortBy: localStorage.sortBy
                }
            })
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setAdverts(data);
            });
    };

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

    const reset = () => {
        localStorage.categoryId = "0";
        localStorage.termsId = "0";
        localStorage.location = "";
        localStorage.sortBy = "";
        location.href =
            props.helpTypeId === 1
                ? routingUrl.pathToGiveHelpBoard + "/1"
                : routingUrl.pathToGetHelpBoard + "/1";
    };

    useEffect(() => {
        retrieveAdverts();
        retrieveGeneralData();
    }, []);

    return (
        <div>
            <Formik
                initialValues={{
                    categoryId: localStorage?.categoryId ?? "",
                    termsId: localStorage?.termsId ?? "",
                    location: localStorage?.location ?? "",
                    sortBy: localStorage?.sortBy ?? ""
                }}
                onSubmit={(values) => {
                    localStorage.categoryId = values.categoryId;
                    localStorage.sortBy = values.sortBy;
                    localStorage.location = values.location;
                    localStorage.termsId = values.termsId;
                    location.href =
                        props.helpTypeId === 1
                            ? routingUrl.pathToGetHelpBoard + "/1"
                            : routingUrl.pathToGiveHelpBoard + "/1";
                }}
            >
                <div className="container">
                    <div className="row justify-content-end"></div>
                    <Form>
                        <div className="row mt-3">
                            <div className=" col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="categoryId"
                                    className="form-select mb-3 drop-down border border-primary"
                                >
                                    <option value="0">
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
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="termsId"
                                    className="form-select mb-3 drop-down border border-warning"
                                >
                                    <option value="0">
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
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    as="select"
                                    name="sortBy"
                                    className="form-select mb-3 drop-down border border-primary"
                                >
                                    <option defaultValue={""}>Sort by</option>
                                    <option value="date">Creation Date</option>
                                </Field>
                            </div>
                            <div className="col-xs-12 col-lg-3">
                                <Field
                                    type="text"
                                    name="location"
                                    className="form-control mb-3 border border-warning"
                                    placeholder="Choose location"
                                />
                            </div>
                        </div>
                        <div className="row justify-content-between">
                            <div className="mb-3 col-lg-3">
                                <Link to={routingUrl.pathToAdvertCreation}>
                                    <button
                                        type="button"
                                        className="btn btn-outline-warning btn-lg w-100 h-100"
                                    >
                                        New Advert
                                    </button>
                                </Link>
                            </div>
                            <div className="mb-3 col-lg-4">
                                <button
                                    type="submit"
                                    className="btn btn-outline-primary btn-lg w-100 h-100"
                                >
                                    Find
                                </button>
                            </div>
                            <div className="mb-3 col-lg-3">
                                <button
                                    type="button"
                                    onClick={() => {
                                        reset();
                                    }}
                                    className="btn btn-outline-warning btn-lg w-100 h-100"
                                >
                                    Reset Filters
                                </button>
                            </div>
                        </div>
                    </Form>
                </div>
            </Formik>
            <hr />
            <AdvertContainer
                adverts={adverts}
            />
            <hr />
            <div className="container mt-3 mb-3">
                <div className="row justify-content-center">
                    <div className="col-xs-12 col-md-6 col-lg-3 col-xl-2">
                        <Pagination
                            advertsByCurrentPage={adverts.length}
                            currentPage={Number(params.page)}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

BoardPage.propTypes = {
    helpTypeId: PropTypes.number
};

export default BoardPage;
