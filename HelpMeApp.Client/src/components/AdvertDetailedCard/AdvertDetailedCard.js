import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import "bootstrap/dist/css/bootstrap.css";
import "./../../styles/pages.css";
import "./AdvertDetailedCard.css";
import { Carousel } from "react-bootstrap";
import defaultAdvertImage from "../../media/defaultAdvertPhoto.jpg";
import defaultAvatar from "../../media/defaultAvatarProfileIcon.jpg";
import { baseRequest } from "../../services/axiosServices";
import { getFormattedDate } from "../../services/getFormattedDate";
import checkRetrievedData from "../../services/checkRetrievedData";
import { Link } from "react-router-dom";
import MyAdvertButtons from "./MyAdvertButtons";
import OtherUserButtons from "./OtherUserButtons";
import routingUrl from "../../constants/routingUrl";

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
                if (data.photos.length === 0) {
                    data.photos.push(defaultAdvertImage);
                }
            });
    };

    useEffect(() => {
        retrieveAdvertById(props.advertId);
    }, []);

    return (
        <div className="container-fluid common-background">
            <div className="container pt-3">
                <div className="row">
                    <div className="col-md-12 col-lg-3 advert-short-info rounded bg-light ">
                        <Carousel>
                            {data.photos?.map((photo) => {
                                return (
                                    <Carousel.Item key={photo.name}>
                                        <img
                                            className="d-block w-100 img-thumbnail"
                                            src={photo}
                                            alt="slide"
                                        ></img>
                                    </Carousel.Item>
                                );
                            })}
                        </Carousel>
                        <div>
                            <div className="attributes-text mt-3">{`Category: ${data?.category}`}</div>
                            <div className="attributes-text mt-2">{`Terms: ${data?.terms} days`}</div>
                            <div className="attributes-text mt-2">{`Location: ${data.location}`}</div>
                            <div className="attributes-text mt-2">{`Creation Date: ${getFormattedDate(
                                new Date(data?.creationDate ?? "1 1 1970")
                            )}`}</div>
                        </div>
                    </div>
                    <div className="col-md-12 col-lg-9">
                        <div className="container d-flex flex-column h-100">
                            <Link to={routingUrl.pathToOtherUserProfile + `/${data.creatorId}`} className="text-dec-none">
                                <div className="col-xs-12 d-flex author-link">
                                    <img
                                        src={data.creatorPhoto ? data.creatorPhoto : defaultAvatar}
                                        className="author-photo rounded-circle"
                                    ></img>
                                    <h6 className="author-text">
                                        {checkRetrievedData(data?.creatorName)}
                                    </h6>
                                </div>
                            </Link>
                            <div className="row">
                                <div className="col-xs-12 mb-2">
                                    <h4 className="space-around mt-3">
                                        {checkRetrievedData(data?.header)}
                                    </h4>
                                </div>
                            </div>
                            <div>
                                <p className="description-text">
                                    {checkRetrievedData(data?.info)}
                                </p>
                            </div>

                            {localStorage.userId === data.creatorId
                                ? (
                                    <MyAdvertButtons advertId={props.advertId} />
                                )
                                : (
                                    <OtherUserButtons advertId={props.advertId} />
                                )}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

AdvertDetailedCard.propTypes = {
    advertId: PropTypes.string
};

export default AdvertDetailedCard;
