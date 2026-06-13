class inventoryService {
    updateInventory(productId, quantity) {
        console.log(`Updating inventory for product ${productId} with quantity ${quantity}`); // log the inventory update
    }
}

export default new inventoryService;