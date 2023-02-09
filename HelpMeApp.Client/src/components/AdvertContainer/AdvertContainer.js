import { React, useEffect, useState } from "react";
import PropTypes from "prop-types";
import AdvertCard from "../AdvertCard/AdvertCard";
import baseRequest from "../../services/axiosServices";

const AdvertShortInfoLayout = (props) => {
    const [adverts, setAdverts] = useState([]);

    const retrieveAdverts = async () => {
        await baseRequest
            .get(`/advert/page/${props.page}`, {
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
                {adverts.map((a) => (
                    <div
                        className="col-xs-12 col-sm-8 col-md-6 col-lg-4 col-xl-3 col-xxl-3 mb-3"
                        key={a.id}
                    >
                        <AdvertCard
                            key={a.id}
                            id={a.id}
                            title={a.header}
                            location={a.location}
                            date={new Date(a.creationDate)}
                        />
                    </div>
                ))}
            </div>
        </div>
    );
};

AdvertShortInfoLayout.propTypes = {
    page: PropTypes.number,
    helpTypeId: PropTypes.number,
    location: PropTypes.string,
    sortBy: PropTypes.string,
    categoryId: PropTypes.number,
    termsId: PropTypes.number
};

export default AdvertShortInfoLayout;
