using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    public float resource;

    [Header("UI")]
    public TMP_Text resourceText;   // Assign in Inspector

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public float Get() => resource;

    public void Add(float amount)
    {
        resource += amount;
        UpdateUI();
    }

    public bool TrySpend(float amount)
    {
        if (resource < amount) return false;

        resource -= amount;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        if (resourceText != null)
            resourceText.text = resource.ToString("0");  // no decimals
    }
}