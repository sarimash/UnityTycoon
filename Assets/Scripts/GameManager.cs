using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float CurrentBalance;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        // get reference to UI manager
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        // set current balance to $6.00
        CurrentBalance = 6.00f;
        uiManager.UpdateBalanceText(CurrentBalance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBalance(float amount)
    {
        CurrentBalance += amount;
        CurrentBalance = Mathf.Floor(CurrentBalance * 100) / 100;
        uiManager.UpdateBalanceText(CurrentBalance);
    }


    public float GetCurrentBalance()
    {
        return CurrentBalance;
    }
}
