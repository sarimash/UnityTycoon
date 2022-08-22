using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TextMeshPro
using TMPro;
using UnityEngine.UI;

public class store : MonoBehaviour
{
    public GameManager gameManager;
    float BaseStoreCost;

    int storeCount;
    public GameObject StoreCountText;
    public Slider StoreProgressSlider;
    bool StartTimer;
    public float incomePerStore;

    float Timer = 4f;
    float CurrentTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // set storeCount to 1
        storeCount = 1;
        // set BaseStoreCost to $1.00
        BaseStoreCost = 1.00f;
        // set incomePerStore to $0.50
        incomePerStore = 0.50f;
        
        // set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
        StoreProgressSlider.GetComponent<Slider>().value = -1;
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
                gameManager.AddBalance( incomePerStore * storeCount );                
            }
        }
        StoreProgressSlider.GetComponent<Slider>().value = CurrentTimer / Timer;

    }
    
    public void BuyStoreOnClick () {
        if (BaseStoreCost > gameManager.GetCurrentBalance()) {
            // do nothing
        } else {
            // add 1 to storeCount
            storeCount++;
            gameManager.AddBalance(-BaseStoreCost);
            // set the text of StoreCountText to storeCount
            StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
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
