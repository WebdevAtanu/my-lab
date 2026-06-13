function logger(target:any, propertyKey:string, desc:PropertyDescriptor) {
    console.log("Class created:", target.name);
}

@logger
class User {
    createUser() {
        console.log("User created");
    }

    updateUser() {
        console.log("User updated");
    }
}