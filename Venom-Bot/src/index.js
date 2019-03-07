require("dotenv").config({ path: "variables.env" });

const express = require("express");
const bodyParser = require("body-parser");
const port = 5000;

const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.listen(port, () =>
  console.log(`Server started at http://localhost:${port}`)
);

const verifyWebhook = require("./verify-webhook");

app.get("/", verifyWebhook);

const messageWebhook = require("./message-webhook");

app.post("/", messageWebhook);
