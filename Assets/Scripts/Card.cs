using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName ="Card")]
public class Card : ScriptableObject
{
    public new string name;

    //public string type;

    public int payAmount;

    public int purchasePrice;

    public int mortgageValue;

    public int rent;

    public int rentWithColourSet;

    public int rentWith1House;

    public int rentWith2House;

    public int rentWith3House;

    public int rentWith4House;

    public int rentWithHotel;

    public int houseCost;

    public int hotelCost;

}
