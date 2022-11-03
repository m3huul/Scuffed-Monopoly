using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Property : Ownable
{
    [SerializeField] private List<Property> otherProperties;

    [Tooltip("These are cumulative, don't write total price")]
    [SerializeField] private int housePrice;
    
    [Tooltip("These are NOT cumulative, write total price")]
    [SerializeField] private int[] rentPrices = new int[6];
    
    private int currentUpgradeLevel;

    protected override int ChargePlayer()
    {
        return rentPrices[currentUpgradeLevel];
    }

    protected override bool BuildHouses(Ownable owner)
    {
        for(int i = 0; i < otherProperties.Count; i++)
        {
            if(otherProperties[i].owner != owner.owner || otherProperties[i].owner == null)
                return false;
        }
        return true;
    }
}
