using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    
    private TextMeshProUGUI GoldenText;

    private void Start()
    {
        GoldenText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGoldentext(PlayerInventory PInvent)
    {
        GoldenText.text = PInvent.NumberOfGolden.ToString();
    }

}
