import express from "express";

const app = express();

app.use(express.json());

app.post("/webhook", (req, res) => {
    console.log("Webhook received:");
    console.log(req.body);

    res.status(200).json({
        success: true
    });
});

app.listen(5000, () => {
    console.log("Receiver running on port 5000");
});