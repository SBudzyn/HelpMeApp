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

export const getFormattedDate = (date) => {
    return `${dayOfWeek[date.getDay() - 1]} ${
        months[date.getMonth()]
    } ${date.getDate()}`;
};

export const getFormattedDateTime = (datetime) => {
    const parsedDate = new Date(datetime);
    return `${parsedDate.getHours()}:${parsedDate.getMinutes()} ${parsedDate.getDate()} ${months[parsedDate.getMonth()]}`;
};
