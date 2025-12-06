# Avalpha Technologies Commission Calculator

A simple commission calculator application with a **.NET backend** API and **React frontend**.  
Calculates commissions for Avalpha Technologies vs a competitor based on local and foreign sales.

## Features

**Backend API**

- POST `/commission` endpoint calculates commission amounts.
- CORS enabled for local React frontend.
- Basic validation and error handling.

**Frontend (React)**

- Form to input Local Sales Count, Foreign Sales Count, and Average Sale Amount.
- Displays Avalpha Technologies and competitor commission results.
- Shows advantage calculation (difference in commission).

**Backend Testing**
-Unit tests written using xUnit.
-Tests cover API endpoints, input validation, and commission calculation logic.

## Getting Started

****Backend****
cd api
dotnet restore
dotnet run

****Frontend****
cd src
npm install
npm start

****Tests****
cd api
dotnet test

## Unfinished
Not added UI Tests