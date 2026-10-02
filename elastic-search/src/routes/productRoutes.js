const express = require("express");
const controller = require("../controllers/productController");

const router = express.Router();

router.post("/", controller.createProduct);
router.get("/search", controller.searchProducts);
router.get("/:id", controller.getProduct);
router.delete("/:id", controller.deleteProduct);

module.exports = router;
