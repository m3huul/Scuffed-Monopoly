using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public static Platforms instance;
    public List<GameObject> Platform;
    public GameObject propertyCard;
    public GameMode.PlatformState platformState;

    private void Awake()
    {
        instance = this;
    }

    public void stateCheck(int activeWaypoint)
    {
        platformState = Platform[activeWaypoint].GetComponent<Platform>().state;

    }

    public void ShowCard(GameMode.PlatformState state, GameObject platform) //Need to change this to get called when player lands on da platform
    {
        switch (state)
        {
            case GameMode.PlatformState.Property:
                //propertyCard.GetComponent<CardDisplay>().TitleText.text = details.GetComponent<plat>().Name;
                propertyCard.SetActive(true);
                break;
            case GameMode.PlatformState.CommunityChest:
                //details.GetComponent<CommunityChest>().RandomSprite("Community");
                break;
            case GameMode.PlatformState.Chance:
                //details.GetComponent<CommunityChest>().RandomSprite("Chance");
                break;

        }
    }
}
