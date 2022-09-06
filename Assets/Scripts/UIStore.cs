using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    public store Store { get; set; }

    public GameObject StoreCountText;
    public Slider StoreProgressSlider;
    GameObject BuyButtonText;
    [SerializeField]
    TextMeshProUGUI StoreNameText;
    // [SerializeField]
    // GameObject StorePanel;
    [SerializeField]
    ParticleSystem StoreParticle;

    // Start is called before the first frame update
    void Start()
    {
        Store = transform.GetComponent<store>();

        // get the BuyButton that is a child of this panel
        BuyButtonText = transform.Find("BuyButton").gameObject.transform.Find("StoreButtonBuyText").gameObject;
        // get the StoreCountText that is a child of this panel
        StoreCountText = transform.Find("StoreCountText").gameObject;
        // get the StoreProgressSlider that is a child of this panel
        StoreProgressSlider = transform.Find("StoreProgressSlider").gameObject.GetComponent<Slider>();

        // set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = Store.StoreCount.ToString();
        StoreProgressSlider.GetComponent<Slider>().value = -1;
        UpdateBuyButtonText();
        UpdateStoreName();

        if (!Store.StoreUnlocked)
        {
            HidePanel();
        }

    }

    void UpdateStoreName() {
        StoreNameText.text = Store.StoreName;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBuyButtonText();
        UpdateStoreCountText();
        UpdateProgressBar(Store.StoreProgress);
    }

    public void UpdateBuyButtonText()
    {
        // set the text of BuyButtonText to "Buy for $" + NextStoreCost
        BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy for $" + Store.NextStoreCost;
    }

    public void CheckBuyStore() {
        if (!Store.StoreUnlocked && (Store.gameManager.GetCurrentBalance() >= Store.NextStoreCost*0.8f))
        {
            Store.StoreUnlocked = true;
            // make panel visible
            ShowPanel();
        }

        if (Store.gameManager.GetCurrentBalance() >= Store.NextStoreCost)
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy Store";
            UnlockBuyButtonText();
            
        }
        else
        {
            //BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Not Enough Money";
            LockBuyButtonText();
        }
    }

    public void UpdateProgressBar(float progress){
        if(StoreProgressSlider)
            StoreProgressSlider.GetComponent<Slider>().value = progress;
    }

    public void ShowPanel() {
        transform.GetComponent<CanvasGroup>().alpha = 1f;
        StoreParticle.Play();
    }

    public void HidePanel() {
        transform.GetComponent<CanvasGroup>().alpha = 0f;
    }

    public void LockBuyButtonText() {
        BuyButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = false;
    }

    public void UnlockBuyButtonText() {
        BuyButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = true;
    }

    public void UpdateStoreCountText() {
        StoreCountText.GetComponent<TextMeshProUGUI>().text = Store.StoreCount.ToString();
    }
}
