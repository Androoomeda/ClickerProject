using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI BalanceText;
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI UpgradeButtonText;
    [SerializeField] private TextMeshProUGUI ClickButtonText;
    [SerializeField] private Button UpgradeButton;

    public void UpdateUI(BalanceManager balance)
    {
        LevelText.text = $"LV {balance.Level}";
        UpgradeButtonText.text = $"UPGRADE {balance.UpgradePrice}";
        ClickButtonText.text = $"+{balance.AmountPerClick}";

        UpdateBalance(balance.MoneyAmount);
    }

    public void UpdateBalance(int money)
    {
        BalanceText.text = money.ToString();
    }

    public void SetActiveUpgradeButton(bool isActive)
    {
        UpgradeButton.interactable = isActive;
    }
}
