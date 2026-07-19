import puppeteer from "puppeteer";
import fs from "fs/promises";
import compile from "./pdf.service.js";
import getPaymentData from "../repositories/payment.repository.js";

export async function generatePaymentReport() {
    const data = await getPaymentData();
    const html = await compile("payment", data); // Compile HTML

    // Launch Puppeteer and generate PDF
    const browser = await puppeteer.launch({
        headless: true // Headless mode
    });

    const page = await browser.newPage(); // New page

    // Set the content of the page to the compiled HTML and wait until network is idle
    await page.setContent(html, {
        waitUntil: "networkidle0"
    });

    // Generate PDF with header and footer
    const pdf = await page.pdf({
        format: "A4", // A4 paper format
        printBackground: true, // Print background graphics
        displayHeaderFooter: true, // Display header and footer

        // Define header and footer templates
        headerTemplate: `
        <div style="font-size:10px;width:100%;text-align:center">
            My Company
        </div>
    `,

        footerTemplate: `
        <div style="font-size:10px;width:100%;text-align:center">
            Page <span class="pageNumber"></span> /
            <span class="totalPages"></span>
        </div>
    `
    });

    await browser.close();

    return pdf;
}