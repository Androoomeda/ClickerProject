using UnityEngine;

public class BalanceManager
{
    public int MoneyAmount { get; private set; }
    public int AmountPerClick { get; private set; }
    public int UpgradePrice { get; private set; }
    public int Level { get; private set; }

    public BalanceManager(int startAmountPerClick, int startUpgradePrice)
    {
        this.AmountPerClick = startAmountPerClick;
        this.UpgradePrice = startUpgradePrice;
        Level = 1;
        MoneyAmount = 0;
    }

    public void AddMoney() => MoneyAmount += AmountPerClick;

    public void Upgrade()
    {
        TryTakeMoney(UpgradePrice);

        ++Level;
        AmountPerClick += Mathf.FloorToInt(AmountPerClick * 0.4f);
        UpgradePrice += Mathf.FloorToInt(UpgradePrice * 0.6f);
    }

    private bool TryTakeMoney(int amount)
    {
        if (MoneyAmount >= amount)
        {
            MoneyAmount -= amount;
            return true;
        }

        return false;
    }
}
