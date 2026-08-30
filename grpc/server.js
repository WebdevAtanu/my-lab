const grpc = require("@grpc/grpc-js");
const protoLoader = require("@grpc/proto-loader");

const PROTO_PATH = "./proto/user.proto";

// Load proto file
const packageDefinition = protoLoader.loadSync(PROTO_PATH, {
  keepCase: true,
  longs: String,
  enums: String,
  defaults: true,
  oneofs: true
});

// Convert proto definition into JavaScript object
const grpcObject = grpc.loadPackageDefinition(packageDefinition);

// Get service object from package
const userPackage = grpcObject.user; 


// Fake database
const users = [
  {
    id: 1,
    name: "Atanu",
    email: "atanu@example.com"
  },
  {
    id: 2,
    name: "Rahul",
    email: "rahul@example.com"
  }
];


// gRPC method to get user from fake database
function getUser(call, callback) {

  const userId = call.request.id;

  console.log("Requested user:", userId);

  const user = users.find(
    user => user.id === userId
  );

  if (!user) {
    return callback({
      code: grpc.status.NOT_FOUND,
      message: "User not found"
    });
  }

  callback(null, user);
}

// gRPC method to create user in fake database 
function createUser(call, callback) {

  const { name, email } = call.request;

  const newUser = {
    id: users.length + 1,
    name,
    email
  };

  users.push(newUser);

  console.log("Created user:", newUser);

  callback(null, newUser);
}


// Create server
const server = new grpc.Server();


// Register service
server.addService(
  userPackage.UserService.service,
  {
    GetUser: getUser,
    CreateUser: createUser
  }
);


// Start server
server.bindAsync(
  "0.0.0.0:50051",
  grpc.ServerCredentials.createInsecure(),
  (error, port) => {

    if (error) {
      console.error(error);
      return;
    }

    console.log(
      `gRPC server running on port ${port}`
    );
  }
);

