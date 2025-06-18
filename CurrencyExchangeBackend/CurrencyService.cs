using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using CurrencyExchangeBackend;

public class CurrencyService : ICurrencyService
{
    private static Dictionary<string, double> userBalances = new Dictionary<string, double>();

    public string CreateAccount(string userId)
    {
        if (!userBalances.ContainsKey(userId))
        {
            userBalances[userId] = 0.0;
            return "✅ Account created.";
        }
        return "⚠️ Account already exists.";
    }

    public string TopUp(string userId, double amount)
    {
        if (!userBalances.ContainsKey(userId)) return "❌ User not found.";
        userBalances[userId] += amount;
        return $"💰 Balance updated: {userBalances[userId]} PLN";
    }

    public double GetExchangeRate(string currencyCode)
    {
        string url = $"http://api.nbp.pl/api/exchangerates/rates/A/{currencyCode}/?format=json";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            using var response = request.GetResponse();
            using var reader = new StreamReader(response.GetResponseStream());
            var json = reader.ReadToEnd();
            var data = JObject.Parse(json);
            return (double)data["rates"][0]["mid"];
        }
        catch
        {
            return -1;
        }
    }

    public string BuyCurrency(string userId, string currencyCode, double amountPLN)
    {
        if (!userBalances.ContainsKey(userId)) return "❌ User not found.";
        double rate = GetExchangeRate(currencyCode);
        if (rate <= 0) return "⚠️ Invalid currency or API error.";
        if (userBalances[userId] < amountPLN) return "❌ Insufficient funds.";

        double purchased = amountPLN / rate;
        userBalances[userId] -= amountPLN;
        return $"✅ Bought {purchased:F2} {currencyCode}. Remaining balance: {userBalances[userId]} PLN";
    }

    public string GetBalance(string userId)
    {
        if (!userBalances.ContainsKey(userId)) return "❌ User not found.";
        return $"💼 Current balance: {userBalances[userId]} PLN";
    }
}