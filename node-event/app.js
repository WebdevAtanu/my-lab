import express from 'express';
import orderRoutes from './routes/order.route.js';
import emailService from './services/email.service.js';
import inventoryService from './services/inventory.service.js';
import eventBus from './eventBus.js';

const app = express();

app.use(express.json());
app.use('/api/orders', orderRoutes);

app.get('/', (req, res) => {
    res.send('Server is running');
});

// Listen for order events on the shared event bus
eventBus.on('order:created', (order) => {
    console.log('eventBus: order:created received', order);
    inventoryService.updateInventory(order.productId, order.quantity);
    emailService.sendEmail(order.email, 'Order confirmation', `Your order for ${order.quantity} ${order.productId} has been placed successfully.`);
});

export default app;