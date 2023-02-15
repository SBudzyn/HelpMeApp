import { React, useEffect, useState } from "react";
import PropTypes from "prop-types";
import AdvertCard from "../AdvertCard/AdvertCard";
import baseRequest from "../../services/axiosServices";

const AdvertContainer = (props) => {
    const [adverts, setAdverts] = useState([]);

    const retrieveAdverts = async () => {
        await baseRequest
            .get(`/adverts/page/${props.page}`, {
                params: {
                    helpTypeId: props.helpTypeId,
                    categoryId: props.categoryId,
                    termsId: props.termsId,
                    location: props.location,
                    sortBy: props.sortBy
                }
            })
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

AdvertContainer.propTypes = {
    page: PropTypes.number,
    helpTypeId: PropTypes.number,
    location: PropTypes.string,
    sortBy: PropTypes.string,
    categoryId: PropTypes.number,
    termsId: PropTypes.number
};

export default AdvertContainer;
