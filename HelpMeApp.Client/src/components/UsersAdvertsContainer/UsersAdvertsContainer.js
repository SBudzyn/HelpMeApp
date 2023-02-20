import { React, useEffect, useState } from "react";
import AdvertCard from "../AdvertCard/AdvertCard";
import { baseRequestWithToken } from "../../services/axiosServices";

const UsersAdvertsContainer = () => {
    const [adverts, setAdverts] = useState([]);

    const retrieveAdverts = async () => {
        await baseRequestWithToken
            .get("/profile/get-user-adverts/")
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setAdverts(data);
            });
    };
    useEffect(() => {
        retrieveAdverts();
    }, []);

    return (
        <div className="container">
            <div className="row">
                {adverts.map((advert) => (
                    <div
                        className="col-xs-12 col-sm-8 col-md-6 col-lg-4 col-xl-3 col-xxl-3 mb-3"
                        key={advert.id}
                    >
                        <AdvertCard
                            key={advert.id}
                            id={advert.id}
                            title={advert.header}
                            location={advert.location}
                            date={new Date(advert.creationDate)}
                        />
                    </div>
                ))}
            </div>
        </div>
    );
};

export default UsersAdvertsContainer;
