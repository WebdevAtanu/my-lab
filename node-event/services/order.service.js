import eventBus from '../eventBus.js';

class OrderService {
    createOrder(order) {
        console.log(`Creating order: ${JSON.stringify(order)}`);

        const createdOrder = { id: Date.now().toString(), ...order };

        // Emit the event on the shared event bus so other modules can listen.
        eventBus.emit('order:created', createdOrder);

        return createdOrder;
    }
}

export default new OrderService();