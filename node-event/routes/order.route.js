import orderController from '../controllers/order.controller.js';
import express from 'express';
const router = express.Router();

router.post('/create', orderController .createOrder);

export default router;