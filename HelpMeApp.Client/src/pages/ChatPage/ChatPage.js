import React from "react";
import "./ChatPage.css";
import ChatFormik from "../../components/ChatForm/ChatFormik";

const ChatPage = () => {
    return (
        <div className="centered-form mb-5 mx-4">
            <ChatFormik />
        </div>
    );
};

export default ChatPage;
