using System.Collections.Generic;
using UnityEngine;

public class TamaGridManager : MonoBehaviour
{
    public static TamaGridManager Instance { get; private set; }

    [Header("Auto-collected Producers")]
    public List<TamagotchiProducer> producers = new List<TamagotchiProducer>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        RefreshProducers();
    }

    // Finds all active producers in the scene
    public void RefreshProducers()
    {
        producers.Clear();
        producers.AddRange(FindObjectsOfType<TamagotchiProducer>());
        Debug.Log($"TamaGridManager: found {producers.Count} producers.");
    }

    // Assign Tama to first empty producer slot
    public bool AssignTamaToVacantSlot(TamagotchiScriptableObject tamaData)
    {
        foreach (var producer in producers)
        {
            if (producer.data == null)
            {
                producer.data = tamaData;
                producer.UpdateSprite();  // <-- ADD THIS
                return true;
            }
        }

        Debug.LogError("No vacant Tama Producer slots available!");
        return false;
    }

}