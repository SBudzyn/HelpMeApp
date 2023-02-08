import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.css";
import "./AdvertPage.css";
import { Carousel } from "react-bootstrap";
import defaultPhoto from "../../media/defaultAdvertPhoto.jpg";
import axios from "axios";
import { serverUrl } from "../../constants/server";

const photos = [defaultPhoto];
const AdvertPage = () => {
    const params = useParams();

    const [data, setData] = useState({});

    const retrieveAdvertById = async (id) => {
        await axios
            .get(`${serverUrl}/api/advert/${id}`)
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setData(data);
            });
    };

    useEffect(() => {
        retrieveAdvertById(params.id);
    }, []);

    console.log(params.id);
    return (
        <div className="container" key={1}>
            <div className="row page bg-light">
                <div className="col-md-12 col-lg-3 column-1">
                    <Carousel>
                        {photos.map((p) => {
                            return (
                                <Carousel.Item key={1}>
                                    <img
                                        className="d-block w-100"
                                        src={p}
                                        alt="slide"
                                    ></img>
                                </Carousel.Item>
                            );
                        })}
                    </Carousel>
                    <button className="btn btn-primary mt-3 width-100-relative">
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
                                    {data?.header ?? "No data"}
                                </h4>
                            </div>
                        </div>
                        <div className="row space-around mb-3">
                            <div className="col-sm-4 col-md-3">
                                {data?.creationDate ?? "No data"}
                            </div>
                            <div className="col-sm-4 col-md-3">
                                {data?.location ?? "No data"}
                            </div>
                            <div className="col-sm-4 col-md-3">
                                {data?.category ?? "No data"}
                            </div>
                        </div>
                        <p>{data?.info ?? "No data"}</p>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AdvertPage;
