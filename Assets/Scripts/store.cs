using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TextMeshPro
using TMPro;
using UnityEngine.UI;

public class store : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    float BaseStoreCost;
    [SerializeField]
    bool ManagerUnlocked;
    [SerializeField]
    float StoreCostMultiplier;
    [SerializeField]
    bool StoreUnlocked;
    [SerializeField]
    int StoreTimerUpgrade = 5;
    public float incomePerStore;
    bool StartTimer;
    float Timer = 4f;
    float CurrentTimer = 0f;
    
    [SerializeField]
    public int StoreCount { get; private set; }

    public float NextStoreCost => Mathf.Round(BaseStoreCost * Mathf.Pow(StoreCostMultiplier, StoreCount) * 100)/100;
    UIStore uiStore;


    // Start is called before the first frame update
    void Start()
    {
        // get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // get reference to ui store
        uiStore = transform.GetComponent<UIStore>();

        uiStore.UpdateBuyButtonText();

        if (!StoreUnlocked)
        {
            uiStore.HidePanel();
        }
        else
        {
            uiStore.ShowPanel();
        }
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
                if(!ManagerUnlocked)
                    // Turn off StartTimer
                    StartTimer = false;
                // set CurrentTimer to 0
                CurrentTimer = 0;
                // gain incomePerStore times StoreCount
                gameManager.AddBalance( incomePerStore * StoreCount );                
            }
        }
        uiStore.UpdateProgressBar(CurrentTimer / Timer);
        CheckBuyStore();
    }

    public void CheckBuyStore() {
        if (!StoreUnlocked && (gameManager.GetCurrentBalance() >= NextStoreCost*0.8f))
        {
            StoreUnlocked = true;
            // make panel visible
            uiStore.ShowPanel();
            uiStore.UpdateBuyButtonText();
        }

        if (gameManager.GetCurrentBalance() >= NextStoreCost)
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy Store";
            uiStore.UnlockBuyButtonText();
            
        }
        else
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Not Enough Money";
            uiStore.LockBuyButtonText();
        }
    }
    
    public void BuyStoreOnClick () {
        if (NextStoreCost > gameManager.GetCurrentBalance()) {
            // do nothing
        } else {
            // add 1 to StoreCount
            gameManager.AddBalance(-NextStoreCost);
            StoreCount++;
            // set the text of StoreCountText to storeCount
            uiStore.UpdateStoreCountText();

            if (StoreCount % StoreTimerUpgrade == 0) {
                Timer *= 0.9f;
            }
        }
        uiStore.UpdateBuyButtonText();
    }

    public void StoreOnClick() {
        // if !StartTimer
        if (!StartTimer && StoreUnlocked && StoreCount > 0) {
            // set StartTimer to true
            StartTimer = true;
            // set CurrentTimer to 0
            CurrentTimer = 0f;
        }
    }

}
