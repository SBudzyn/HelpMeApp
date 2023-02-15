import * as yupModifyProfileData from "yup";
import "yup-phone";
import YupPassword from "yup-password";
YupPassword(yupModifyProfileData);

const ProfileDataModificationScheme = yupModifyProfileData.object().shape({
    email: yupModifyProfileData
        .string()
        .required("Please provide valid email")
        .email("This doesn't look like email"),
    password: yupModifyProfileData
        .string()
        .required("Please provide valid password")
        .min(8, "Password is too short - must be 8 symbols minimum")
        .minLowercase(1, "Password must include at least one lowercase symbol")
        .minUppercase(1, "Password must include at least one uppercase symbol")
        .minNumbers(1, "Password must include at least one number"),
    name: yupModifyProfileData
        .string("Name")
        .min(2, "This name is too short")
        .matches(/^[aA-zZ\s]+$/, "Name can contain only letters")
        .required("Please provide your name"),
    surname: yupModifyProfileData
        .string("Surname can contain only letters")
        .min(2, "This surname is too short")
        .matches(/^[aA-zZ\s]+$/, "Surname can contain only letters")
        .required("Please provide your surname"),
    phoneNumber: yupModifyProfileData
        .string()
        .phone("", true, "Provide correct phone number")
        .typeError("Provide your phone number")
        .required("Provide your phone number"),
    info: yupModifyProfileData.string().notRequired(),

    photo: yupModifyProfileData.mixed().nullable().notRequired()
});

export default ProfileDataModificationScheme;
