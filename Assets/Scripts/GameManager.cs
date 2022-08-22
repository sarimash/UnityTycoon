using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float CurrentBalance;
    public GameObject CurrentBalanceText;

    // Start is called before the first frame update
    void Start()
    {
        // set current balance to $2.00
        CurrentBalance = 2.00f;
        UpdateBalanceText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBalance(float amount)
    {
        CurrentBalance += amount;
        UpdateBalanceText();
    }

    public void UpdateBalanceText()
    {
        CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");
    }

    public float GetCurrentBalance()
    {
        return CurrentBalance;
    }
}
