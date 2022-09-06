using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import sprite
using UnityEngine.UI;
// import microsoft json library
using Newtonsoft.Json;

public class LoadGameDataJSON : MonoBehaviour
{
    public class StoreImport
    {
        public string Name { get; set; }
        public float BaseStoreCost { get; set; }
        public float BaseStoreProfit { get; set; }
        public float StoreTimer { get; set; }
        public bool StoreUnlocked { get; set; }
        public float StoreCostMultiplier { get; set; }
        public string Image { get; set; }
        public float ManagerPrice { get; set; }
        public string ManagerName { get; set; }
    }

    public TextAsset GameDataJSON;
    public GameObject StorePanel;
    public GameObject StorePrefab;
    public GameObject ManagerPanel;
    public GameObject ManagerPrefab;

    public void Start() {
        //Invoke("LoadData", 0.1f);
        LoadData();
    }

    public void LoadData()
    {
        // load json file GameDataJSON
        string jsonString = GameDataJSON.text;
        // convert json to array of StoreImport objects using Newtonsoft.Json
        StoreImport[] storeImport = JsonConvert.DeserializeObject<StoreImport[]>(jsonString);
        
        // loop through each store in storeImport
        foreach(StoreImport store in storeImport)
        {
            // create a new store object
            GameObject StoreObject = (GameObject)Instantiate(StorePrefab, StorePanel.transform);
            GameObject ManagerObject = (GameObject)Instantiate(ManagerPrefab, ManagerPanel.transform);
            // get reference to store script
            store storeObj = StoreObject.GetComponent<store>();
            store managerObj = ManagerObject.GetComponent<store>();
            UIStoreManager managerUI = ManagerObject.GetComponent<UIStoreManager>();
            // set store properties
            storeObj.StoreName = store.Name;
            storeObj.BaseStoreCost = store.BaseStoreCost;
            storeObj.incomePerStore = store.BaseStoreProfit;
            storeObj.StoreTimer = store.StoreTimer;
            storeObj.StoreUnlocked = store.StoreUnlocked;
            storeObj.StoreCostMultiplier = store.StoreCostMultiplier;
            storeObj.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>(store.Image);

            storeObj.ManagerPrice = store.ManagerPrice;
            storeObj.ManagerName = store.ManagerName;
            
            managerObj = storeObj;
            managerUI.Store = storeObj;

        }
    }
}
