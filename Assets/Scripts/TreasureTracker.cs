using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureTracker : MonoBehaviour
{
    public int treasuresFound = 0;
    public Text hudText;

    private void Start()
    {
        UpdateHUDText();
    }

    public void FindTreasure(Treasure treasure)
    {
        treasuresFound++;
        Destroy(treasure.gameObject);
        UpdateHUDText();
    }

    private void UpdateHUDText()
    {
        hudText.text = "treasures found: " + treasuresFound;
    }
}
