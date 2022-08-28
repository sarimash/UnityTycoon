using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu_Hover : MonoBehaviour
{
    [SerializeField]
    Color32 OriginalColor;
    [SerializeField]
    Color32 HoverColor;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the original color of the text
        OriginalColor = GetComponent<TextMeshProUGUI>().color;
        HoverColor = new Color32(222, 41, 22, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        GetComponent<TextMeshProUGUI>().color = HoverColor;
    }

    void OnMouseExit()
    {
        GetComponent<TextMeshProUGUI>().color = OriginalColor;
    }

    void OnMouseUp()
    {
        // Log the component name when the mouse is clicked
        if (gameObject.name == "Menu_StartButton") {
            //load scene 1
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        } else if (gameObject.name == "Menu_QuitButton") {
            //close game
            Application.Quit();
        }
    }
}
