using UnityEngine;

[CreateAssetMenu(fileName = "NewTamagotchi", menuName = "Tamagotchi/Tamagotchi Data")]
public class TamagotchiScriptableObject : ScriptableObject
{
    [Header("Stats")]
    public string tamaName = "New Tama";
    public float moneyPerSecond = 1f;

    [Header("Visuals")]
    public Sprite tamaSprite;
    [Header("Shop")]
    public int price = 10;
}
