import puppeteer from "puppeteer";
import fs from "fs/promises";
import Handlebars from "../helpers/handlebar.js";

// Compile Handlebars template and return HTML
async function compile(templateName, data) {
    // Register partial
    const header = await fs.readFile(
        "./templates/partials/header.hbs",
        "utf8"
    );

    const footer = await fs.readFile(
        "./templates/partials/footer.hbs",
        "utf8"
    );

    Handlebars.registerPartial("footer", footer);
    Handlebars.registerPartial("header", header);

    // Compile page template 
    const pageHtml = await fs.readFile(
        `./templates/${templateName}.hbs`,
        "utf8"
    );

    const pageTemplate = Handlebars.compile(pageHtml); // Compile HTML 
    const body = pageTemplate(data);

    // Compile layout
    const layoutHtml = await fs.readFile(
        "./templates/layouts/layout.hbs",
        "utf8"
    );

    const layoutTemplate = Handlebars.compile(layoutHtml);

    return layoutTemplate({
        ...data,
        body
    });
}

export default compile;