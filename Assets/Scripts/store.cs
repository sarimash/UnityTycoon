using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TextMeshPro
using TMPro;

public class store : MonoBehaviour
{

    float CurrentBalance;
    float BaseStoreCost;

    int storeCount;
    public GameObject StoreCountText;
    public GameObject CurrentBalanceText;
    bool StartTimer;
    public float incomePerStore;

    float Timer = 4f;
    float CurrentTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // set storeCount to 1
        storeCount = 1;
        // set current balance to $2.00
        CurrentBalance = 2.00f;
        // set BaseStoreCost to $1.00
        BaseStoreCost = 1.00f;
        // set incomePerStore to $0.50
        incomePerStore = 0.50f;
        
        // set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
        CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");

    }

    // Update is called once per frame
    void Update()
    {
        // if StartTimer is true
        if (StartTimer)
        {
            // set CurrentTimer to CurrentTimer + Time.deltaTime
            CurrentTimer += Time.deltaTime;
            // if CurrentTimer is greater than Timer
            if (CurrentTimer > Timer)
            {
                // Turn off StartTimer
                StartTimer = false;
                // set CurrentTimer to 0
                CurrentTimer = 0;
                // gain incomePerStore times storeCount
                CurrentBalance += incomePerStore * storeCount;
                // update the text of CurrentBalanceText to CurrentBalance
                CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");
                
            }
        }
    }
    
    public void BuyStoreOnClick () {
        if (BaseStoreCost > CurrentBalance) {
            // do nothing
        } else {
            // add 1 to storeCount
            storeCount++;
            // add BaseStoreCost to CurrentBalance
            CurrentBalance -= BaseStoreCost;
            // set the text of StoreCountText to storeCount
            StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
            // update CurrentBalanceText to CurrentBalance
            CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");
        }
    }

    public void StoreOnClick() {
        // if !StartTimer
        if (!StartTimer) {
            // set StartTimer to true
            StartTimer = true;
            // set CurrentTimer to 0
            CurrentTimer = 0f;
        }
    }

}
