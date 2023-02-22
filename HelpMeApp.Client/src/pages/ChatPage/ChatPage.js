import React from "react";
import ChatForm from "../../components/ChatForm/ChatForm";
import PropTypes from "prop-types";

const ChatPage = () => {
    return (
        <div className="centered-form">
            <ChatForm />
        </div>
    );
};

ChatPage.propTypes = {
    component: PropTypes.element
};

export default ChatPage;
