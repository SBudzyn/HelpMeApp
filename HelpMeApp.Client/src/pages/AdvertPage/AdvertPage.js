import React from "react";
import { useParams } from "react-router-dom";
import AdvertDetailedCard from "../../components/AdvertDetailedInfo/AdvertDetailedCard";

const AdvertPage = () => {
    const params = useParams();
    return (<div>
        <AdvertDetailedCard advertId={~~params.id}/>
    </div>);
};

export default AdvertPage;
