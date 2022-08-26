using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject CurrentBalanceText;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //cache the text component of the current balance text
        CurrentBalanceText = GameObject.Find("CurrentBalanceText").gameObject;
        //get reference to game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBalanceText(float CurrentBalance)
    {
        CurrentBalanceText.GetComponent<TextMeshProUGUI>().text = "$" + CurrentBalance.ToString("0.00");
    }

}
