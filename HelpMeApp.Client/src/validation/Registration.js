import * as yupRegistration from "yup";
import "yup-phone";
import YupPassword from "yup-password";
YupPassword(yupRegistration);

const Registration = yupRegistration.object().shape({
    name: yupRegistration
        .string("Name")
        .min(2, "This name is too short")
        .matches(/^[aA-zZ\s]+$/, "Name can contain only letters")
        .required("Please provide your name"),
    surname: yupRegistration
        .string("Surname can contain only letters")
        .min(2, "This surname is too short")
        .matches(/^[aA-zZ\s]+$/, "Surname can contain only letters")
        .required("Please provide your surname"),
    phoneNumber: yupRegistration
        .string()
        .phone("", true, "Provide correct phone number")
        .typeError("Provide your phone number")
        .required("Provide your phone number"),
    info: yupRegistration.string().notRequired(),

    photo: yupRegistration.mixed().nullable().notRequired()
});

export default Registration;
