import { React } from "react";
import PropTypes from "prop-types";
import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import defaultChatPhoto from "../../media/defaultAvatarProfileIcon.jpg";
import "./ChatCard.css";

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

const ChatShortInfo = (props) => {
    const linkToChat = `${routingUrl.pathToChat}/${props.id}`;
    const photoSrc = props.photo ?? defaultChatPhoto;
    const date = `${dayOfWeek[props.date.getDay()]} ${
        months[props.date.getMonth()]
    } ${props.date.getDate()}`;
    return (
        <Card className="card-size">
            <Link to={linkToChat}><Card.Img variant="top" src={photoSrc} className="image-border-bottom" /></Link>
            <Card.Body>
                <Link to={linkToChat} className="text-dec-none">
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

ChatShortInfo.propTypes = {
    title: PropTypes.string,
    photo: PropTypes.string,
    date: PropTypes.instanceOf(Date),
    location: PropTypes.string,
    id: PropTypes.number
};

export default ChatShortInfo;
