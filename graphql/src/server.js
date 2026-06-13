const express = require("express");
const { graphqlHTTP } = require("express-graphql");
const { schema, root } = require("./schema");

const app = express();

app.use("/graphql", graphqlHTTP({
    schema: schema,
    rootValue: root,
    graphiql: true   // enables UI
}));

app.listen(4000, () => {
    console.log("Server running at http://localhost:4000/graphql");
});