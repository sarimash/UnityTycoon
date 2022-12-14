using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TextMeshPro
using TMPro;
//import UnityEngine.UI
using UnityEngine.UI;

public class store : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    public float BaseStoreCost { get; set; }
    [SerializeField]
    public bool ManagerUnlocked {get; set; }
    [SerializeField]
    public float StoreCostMultiplier;
    [SerializeField]
    public bool StoreUnlocked { get; set; }
    [SerializeField]
    int StoreStoreTimerUpgrade = 5;
    [SerializeField] 
    public float incomePerStore;
    bool StartStoreTimer;
    public float StoreTimer = 4f;
    public float CurrentStoreTimer = 0f;
    [SerializeField]
    public string StoreName { get; set; }
    [SerializeField]
    public float ManagerPrice { get; set; }
    [SerializeField]
    public string ManagerName { get; set; }
    [SerializeField]
    public bool ShowManagerPanel { get; set; }

    public float StoreProgress => CurrentStoreTimer / StoreTimer;

    [SerializeField]
    public int StoreCount { get; private set; }

    public float NextStoreCost => Mathf.Round(BaseStoreCost * Mathf.Pow(StoreCostMultiplier, StoreCount) * 100)/100;


    // Start is called before the first frame update
    void Start()
    {
        // get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ShowManagerPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if StartStoreTimer is true
        if (StartStoreTimer)
        {
            // set CurrentStoreTimer to CurrentStoreTimer + Time.deltaTime
            CurrentStoreTimer += Time.deltaTime;
            // if CurrentStoreTimer is greater than StoreTimer
            if (CurrentStoreTimer > StoreTimer)
            {
                if(!ManagerUnlocked)
                    // Turn off StartStoreTimer
                    StartStoreTimer = false;
                // set CurrentStoreTimer to 0
                CurrentStoreTimer = 0;
                // gain incomePerStore times StoreCount
                gameManager.AddBalance( incomePerStore * StoreCount );                
            }
        }
    }
    
    public void BuyStoreOnClick () {
        if (NextStoreCost > gameManager.GetCurrentBalance()) {
            // do nothing
        } else {
            // add 1 to StoreCount
            gameManager.AddBalance(-NextStoreCost);
            StoreCount++;

            if (StoreCount % StoreStoreTimerUpgrade == 0) {
                StoreTimer *= 0.9f;
            }
        }
    }

    public void StoreOnClick() {
        // if !StartStoreTimer
        if (!StartStoreTimer && StoreUnlocked && StoreCount > 0) {
            // set StartStoreTimer to true
            StartStoreTimer = true;
            // set CurrentStoreTimer to 0
            CurrentStoreTimer = 0f;
        }
    }

    public void HireManager() {
        if (ManagerUnlocked || (ManagerPrice > gameManager.GetCurrentBalance())) {
            // do nothing
        } else {
            Debug.Log(ManagerPrice);
            gameManager.AddBalance(-ManagerPrice);
            ManagerUnlocked = true;
        }
    }

}
