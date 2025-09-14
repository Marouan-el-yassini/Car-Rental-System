# 🛒 Car Rental System (C# Console Application)

A **console-based Car Rental System** built in **C#** using **OOP principles**, allowing users to select a car, calculate age-based discounts, and generate a payment summary.

---

## 🎯 Features

* **User Registration:** Collects client information (name, age, client status).
* **Car Selection:** Choose between **SUV** or **Berlin** car types.
* **Age & Client Discounts:** Automatically calculates discounts based on age and client status.
* **Dynamic Pricing:** Calculates total price based on number of rental days and applied discount.
* **Detailed Payment Info:** Displays a clear summary of rental details and total amount due.
* **OOP Structure:** Includes abstract classes, inheritance, and encapsulation.

---

## 📝 Classes Overview

| Class     | Purpose                                                               |
| --------- | --------------------------------------------------------------------- |
| `Voiture` | Abstract class representing a car with model, ID, price, and methods. |
| `Berlin`  | Inherits `Voiture`; specific pricing for Berlin cars.                 |
| `Suv`     | Inherits `Voiture`; specific pricing for SUV cars.                    |
| `Client`  | Handles client info, age validation, and discount calculation.        |
| `Payment` | Handles rental payment calculation based on car type and discounts.   |

---

## 🚀 Usage

1. Run the program.
2. Enter your **name**, **age**, and whether you are an **existing client** (`true/false`).
3. Choose the **type of car**: `SUV` or `BERLIN`.
4. Select a **specific car model** from the list.
5. Enter the **number of rental days**.
6. The system will display:

   * Client info
   * Car info
   * Total payment amount after discount

Example console output:

```
Nom       : Marouan EPO
ID        : 16826Z8HYET51887Y716-i9
Âge       : 30 ans
EstClient : True
Réduction : 50%

Le montant total a payer est de : 4500
```

---

## 📦 Pricing Details

| Car Type | Base Price per Day (DH) |
| -------- | ----------------------- |
| SUV      | 200 DH                  |
| Berlin   | 300 DH                  |

**Discounts:**

* Existing client **> 25 years** → 50%
* Existing client **≤ 25 years** → 30%
* Non-clients → 0%

---

## 🔧 Technologies Used

* **C#**
* **.NET Console Application**
* **Object-Oriented Programming (OOP)**

---

## 🎨 Screenshots

**Car Selection Example:**

```
Veuillez choisir votre type de voiture : SUV ou BERLIN
Liste des SUV disponibles :
1 - Nissan
2 - Toyota
3 - Ford
4 - Honda
5 - Jeep
```

**Payment Summary:**

```
╔══════════════════════════════════╗
║          Détails Paiement        ║
╚══════════════════════════════════╝
Le montant total a payer est de : 4500
```

---

## 📌 Future Enhancements

* Add **GUI interface** with WinForms or WPF.
* Include **car availability tracking**.
* Save **rental history** to a file or database.
* Add **more car types** with dynamic pricing.

---
