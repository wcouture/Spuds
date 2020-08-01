using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManger : MonoBehaviour
{
    public float taters = 200;
    public Text tatersCount;
    public void changeFunds(float money)
    {
        taters += money;
        UpdateUI();
        Debug.Log("Money Added");
    }

    void UpdateUI()
    {
        tatersCount.text = taters.ToString();
    }
}
