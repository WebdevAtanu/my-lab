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


// Create client
const client = new userPackage.UserService(
  "localhost:50051",
  grpc.credentials.createInsecure()
);


// Call GetUser
client.GetUser(
  {
    id: 1
  },
  (error, response) => {

    if (error) {
      console.error("Error:", error);
      return;
    }

    console.log("User:", response);
  }
);

client.CreateUser(
  {
    name: "John",
    email: "john@example.com"
  },
  (error, response) => {

    if (error) {
      console.error("Error:", error);
      return;
    }

    console.log("Created:", response);
  }
);