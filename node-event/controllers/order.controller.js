import orderService from '../services/order.service.js';

class orderController {
    
    createOrder(req, res) {
        const order = req.body; // get the order from the request body

        const createdOrder = orderService.createOrder(order); // create the order using the order service, which will emit an event
        
        res.status(201).json(createdOrder); // return the created order as a response with status 201 (Created)
    }
}

export default new orderController;