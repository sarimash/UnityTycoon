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
    int storeCount;
    [SerializeField]
    bool StoreUnlocked;
    [SerializeField]
    GameObject StorePanel;
    [SerializeField]
    int StoreTimerUpgrade = 5;

    public float NextStoreCost => Mathf.Round(BaseStoreCost * Mathf.Pow(StoreCostMultiplier, storeCount) * 100)/100;

    public GameObject StoreCountText;
    public Slider StoreProgressSlider;
    bool StartTimer;
    public float incomePerStore;

    float Timer = 4f;
    float CurrentTimer = 0f;
    GameObject BuyButtonText;

    // Start is called before the first frame update
    void Start()
    {
        if(!StoreUnlocked) {
            StorePanel.GetComponent<CanvasGroup>().alpha = 0f;
        }
        // get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // get the BuyButton that is a child of this panel
        BuyButtonText = transform.Find("BuyButton").gameObject.transform.Find("StoreButtonBuyText").gameObject;

        // set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
        StoreProgressSlider.GetComponent<Slider>().value = -1;
        UpdateBuyButtonText();
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
                // gain incomePerStore times storeCount
                gameManager.AddBalance( incomePerStore * storeCount );                
            }
        }
        StoreProgressSlider.GetComponent<Slider>().value = CurrentTimer / Timer;
        CheckBuyStore();
    }

    public void CheckBuyStore() {
        if (!StoreUnlocked && (gameManager.GetCurrentBalance() >= NextStoreCost*0.8f))
        {
            StoreUnlocked = true;
            // make panel visible
            StorePanel.GetComponent<CanvasGroup>().alpha = 1f;
            UpdateBuyButtonText();
        }

        if (gameManager.GetCurrentBalance() >= NextStoreCost)
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy Store";
            BuyButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Not Enough Money";
            BuyButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    void UpdateBuyButtonText()
    {
        // set the text of BuyButtonText to "Buy for $" + NextStoreCost
        BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy for $" + NextStoreCost;
    }
    
    public void BuyStoreOnClick () {
        if (NextStoreCost > gameManager.GetCurrentBalance()) {
            // do nothing
        } else {
            // add 1 to storeCount
            gameManager.AddBalance(-NextStoreCost);
            storeCount++;
            // set the text of StoreCountText to storeCount
            StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
            if (storeCount % StoreTimerUpgrade == 0) {
                Timer *= 0.9f;
            }
        }
        UpdateBuyButtonText();
    }

    public void StoreOnClick() {
        // if !StartTimer
        if (!StartTimer && StoreUnlocked && storeCount > 0) {
            // set StartTimer to true
            StartTimer = true;
            // set CurrentTimer to 0
            CurrentTimer = 0f;
        }
    }

}
