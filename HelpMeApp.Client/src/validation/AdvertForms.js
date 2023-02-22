import * as Yup from "yup";

const AdvertForms = Yup.object().shape({
    helpType: Yup.string()
        .required("Required!"),
    header: Yup.string()
        .min(5, "Must be 5 at least characters")
        .max(45, "Must be 45 characters or less")
        .required("Required!"),
    info: Yup.string()
        .min(20, "Must be 20 at least characters")
        .max(200, "Must be 200 characters or less")
        .required("Required!"),
    location: Yup.string()
        .min(4, "Must be 4 at least characters")
        .max(20, "Must be 20 characters or less")
        .required("Required!"),
    category: Yup.string()
        .required("Required!"),
    terms: Yup.string()
        .required("Required!")
});

export default AdvertForms;
