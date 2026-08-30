# Node.js gRPC User Service

A simple **gRPC implementation using Node.js** demonstrating how a gRPC client communicates with a gRPC server using **Protocol Buffers (Protobuf)**.

The project implements a basic `UserService` with `GetUser` and `CreateUser` RPC methods.

## 🚀 Features

- Node.js gRPC server
- Node.js gRPC client
- Protocol Buffers (`.proto`)
- `GetUser` RPC method
- `CreateUser` RPC method
- Request/response handling
- gRPC error handling
- In-memory user data
- HTTP/2-based gRPC communication

## 🛠️ Technologies Used

- Node.js
- gRPC
- @grpc/grpc-js
- @grpc/proto-loader
- Protocol Buffers

## 📁 Project Structure

```text
grpc-node/
│
├── proto/
│   └── user.proto
│
├── server.js
├── client.js
├── package.json
└── README.md
```
