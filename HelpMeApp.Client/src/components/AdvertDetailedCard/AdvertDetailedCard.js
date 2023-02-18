import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import "bootstrap/dist/css/bootstrap.css";
import "./AdvertDetailedCard.css";
import { Carousel } from "react-bootstrap";
import defaultPhoto from "../../media/defaultAdvertPhoto.jpg";
import baseRequest from "../../services/axiosServices";
import getFormattedDate from "../../services/getFormattedDate";
import checkRetrievedData from "../../services/checkRetrievedData";

const photos = [defaultPhoto];

const AdvertDetailedCard = (props) => {
    const [data, setData] = useState({});

    const retrieveAdvertById = async (id) => {
        await baseRequest
            .get(`/adverts/${id}`)
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setData(data);
            });
    };

    useEffect(() => {
        retrieveAdvertById(props.advertId);
    }, []);

    return (
        <div className="container mt-3">
            <div className="row bg-light">
                <div className="col-md-12 col-lg-3 column-1">
                    <Carousel>
                        {photos.map((photo) => {
                            return (
                                <Carousel.Item key={photo.name}>
                                    <img
                                        className="d-block w-100"
                                        src={photo}
                                        alt="slide"
                                    ></img>
                                </Carousel.Item>
                            );
                        })}
                    </Carousel>
                    <div>{`Category: ${data?.category}`}</div>
                    <div>{`Terms: ${data?.terms} days`}</div>
                    <div>{`Location: ${data.location}`}</div>
                    <div>{`Creation Date: ${getFormattedDate(
                        new Date(data?.creationDate ?? "1 1 1970")
                    )}`}</div>
                    {/* <button className="btn btn-primary mt-3 width-100-relative">
                        chat
                    </button>
                    <button className="btn btn-warning mt-3 width-100-relative">
                        report
                    </button> */}
                </div>
                <div className="col-md-12 col-lg-9">
                    <div className="container">
                        <div className="row">
                            <div className="col-xs-12">
                                <h4 className="space-around mt-3">
                                    {checkRetrievedData(data?.header)}
                                </h4>
                            </div>
                        </div>
                        <div className="row space-around mb-3">
                            <div className="col-sm-4 col-md-3 atributes-text">
                                {getFormattedDate(
                                    new Date(data?.creationDate ?? "1 1 1970")
                                )}
                            </div>
                            <div className="col-sm-4 col-md-3 atributes-text">
                                {checkRetrievedData(data?.location)}
                            </div>
                            <div className="col-sm-4 col-md-3 atributes-text">
                                {checkRetrievedData(data?.category)}
                            </div>
                        </div>
                        <p className="description-text">
                            {checkRetrievedData(data?.info)}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    );
};

AdvertDetailedCard.propTypes = {
    advertId: PropTypes.number
};

export default AdvertDetailedCard;
