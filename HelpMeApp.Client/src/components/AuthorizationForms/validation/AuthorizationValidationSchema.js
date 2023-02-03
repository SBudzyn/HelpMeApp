import * as yupLogin from "yup";
import YupPassword from "yup-password";

YupPassword(yupLogin);

const AuthoirzationValidationSchema = yupLogin.object().shape({
    email: yupLogin
        .string()
        .required("Please provide valid email")
        .email("That doesn't look like an email"),
    password: yupLogin
        .string()
        .required("Please provide valid password")
        .min(8, "Password is too short - must be 8 symbols minimum.")
        .minLowercase(1, "Password must include at least one lowercase symbol")
        .minUppercase(1, "Password must include at least one uppercase symbol")
        .minNumbers(1, "Password include at least one number")
});

export default AuthoirzationValidationSchema;
