import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import { useParams } from "react-router-dom";
import AdvertDetailedCard from "../../components/AdvertDetailedCard/AdvertDetailedCard";

const AdvertPage = () => {
    const params = useParams();
    return (<div className="mt-1">
        <AdvertDetailedCard advertId={params.id}/>
    </div>);
};

export default AdvertPage;
