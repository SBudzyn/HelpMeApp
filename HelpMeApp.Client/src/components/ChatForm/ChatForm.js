import React, { useState, useEffect } from "react";
import { Container, Row, Col, Button, ListGroup } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import {
    HubConnectionBuilder,
    LogLevel,
    HttpTransportType
} from "@microsoft/signalr";
import avatar from "../../media/defaultAvatarProfileIcon.jpg";
import routingUrl from "../../constants/routingUrl";
import baseRequest from "../../services/axiosServices";
import "./Chat.css";
import { getFormattedDateTime } from "../../services/getFormattedDate.js";

const ChatForm = () => {
    const [selectedChatId, setSelectedChatId] = useState(null);
    const [messages, setMessages] = useState([]);
    const [allChats, setAllChats] = useState([]);
    const [connection, setConnection] = useState();
    const navigate = useNavigate();
    const params = useParams();

    const joinChat = async (chatId) => {
        try {
            connection.stop();
        } catch (e) {
            console.error(e);
        }
        try {
            const connection = new HubConnectionBuilder()
                .configureLogging(LogLevel.Debug)
                .withUrl("https://localhost:7049/chat-hub", {
                    transport: HttpTransportType.WebSockets,
                    accessTokenFactory: () => localStorage.token,
                    UseDefaultCredentials: true
                })
                .build();

            connection.on("ReceiveMessagesHistory", (messagesHistory) => {
                setMessages(messagesHistory);
            });
            connection.on("ReceiveMessage", (message) => {
                setMessages((messages) => [...messages, message]);
            });
            connection.onclose((e) => {
                setConnection();
                setMessages([]);
            });

            await connection.start();
            await connection.invoke("JoinChat", chatId);
            setConnection(connection);
        } catch (e) {
            console.log(e);
        }
    };

    const sendMessage = async (message) => {
        try {
            await connection.invoke("SendMessage", message);
        } catch (e) {
            console.log(e);
        }
    };

    const getChats = async () => {
        await baseRequest
            .get("/chats/get-my-chats", {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: "Bearer " + localStorage.token
                }
            })
            .then((response) => {
                return response.data;
            })
            .then((data) => {
                setAllChats(data);
            });
    };

    useEffect(() => {
        getChats();
        if (params.id) {
            handleChatSelect(parseInt(params.id));
        }
    }, []);

    const handleChatSelect = (id) => {
        setSelectedChatId(id);
        joinChat(id);
        navigate(`${routingUrl.pathToChat}/${id}`);
    };

    const redirectToAdvert = () => {
        location.href = `${routingUrl.pathToAdvert}/${selectedChat.advertId}`;
    };

    const redirectToUserProfile = () => {
        location.href = `${routingUrl.pathToProfile}/${selectedChat.responderId}`;
    };

    const selectedChat =
        selectedChatId && allChats.find((chat) => chat.id === selectedChatId);

    return (
        <Container>
            <Row className="mt-2">
                <Col xs={4} className="chats-list-window pe-0">
                    <ListGroup>
                        {allChats.map((chat) => (
                            <ListGroup.Item
                                key={chat.id}
                                action
                                active={selectedChatId === chat.id}
                                onClick={() => handleChatSelect(chat.id)}
                                className="overflow-hidden lh-sm"
                            >
                                <img
                                    src={chat.advertPicture}
                                    alt="Image"
                                    className="image-icon mt-0"
                                />
                                <strong>{chat.advertTitle}</strong>
                                <p className="p-0 my-0">{chat.responderName}</p>
                                <p className="text-truncate lh-base mb-0">
                                    {chat.lastMessage?.senderId ===
                                    localStorage.userId
                                        ? "You: "
                                        : " "}
                                    {chat.lastMessage?.text}
                                </p>
                            </ListGroup.Item>
                        ))}
                    </ListGroup>
                </Col>
                <Col xs={8} className="">
                    <div className="d-flex align-items-center border rounded-top">
                        <img
                            src={avatar}
                            alt="Profile"
                            className={`flex-shrink-0 image-icon ${
                                !selectedChat ? "d-none" : ""
                            } `}
                        />
                        <h2
                            className="flex-grow-1 ms-1"
                            onClick={redirectToUserProfile}
                        >
                            {selectedChat
                                ? selectedChat.responderName
                                : "Select chat"}
                        </h2>
                        <Button
                            onClick={redirectToAdvert}
                            type="submit"
                            className="w-25 me-3"
                        >
                            Advert
                        </Button>
                    </div>

                    <div className="chat-window bg-primary bg-opacity-25">
                        {selectedChat &&
                            messages.map((message, index) => (
                                <div
                                    key={index}
                                    className={`message h-auto pb-0 ${
                                        message.senderId === localStorage.userId
                                            ? "right"
                                            : "left"
                                    }`}
                                >
                                    <blockquote>
                                        <p>{message.text}</p>
                                        <p className="blockquote-footer text-end">
                                            {getFormattedDateTime(
                                                message.sentTime
                                            )}
                                        </p>
                                    </blockquote>
                                </div>
                            ))}
                    </div>

                    <Formik
                        initialValues={{
                            message: ""
                        }}
                        onSubmit={async (values) => {
                            sendMessage(values.message);
                        }}
                    >
                        <Form>
                            <Row>
                                <Col xs={10} className="pe-0">
                                    <Field
                                        id="message"
                                        name="message"
                                        type="text"
                                        placeholder="Enter message..."
                                        className="p-2 w-100 h-100 border border-1 rounded-bottom-left-1"
                                    />{" "}
                                </Col>
                                <Col xs={2} className="ps-0">
                                    <Button
                                        type="submit"
                                        className="w-100 rounded-0 rounded-end"
                                        // disabled={!message}
                                    >
                                        Send
                                    </Button>
                                </Col>
                            </Row>
                        </Form>
                    </Formik>
                </Col>
            </Row>
        </Container>
    );
};

export default ChatForm;
