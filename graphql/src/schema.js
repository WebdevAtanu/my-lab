const { buildSchema } = require("graphql");

// Define schema
const schema = buildSchema(`
  type User {
    id: Int
    name: String
    age: Int
  }

  type Query {
    getUser(id: Int!): User
    getUsers: [User]
  }
`);

// Dummy data
const users = [
  { id: 1, name: "Atanu", age: 25 },
  { id: 2, name: "Rahul", age: 30 }
];

// Resolver
const root = {
  getUser: ({ id }) => {
    return users.find(user => user.id === id);
  },
  getUsers: () => users
};

module.exports = { schema, root };

// query
// {
//   getUser(id: 1) { name }
// }