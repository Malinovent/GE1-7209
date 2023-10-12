using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    TMP_Text textComponent;
    [SerializeField] Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        textComponent.text = playerHealth.CurrentHealth.ToString();
    }
}
