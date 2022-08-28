using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    GameObject StartButton;
    GameObject QuitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        // cache the text component of the start button
        StartButton = GameObject.Find("Menu_StartButton");
        // cache the text component of the quit button
        QuitButton = GameObject.Find("Menu_QuitButton");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
