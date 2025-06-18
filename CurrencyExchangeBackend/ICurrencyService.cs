namespace CurrencyExchangeBackend
{
    public interface ICurrencyService
    {
        double GetExchangeRate(string currencyCode);
        string CreateAccount(string userId);
        string TopUp(string userId, double amount);
        string BuyCurrency(string userId, string currencyCode, double amountPLN);
        string GetBalance(string userId);
    }
}