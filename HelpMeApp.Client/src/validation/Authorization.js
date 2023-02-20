import * as yupLogin from "yup";
import YupPassword from "yup-password";

YupPassword(yupLogin);

const Authorization = yupLogin.object().shape({
    email: yupLogin
        .string()
        .required("Please provide valid email")
        .email("This doesn't look like email"),
    password: yupLogin
        .string()
        .required("Please provide valid password")
        .min(8, "Password is too short - must be 8 symbols minimum")
        .minLowercase(1, "Password must include at least one lowercase symbol")
        .minUppercase(1, "Password must include at least one uppercase symbol")
        .minNumbers(1, "Password must include at least one number")
});

export default Authorization;
