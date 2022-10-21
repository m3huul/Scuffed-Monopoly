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
    public List<GameObject> allPlatforms;
    List<PropertyInfo> list = new List<PropertyInfo>();

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
            List<PropertyInfo> units = new List<PropertyInfo>();
            string EncryptedString = request.downloadHandler.text;
            Debug.Log("Json data" + EncryptedString);
            JSONNode jSONNode = JSON.Parse(EncryptedString);


            int totP = allPlatforms.Count;
            int totalProperties = jSONNode["data"].Count;
            //FindLengthOfUnitstoShow();
            foreach(GameObject ob in allPlatforms)
            {
                plat n= ob.GetComponent<plat>();
                for (int i = 0; i < 10; i++)
                {
                    n.name = jSONNode["data"][i]["property_name"];
                    n.price = jSONNode["data"][i]["price"];
                    n.rent = jSONNode["data"][i]["rent"];
                    n.house1 = jSONNode["data"][i]["house1"];
                    n.house2 = jSONNode["data"][i]["house2"];
                    n.house3 = jSONNode["data"][i]["house3"];
                    n.house4 = jSONNode["data"][i]["house4"];
                    n.price_per_house = jSONNode["data"][i]["price_per_house"];
                    n.hotel = jSONNode["data"][i]["hotel"];
                    n.mortgage = jSONNode["data"][i]["mortgage"];

                }

            }
            if (units == null)
            {
                print("units is null");

            }
            
        }
        
    }
}


public struct PropertyInfo
{
    public string propertyId;
    public string porpertyName;
    public string price;
    public string rent;
    public string house1;
    public string house2;
    public string house3;
    public string house4;
    public string housePrice;
    public string hotel;
    public string mortgage;

    public PropertyInfo(string propertyId, string propertyName, string price, string rent, string house1, string house2, string house3, string house4, string housePrice, string hotel, string mortgage)
    {
        this.propertyId = propertyId;
        this.porpertyName = propertyName;
        this.price = price;
        this.rent = rent;
        this.house1 = house1;
        this.house2 = house2;
        this.house3 = house3;
        this.house4 = house4;   
        this.housePrice = housePrice;
        this.hotel = hotel;
        this.mortgage = mortgage;
    }
}