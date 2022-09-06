using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject CurrentBalanceText;
    GameManager gameManager;

    [SerializeField]
    GameObject storePanel;
    [SerializeField]
    GameObject managerPanel;
    [SerializeField]
    GameObject settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        //cache the text component of the current balance text
        CurrentBalanceText = GameObject.Find("CurrentBalanceText").gameObject;
        //get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        UpdateBalanceText(gameManager.GetCurrentBalance());
    }

    void OnEnable() {
        //subscribe to the event
        GameManager.OnUpdateBalance += UpdateBalanceText;
    }

    void OnDisable() {
        //unsubscribe from the event
        GameManager.OnUpdateBalance -= UpdateBalanceText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(GameManager.State newState){
        //switch to the new state
        switch(newState){
            case GameManager.State.MainMenu:
                break;
            case GameManager.State.Store:
                managerPanel.SetActive(false);
                settingsPanel.SetActive(false);
                break;
            case GameManager.State.Manager:
                managerPanel.SetActive(true);
                settingsPanel.SetActive(false);
                break;
            case GameManager.State.Settings:
                managerPanel.SetActive(false);
                settingsPanel.SetActive(true);
                break;
        }
    }

    public void UpdateBalanceText(float CurrentBalance)
    {
        CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");
    }

    public void onClickManager() {
        ChangeState(GameManager.State.Manager);
    }

    public void onClickStores() {
        ChangeState(GameManager.State.Store);
    }

    public void onClickSettings() {
        ChangeState(GameManager.State.Settings);
    }

}
