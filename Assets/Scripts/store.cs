using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import TextMeshPro
using TMPro;

public class store : MonoBehaviour
{

    int storeCount;
    public GameObject StoreCountText;

    // Start is called before the first frame update
    void Start()
    {
        // set storeCount to 1
        storeCount = 1;
        // set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BuyStoreOnClick () {
        storeCount++;
        //set the text of StoreCountText to storeCount
        StoreCountText.GetComponent<TextMeshProUGUI>().text = storeCount.ToString();
    }

}
