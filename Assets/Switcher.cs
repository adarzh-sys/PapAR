using UnityEngine;
using TMPro;

public class ModelSwitcher : MonoBehaviour
{
    public GameObject[] models;
    public TextMeshProUGUI trackingLabel; // Reference to UI text

    public void ActivateModelByIndex(int index)
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == index);
        }

        if (trackingLabel != null)
        {
            trackingLabel.text = $"Tracking: M{index + 1}";
        }
    }

    public void DeactivateAll()
    {
        foreach (var model in models)
        {
            model.SetActive(false);
        }

        if (trackingLabel != null)
        {
            trackingLabel.text = "Tracking: None";
        }
    }
}
