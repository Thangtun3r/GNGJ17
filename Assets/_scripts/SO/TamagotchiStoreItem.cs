using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [Header("Setup")]
    public TamagotchiScriptableObject data;

    [Header("UI References")]
    public Image tamaSpriteImage;
    public TMP_Text statsText;
    public TMP_Text priceText;
    public Button buyButton;

    void Start()
    {
        RefreshUI();

        buyButton.onClick.AddListener(Buy);
    }

    void RefreshUI()
    {
        if (data == null) return;

        tamaSpriteImage.sprite = data.tamaSprite;
        statsText.text = $"Produces: {data.moneyPerSecond}/sec";
        priceText.text = $"{data.price}";
    }

    void Buy()
    {
        // 1. Check money
        if (!ResourceManager.Instance.TrySpend(data.price))
        {
            Debug.Log("Not enough money to buy this Tama!");
            return;
        }

        // 2. Attempt to assign to grid
        bool success = TamaGridManager.Instance.AssignTamaToVacantSlot(data);

        if (!success)
        {
            Debug.Log("No vacant slots in the grid!");
            // Refund if needed
            ResourceManager.Instance.Add(data.price);
        }
    }
}