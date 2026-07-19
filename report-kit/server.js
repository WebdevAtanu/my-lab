import express from "express";
import { generatePaymentReport } from "./services/payment.service.js";

const app = express();

app.get("/", (req, res) => {
    res.send(`
        <!DOCTYPE html>
        <html>
        <head>
            <title>Payment Report</title>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    margin: 40px;
                    text-align: center;
                }

                h1 {
                    color: #333;
                }

                a {
                    display: inline-block;
                    margin-top: 20px;
                    padding: 10px 20px;
                    background: #007bff;
                    color: white;
                    text-decoration: none;
                    border-radius: 5px;
                }

                a:hover {
                    background: #0056b3;
                }
            </style>
        </head>
        <body>
            <h1>Payment Report API</h1>
            <p>Click the button below to generate the PDF report.</p>

            <a href="/payment">Generate PDF</a>
        </body>
        </html>
    `);
});

// Route to generate payment report PDF
app.get("/payment", async (req, res) => {
    const pdf = await generatePaymentReport(); // Generate PDF
    res.contentType("application/pdf"); // Set content type
    res.send(pdf); // Send PDF as response
});

app.listen(3000, () => console.log("Server started on port http://localhost:3000")); // Start server on port 3000