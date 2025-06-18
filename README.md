# 💱 Currency Exchange Console Application

A .NET 9 project that simulates a simple currency exchange system. Users can create accounts, top-up PLN balances, fetch live exchange rates from the NBP API, and buy foreign currencies using a console interface.

---

## 📦 Technologies Used

- **C# / .NET 9**
- **Console Application (Frontend)**
- **Custom Logic Library (Backend)**
- **NBP API**: [api.nbp.pl](http://api.nbp.pl)
- **Project Reference (no WCF hosting)**

---

## 🧠 Features

- 🔐 Create user accounts
- 💳 Top up balance in PLN
- 🌐 Fetch current exchange rates (USD, EUR, etc.) from NBP API
- 💱 Buy foreign currencies using real-time rates
- 🧾 View current balance

---

## 📁 Project Structure
CurrencyExchangeSolution/
│
├── CurrencyExchangeBackend/       # Business logic
│   ├── ICurrencyService.cs
│   └── CurrencyService.cs
│
├── CurrencyExchangeFrontend/      # Console UI
│   └── Program.cs
│
└── README.md
---

## 🏃‍♂️ How to Run

```bash
# Navigate to frontend folder
cd CurrencyExchangeFrontend

# Run the app
dotnet run


##📸 Sample UI (Console)
=== Currency Exchange Console ===
1. Create Account
2. Top Up PLN
3. Check Balance
4. Get Exchange Rate
5. Buy Currency
6. Exit

#📬 Author

Akzhol Abdinazarov
Warsaw, Poland | 2025


