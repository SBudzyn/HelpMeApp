import { useState } from 'react';
import { Formik, Field, Form } from 'formik';
import { Link } from 'react-router-dom';
import { routes } from '../../Constants/Constants';
import Modal from 'react-bootstrap/Modal'
import 'bootstrap/dist/css/bootstrap.css';
import './AuthorizationForms.css';

const {
    pathToLoginPage,
    pathToSignUpPage
} = routes;



const RegistrationForm = () => {
    const [registrationData, setRegistrationData] = useState({
        email: '',
        password: ''
    });
    const [show, setShow] = useState(false);

    const [photo, setPhoto] = useState(null);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <div className='auth-form'>
            <div className="header-button-wrapper">
                <Link to={pathToLoginPage}><button className="other-form-type normal-button header-button left-button">login</button></Link>
                <Link to={pathToSignUpPage}><button className="current-form-type normal-button header-button right-button">registration</button></Link>
            </div>
            <Formik
                initialValues={{
                    email: '',
                    password: ''
                }}
                onSubmit={async (values) => {

                    setRegistrationData(values);
                    handleShow();


                }}
            >
                <Form className='form'>
                    <div className='mb-3 row'>
                        <label htmlFor="email" className='col-sm-2 col-form-label up'>Email</label>
                        <br />

                        <Field
                            id="email"
                            name="email"
                            placeholder="name@gmail.com"
                            type="email"
                            className="form-control up"
                            required
                        />

                    </div>

                    <div className='mb-3 row'>
                        <label htmlFor="password" className='col-sm-2 col-form-label up'>Password</label>
                        <Field
                            id="password"
                            name="password"
                            type="password"
                            className="form-control up"
                            required
                        />
                    </div>
                    <br />
                    <button className='submit-button horizontal-center btn btn-primary mb-3 up' type="submit">Next</button>

                </Form>
            </Formik>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Fill in personal data</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div>
                        <Formik
                            initialValues={{
                                name: '',
                                surname: '',
                                phoneNumber: '',
                                info: ''
                            }}
                            onSubmit={
                                async (values) => {
                                    let allData = {
                                        email: registrationData.email,
                                        password: registrationData.password,
                                        name: values.name,
                                        phoneNumber: values.phoneNumber,
                                        info: values.info,
                                        photo: photo.name
                                    }
                                    alert(JSON.stringify(allData));
                                    //configure form data and send post request with photo

                                    // const formData = new FormData();
                                    // formData.append("file", photo);

                                    // const response = await fetch('https://localhost:7048/api/Photo', {method: 'POST', body: formData});


                                    //add redirection
                                    handleClose();
                                }

                            }
                        >
                            <Form>
                                <div className='mb-3 row modal-group'>
                                    <label htmlFor="name" className='col-sm-2 col-form-label'>Name</label>
                                    <br />

                                    <Field
                                        id="name"
                                        name="name"
                                        placeholder="John"
                                        type="text"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className='mb-3 row modal-group'>
                                    <label htmlFor="surname" className='col-sm-2 col-form-label'>Surname</label>
                                    <br />

                                    <Field
                                        id="Surname"
                                        name="Surname"
                                        placeholder="Bobkin"
                                        type="text"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className='mb-3 row modal-group'>
                                    <label htmlFor="phoneNumber" className='col-sm-4 col-form-label'>Phone Number</label>
                                    <br />

                                    <Field
                                        id="phoneNumber"
                                        name="phoneNumber"
                                        placeholder="+380000000000"
                                        type="tel"
                                        className="form-control"
                                        required
                                    />
                                </div>
                                <div className='mb-3 row modal-group'>
                                    <label htmlFor="info" className='col-sm-2 col-form-label'>Info</label>
                                    <br />

                                    <Field
                                        id="info"
                                        name="info"
                                        placeholder="Some info about you"
                                        type="text"
                                        className="form-control"
                                    />

                                    <div className='bm-3'>
                                        <br />
                                        <label for="photo" className="form-label">Select your photo</label>
                                        <input className="form-control" type="file" id="photo" onChange={(event) => {
                                            setPhoto(event.currentTarget.files[0]);
                                        }}
                                        ></input>
                                    </div>
                                </div>
                                <br />
                                <button type='submit' className='horizontal-center btn btn-primary mb-1 modal-btn'>Register</button>
                            </Form>
                        </Formik>
                    </div>
                </Modal.Body>

            </Modal>

        </div >
    );
}

export default RegistrationForm;