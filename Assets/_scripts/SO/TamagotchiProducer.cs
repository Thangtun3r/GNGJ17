using UnityEngine;
using UnityEngine.UI;

public class TamagotchiProducer : MonoBehaviour
{
    public TamagotchiScriptableObject data;  // assigned via Grid Manager or Inspector

    [Header("UI Display")]
    public Image spriteImage; // assign UI Image here (in the grid slot)

    private float timer;

    void Start()
    {
        UpdateSprite();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer -= 1f;
            ProduceMoney();
        }
    }

    private void ProduceMoney()
    {
        if (data == null) return;

        ResourceManager.Instance.Add(data.moneyPerSecond);

        Debug.Log($"{data} produced {data.moneyPerSecond} money!");
    }

    // Called whenever a new Tama is assigned
    public void UpdateSprite()
    {
        if (spriteImage == null) return;

        if (data == null)
        {
            spriteImage.enabled = false; // hide if empty
        }
        else
        {
            spriteImage.enabled = true;
            spriteImage.sprite = data.tamaSprite;
        }
    }
}