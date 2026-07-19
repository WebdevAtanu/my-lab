import Handlebars from "handlebars";

// Register a helper to format currency
Handlebars.registerHelper("currency", function (value) {
    return new Intl.NumberFormat("en-IN", {
        style: "currency",
        currency: "INR",
    }).format(value);
});

export default Handlebars;