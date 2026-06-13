import express from "express";
import axios from "axios";

const app = express();

app.get("/create-user", async (req, res) => {
    const payload = {
        event: "user.created",
        userId: 1,
        name: "Atanu"
    };

    try {
        await axios.post(
            "http://localhost:5000/webhook",
            payload
        );

        res.send("Webhook sent"); // Send a response to the client after the webhook is sent
    } catch (err) {
        res.status(500).send("Webhook failed");
    }
});

app.listen(3000, () => {
    console.log("Sender running on port 3000");
});