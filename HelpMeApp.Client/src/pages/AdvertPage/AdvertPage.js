import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.css";
import "./AdvertPage.css";
import { Carousel } from "react-bootstrap";
import defaultPhoto from "../../media/defaultAdvertPhoto.jpg";
import baseRequest from "../../services/axiosServices";
import getFormattedDate from "../../services/getFormattedDate";
import checkRetrievedData from "../../services/checkRetrievedData";
import routingUrl from "../../constants/routingUrl";

const photos = [defaultPhoto];
const AdvertPage = () => {
    const params = useParams();

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

    const redirectToChat = async () => {
        await baseRequest
            .get(`/chats/advert/${data.id}`, {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.token
                }
            })
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                location.href = `${routingUrl.pathToChat}/${data.id}`;
            });
    };

    useEffect(() => {
        retrieveAdvertById(params.id);
    }, []);

    return (
        <div className="container">
            <div className="row page bg-light">
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
                    <button
                        onClick={(e) => {
                            e.preventDefault();
                            redirectToChat();
                        }}
                        className="btn btn-primary mt-3 width-100-relative"
                    >
                        chat
                    </button>
                    <button className="btn btn-warning mt-3 width-100-relative">
                        report
                    </button>
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
                            <div className="col-sm-4 col-md-3">
                                {getFormattedDate(
                                    new Date(data?.creationDate ?? "1 1 1970")
                                )}
                            </div>
                            <div className="col-sm-4 col-md-3">
                                {checkRetrievedData(data?.location)}
                            </div>
                            <div className="col-sm-4 col-md-3">
                                {checkRetrievedData(data?.category)}
                            </div>
                        </div>
                        <p>{checkRetrievedData(data?.info)}</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AdvertPage;
