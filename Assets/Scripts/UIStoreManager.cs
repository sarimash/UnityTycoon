using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStoreManager : MonoBehaviour
{
    public store Store { get; set; }
    GameObject HireButtonText;
    [SerializeField]
    TextMeshProUGUI ManagerNameLabel;
    [SerializeField]
    TextMeshProUGUI StoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        // get the BuyButton that is a child of this panel
        HireButtonText = transform.Find("HireButton").gameObject.transform.Find("ManagerHireText").gameObject;
        ManagerNameLabel.text = Store.ManagerName;

        UpdateHireButtonText();
        UpdateStoreName();

        if (!Store.StoreUnlocked)
        {
            HidePanel();
        }

    }

    void UpdateStoreName() {
        ManagerNameLabel.text = Store.ManagerName;
        StoreLabel.text = Store.StoreName + " Manager";
    }

    // Update is called once per frame
    void Update()
    {
        CheckShowManagerPanel();
        UpdateHireButtonText();

    }

    public void UpdateHireButtonText()
    {
        if (Store.ManagerUnlocked) {
            HireButtonText.GetComponent<TextMeshProUGUI>().text = "Hired!";
        } else {
        // set the text of BuyButtonText to "Buy for $" + NextStoreCost
        HireButtonText.GetComponent<TextMeshProUGUI>().text = "Hire for $" + Store.ManagerPrice;
        }
    }

    public void CheckShowManagerPanel() {
        if (!Store.ShowManagerPanel && (Store.gameManager.GetCurrentBalance() >= Store.ManagerPrice*0.8f))
        {
            Store.ShowManagerPanel = true;
            ShowPanel();
        }

        if (!Store.ManagerUnlocked && Store.gameManager.GetCurrentBalance() >= Store.ManagerPrice)
        {
            UnlockHireButtonText();
            
        }
        else
        {
            LockHireButtonText();
        }
    }

    public void ShowPanel() {
        transform.GetComponent<CanvasGroup>().alpha = 1f;
    }

    public void HidePanel() {
        transform.GetComponent<CanvasGroup>().alpha = 0f;
    }

    public void LockHireButtonText() {
        HireButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = false;
    }

    public void UnlockHireButtonText() {
        HireButtonText.transform.parent.gameObject.GetComponent<Button>().interactable = true;
    }

    public void onClickHireButton() {
        Store.HireManager();
    }
}
