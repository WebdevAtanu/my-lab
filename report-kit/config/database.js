import knex from "knex";

const db = knex({
  client: "mssql",
  connection: {
    server: 'localhost',
    user: 'sa',
    password: 'admin',
    database: 'streamlit-dashboard', // test database
    options: {
      encrypt: false,
      trustServerCertificate: true
    }
  },
  pool: {
    min: 2,
    max: 10
  }
});

export default db;