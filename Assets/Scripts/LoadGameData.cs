using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadGameData : MonoBehaviour
{
    public TextAsset GameData;
    public GameObject StorePanel;
    public GameObject StorePrefab;

    public void Start() {
        //Invoke("LoadData", 0.1f);
        LoadData();
    }

    public void LoadData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(GameData.text);
        XmlNodeList StoreList = xmlDoc.GetElementsByTagName("Store");
        foreach(XmlNode Store in StoreList)
        {
            GameObject StoreObject = (GameObject)Instantiate(StorePrefab, StorePanel.transform);

            store storeObj = StoreObject.GetComponent<store>();

            XmlNodeList StoreDetail = Store.ChildNodes;
            foreach(XmlNode Detail in StoreDetail)
            {
                if (Detail.Name == "Name")
                {
                    storeObj.StoreName = Detail.InnerText;
                } else if (Detail.Name == "BaseStoreCost")
                {
                    storeObj.BaseStoreCost = float.Parse(Detail.InnerText);
                }
                else if (Detail.Name == "BaseStoreProfit")
                {
                    storeObj.incomePerStore = float.Parse(Detail.InnerText);
                }
                else if (Detail.Name == "StoreTimer")
                {
                    storeObj.StoreTimer = float.Parse(Detail.InnerText);
                }
                else if (Detail.Name == "StoreUnlocked")
                {
                    storeObj.StoreUnlocked = bool.Parse(Detail.InnerText);
                }        
            }

            storeObj.transform.SetParent(StorePanel.transform);
        }
    }
}
