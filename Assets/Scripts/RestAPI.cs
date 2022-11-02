using System;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class RestAPI : MonoBehaviour
{
    public static RestAPI Instance { get; private set; }
    public List<GameObject> properties;
    public List<String> colors;
    //List<PropertyInfo> list = new List<PropertyInfo>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(GetPropertyInfo("http://192.168.1.34:5001/property_list"));
    }
    public IEnumerator GetPropertyInfo(String Url)
    {
        UnityWebRequest request = UnityWebRequest.Get(Url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Is network Server");
        }
        else
        {
            //List<PropertyInfo> units = new List<PropertyInfo>();
            string EncryptedString = request.downloadHandler.text;
            Debug.Log("Json data" + EncryptedString);
            JSONNode jSONNode = JSON.Parse(EncryptedString);

            for (int i = 0; i < properties.Count; i++)
            {
                Property property = properties[i].GetComponent<Property>();
                property.colorName = jSONNode["data"][i]["property_name"];
                colors.Add(jSONNode["data"][i]["property_name"]);
                property.purchasePrice = jSONNode["data"][i]["price"];
                property.mortgageValue = jSONNode["data"][i]["mortgage"];
            }

            colors.Add("Brown");
            colors.Add("Brown");
            colors.Add("Yellow");
            colors.Add("Yellow");
            colors.Add("Yellow");
        }
    }
}



