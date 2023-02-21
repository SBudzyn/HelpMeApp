import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./AdvertPage.css";
import { Carousel } from "react-bootstrap";
import defaultPhoto from "../../media/defaultAdvertPhoto.jpg";
import baseRequest from "../../services/axiosServices";
import getFormattedDate from "../../services/getFormattedDate";
import checkRetrievedData from "../../services/checkRetrievedData";

const AdvertPage = () => {
    const params = useParams();
    return (<div className="mt-1">
        <AdvertDetailedCard advertId={params.id}/>
    </div>);
};

export default AdvertPage;
