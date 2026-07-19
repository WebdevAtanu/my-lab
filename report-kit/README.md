# Payment Report Generator

This project generates a PDF payment report from data stored in a SQL Server database and serves it through a simple Express app.

## What it does

- Exposes a root endpoint at / that shows a short message.
- Generates a PDF report at /payment using Puppeteer.
- Loads data from the Users and Payments tables.
- Renders the report with Handlebars templates and a custom currency helper.

## Tech stack

- Node.js
- Express
- Handlebars
- Puppeteer
- Knex + mssql

## Prerequisites

- Node.js installed on your machine
- A running SQL Server instance
- A database named streamlit-dashboard
- The following tables available in the database:
  - Users
  - Payments

You can find the sample table definitions in [DB/table.sql](DB/table.sql).

## Installation

1. Install dependencies:
   ```bash
   npm install
   ```

2. Update the database connection details in [config/database.js](config/database.js) if your SQL Server credentials or database name differ.

3. Make sure the database and tables exist before running the app.

## Running the app

Start the development server:

```bash
npm run dev
```

Then open:

- http://localhost:3000/ for the welcome message
- http://localhost:3000/payment to generate and download the PDF report

## Project structure

- [server.js](server.js) - Express server entry point
- [services/payment.service.js](services/payment.service.js) - PDF generation workflow
- [services/pdf.service.js](services/pdf.service.js) - Handlebars template compilation
- [repositories/payment.repository.js](repositories/payment.repository.js) - SQL data fetching logic
- [templates/](templates/) - HTML and Handlebars templates for the report
- [config/database.js](config/database.js) - Database connection configuration

## Notes

The report is styled as a simple invoice-like table and shows the total payment amount formatted in Indian Rupees.
