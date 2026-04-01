Overview

This project is a technical demonstration of a Benefit Processing System designed for government agencies. It simulates the logic used in unemployment insurance implementations, 
focusing on eligibility rules, benefit caps, and debt recovery (Clawback).

Technical Features

* Object-Oriented Programming (OOP): Utilizes Abstraction, Inheritance, and Encapsulation.

* Business Logic:

- Tiered Duration: Benefit length based on months of service.

- Capping Mechanism: Strict adherence to Minimum and Maximum legal limits.

- Debt Integration: Automatic deduction of government debts from the final payout.

* Language: VB.NET

Class Hierarchy
* BureauUser (Abstract Base): Defines core properties and shared calculation logic.

* StandardWorker: Implements duration rules for full-time employees.

* SeasonalWorker: Implements simplified rules for seasonal contract holders.
