import React, { useState, useEffect, useRef } from "react";
import { Container, Row, Col, Button, ListGroup } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import { Field, Form, Formik } from "formik";
import {
    HubConnectionBuilder,
    LogLevel,
    HttpTransportType
} from "@microsoft/signalr";
import defaultAdvertPicture from "../../media/defaultAdvertPhoto.jpg";
import defaultAvatar from "../../media/defaultAvatarProfileIcon.jpg";
import routingUrl from "../../constants/routingUrl";
import { baseRequest } from "../../services/axiosServices";
import "./Chat.css";
import { getFormattedDateTime } from "../../services/getFormattedDate.js";

const ChatForm = () => {
    const [selectedChatId, setSelectedChatId] = useState(null);
    const [messages, setMessages] = useState([]);
    const [allChats, setAllChats] = useState([]);
    const [connection, setConnection] = useState();
    const navigate = useNavigate();
    const params = useParams();
    const bottomRef = useRef(null);

    const joinChat = async (chatId) => {
        connection?.stop();

        try {
            const connection = new HubConnectionBuilder()
                .configureLogging(LogLevel.Information)
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

    useEffect(() => {
        bottomRef.current.scrollIntoView();
    }, [messages]);

    const handleChatSelect = async (id) => {
        setSelectedChatId(id);
        await joinChat(id);
        navigate(`${routingUrl.pathToChat}/${id}`);
    };

    const redirectToAdvert = () => {
        location.href = `${routingUrl.pathToAdvert}/${selectedChat.advertId}`;
    };

    const redirectToUserProfile = () => {
        location.href = `${routingUrl.pathToOtherUserProfile}/${selectedChat.responderId}`;
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
                                <Row>
                                    <Col xs={3} className="align-middle hidden-when-width-700">
                                        <img
                                            src={
                                                chat.advertPicture ||
                                                defaultAdvertPicture
                                            }
                                            alt="Advert picture"
                                            className="image-icon mt-0 ms-0"
                                        />
                                    </Col>
                                    <Col xs={9}>
                                        <Row>
                                            <p className="text-truncate fw-bold ps-0 ms-0 mt-2 mb-1 align-middle">
                                                {chat.advertTitle}
                                            </p>
                                        </Row>
                                        <Row>
                                            <p className="fst-italic text-truncate ps-0">
                                                {chat.responderName}
                                            </p>
                                        </Row>
                                    </Col>
                                </Row>

                                <p className="text-truncate lh-base mb-0 ms-2">
                                    {chat.lastMessage?.senderId ===
                                    localStorage.userId
                                        ? "You: "
                                        : `${chat.responderName}: `}
                                    {chat.lastMessage?.text}
                                </p>
                            </ListGroup.Item>
                        ))}
                    </ListGroup>
                </Col>
                <Col xs={8} className="">
                    <div className="d-flex align-items-center border rounded-top">
                        <img
                            src={selectedChat?.responderAvatar || defaultAvatar}
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
                        <div
                            ref={bottomRef}
                            className="h-auto pb-0 right"
                        ></div>
                    </div>

                    <Formik
                        initialValues={{
                            message: ""
                        }}
                        onSubmit={async (values) => {
                            sendMessage(values.message);
                            values.message = "";
                        }}
                    >
                        <Form>
                            <Row>
                                <Col xs={9} className="pe-0">
                                    <Field
                                        id="message"
                                        name="message"
                                        type="text"
                                        placeholder="Enter message..."
                                        className="p-2 w-100 h-100 border border-1 rounded-bottom-left"
                                    />
                                </Col>
                                <Col xs={3} className="ps-0">
                                    <Button
                                        type="submit"
                                        className="w-100 rounded-0 rounded-end"
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
