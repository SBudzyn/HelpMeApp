const months = [
    "Jan",
    "Feb",
    "Mar",
    "Apr",
    "May",
    "June",
    "July",
    "Aug",
    "Sep",
    "Oct",
    "Nov",
    "Dec"
];

const dayOfWeek = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"];

const getFormattedDate = (date) => {
    return `${dayOfWeek[date.getDay()]} ${
        months[date.getMonth()]
    } ${date.getDate()}`;
};

export default getFormattedDate;
