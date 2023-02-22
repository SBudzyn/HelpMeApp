import { React } from "react";
import PropTypes from "prop-types";
import AdvertCard from "../AdvertCard/AdvertCard";

const AdvertContainer = (props) => {
    return (
        <div className="container">
            <div className="row">
                {props.adverts.map((advert) => (
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
                            photo={advert.photo}
                        />
                    </div>
                ))}
            </div>
        </div>
    );
};

AdvertContainer.propTypes = {
    adverts: PropTypes.array
};

export default AdvertContainer;
