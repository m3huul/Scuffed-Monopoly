using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameMode.PlatformState state;
    public int cardNo;

    private void Start()
    {

        for (int i = 1; i < 41; i++)
        {
            if (i == 1)
            {
                if (gameObject.transform.name == "BigPlatform " + i)
                {
                    state = GameMode.PlatformState.StartPoint;
                }
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.PurpleProperty;
                    cardNo = 0;
                }
            }
            if (i == 2)
            {
                if (gameObject.transform.name == "BigPlatform " + i)
                {
                    state = GameMode.PlatformState.Jail;
                }
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.CommunityChest;
                }
            }
            if (i == 3)
            {
                if (gameObject.transform.name == "BigPlatform " + i)
                {
                    state = GameMode.PlatformState.FreeParking;
                }
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.PurpleProperty;
                    cardNo = 1;
                }
            }
            if (i == 4)
            {
                if (gameObject.transform.name == "BigPlatform " + i)
                {
                    state = GameMode.PlatformState.GoToJail;
                }
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Pay;
                    cardNo = 0;
                }
            }
            if (i == 5)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RailRoad;
                }
            }
            if (i == 6)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.LightBlueProperty;
                    cardNo = 0;
                }
            }
            if (i == 7)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Chance;
                }
            }
            if (i == 8)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.LightBlueProperty;
                    cardNo = 1;
                }
            }
            if (i == 9)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.LightBlueProperty;
                    cardNo = 2;
                }
            }
            if (i == 10)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.PinkProperty;
                }
            }
            if (i == 11)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Pay;
                    cardNo = 1;
                }
            }
            if (i == 12)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.PinkProperty;  
                }
            }
            if (i == 13)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.PinkProperty;
                }
            }
            if (i == 14)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RailRoad;
                }
            }
            if (i == 15)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.OrangeProperty;
                }
            }
            if (i == 16)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.CommunityChest;
                }
            }
            if (i == 17)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.OrangeProperty;
                }
            }
            if (i == 18)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.OrangeProperty;
                }
            }
            if (i == 19)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RedProperty;
                }
            }
            if (i == 20)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Chance;
                }
            }
            if (i == 21)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RedProperty;
                }
            }
            if (i == 22)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RedProperty;
                }
            }
            if (i == 23)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RailRoad;
                }
            }
            if (i == 24)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.YellowProperty;
                }
            }
            if (i == 25)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.YellowProperty;
                }
            }
            if (i == 26)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Pay;
                    cardNo = 2;
                }
            }
            if (i == 27)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.YellowProperty;
                }
            }
            if (i == 28)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.GreenProperty;
                }
            }
            if (i == 29)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.GreenProperty;
                }
            }
            if (i == 30)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.CommunityChest;
                }
            }
            if (i == 31)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.GreenProperty;
                }
            }
            if (i == 32)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.RailRoad;
                }
            }
            if (i == 33)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Chance;
                }
            }
            if (i == 34)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.DarkBlueProperty;
                    cardNo = 0;
                }
            }
            if (i == 35)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.Pay;
                    cardNo = 3;
                }
            }
            if (i == 36)
            {
                if (gameObject.transform.name == "SmolPlatform " + i)
                {
                    state = GameMode.PlatformState.DarkBlueProperty;
                    cardNo = 1;
                }
            }
        }
        
    }

    public void PlatformState()
    {
        GameMode.instance.WhatToDo(state, cardNo);
    }


}
