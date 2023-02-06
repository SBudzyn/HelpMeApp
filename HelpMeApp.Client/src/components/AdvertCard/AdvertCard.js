import { React } from "react";
import PropTypes from "prop-types";
import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import defaultAdvertPhoto from "../../media/defaultAdvertPhoto.jpg";
import routingUrl from "../../constants/routingUrl";
import "./AdvertCard.css";

const months = [
    "Jan",
    "Feb",
    "Mar",
    "Apr",
    "May",
    "June",
    "July",
    "Aug",
    "Sep",
    "Oct",
    "Nov",
    "Dec"
];

const dayOfWeek = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];

const AdvertShortInfo = (props) => {
    const linkToAdvert = `${routingUrl.pathToAdvert}/${props.id}`;
    const photoSrc = props.photo ?? defaultAdvertPhoto;
    const date = `${dayOfWeek[props.date.getDay()]} ${
        months[props.date.getMonth()]
    } ${props.date.getDate()}`;
    return (
        <Card className="card-size">
            <Link to={linkToAdvert}><Card.Img variant="top" src={photoSrc} className="image-border-bottom" /></Link>
            <Card.Body>
                <Link to={linkToAdvert} className="text-dec-none">
                    <Card.Title className="title">{props.title}</Card.Title>
                </Link>
            </Card.Body>
            <Card.Footer>
                <div className="footer-content">
                    <small>{props.location} </small>
                    <small>{date}</small>
                </div>
            </Card.Footer>
        </Card>
    );
};

AdvertShortInfo.propTypes = {
    title: PropTypes.string,
    photo: PropTypes.string,
    date: PropTypes.instanceOf(Date),
    location: PropTypes.string,
    id: PropTypes.number
};

export default AdvertShortInfo;
