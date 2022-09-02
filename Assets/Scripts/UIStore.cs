using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStore : MonoBehaviour
{
    private store Store;

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
        Debug.Log(Store.StoreName);

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
    }

    void UpdateStoreName() {
        StoreNameText.text = Store.StoreName;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBuyButtonText();
        UpdateStoreCountText();
    }

    public void UpdateBuyButtonText()
    {
        // set the text of BuyButtonText to "Buy for $" + NextStoreCost
        BuyButtonText.GetComponent<TextMeshProUGUI>().text = "Buy for $" + Store.NextStoreCost;
    }

    public void UpdateProgressBar(float progress){
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
