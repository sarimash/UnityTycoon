using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class store : MonoBehaviour
{

    int storeCount;


    // Start is called before the first frame update
    void Start()
    {
        storeCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void BuyStoreOnClick () {
        storeCount++;
        Debug.Log("storeCount: " + storeCount);
    }

}
