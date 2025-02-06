using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] UIManager UIManager;

    [Header("Game Settings")]
    [SerializeField] private int StartAmountPerClick = 5;
    [SerializeField] private int StartUpgradePrice = 30;

    private BalanceManager balanceManager;

    private void Awake()
    {
        balanceManager = new BalanceManager(StartAmountPerClick, StartUpgradePrice);

        UIManager.UpdateUI(balanceManager);
        SetActiveUpgradeButton();
    }

    public void AddMoney()
    {
        balanceManager.AddMoney();
        UIManager.UpdateBalance(balanceManager.MoneyAmount);
        SetActiveUpgradeButton();
    }

    public void Upgrade()
    {
        balanceManager.Upgrade();
        UIManager.UpdateUI(balanceManager);
        SetActiveUpgradeButton();
    }

    private void SetActiveUpgradeButton()
    {
        bool isActive = balanceManager.MoneyAmount >= balanceManager.UpgradePrice;
        UIManager.SetActiveUpgradeButton(isActive);
    }
}
