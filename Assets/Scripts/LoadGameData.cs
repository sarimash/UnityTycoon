using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadGameData : MonoBehaviour
{
    public TextAsset GameData;

    public void Start() {
        Invoke("LoadData", 0.1f);
    }

    public void LoadData()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(GameData.text);
        XmlNodeList StoreList = xmlDoc.GetElementsByTagName("Store");
        foreach(XmlNode Store in StoreList)
        {
            XmlNodeList StoreDetail = Store.ChildNodes;
            foreach(XmlNode Detail in StoreDetail)
            {
                Debug.Log(Detail.Name);
                Debug.Log(Detail.InnerText);
            }
        }
    }
}
