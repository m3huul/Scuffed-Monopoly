using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Purchasing;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    public List<Player> players;

    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private BalanceTracker[] balanceTrackers;

    public int result;
 
    void Awake()
    {
        instance = this;
        
        players = new List<Player>();
    }

    private void Update()
    {
        
    }

    public void RegisterNewPlayer(string playerName, bool ai, Material material)
    {
        print(playerName);
        // Decide an offset vector so they don't overlap.  
        Vector3 placementOffsetVector = Vector3.zero;
        switch (players.Count)
        {
            case 1: 
                placementOffsetVector = new Vector3(.5f, 0, 0);
                break;
            
            case 2: 
                placementOffsetVector = new Vector3(-.5f, 0, 0);
                break;
            
            case 3: 
                placementOffsetVector = new Vector3(0, 0, -.5f);
                break;
        }
        
        Player newPlayer = ((GameObject)(Instantiate(playerPrefab, PassGo.instance.transform.position + placementOffsetVector, playerPrefab.transform.rotation))).GetComponent<Player>();
        
        newPlayer.SetPlayerName(playerName);

        newPlayer.SetIsAI(ai);
        newPlayer.playerColor = material;
        players.Add(newPlayer);
        
        newPlayer.Initialize();
        
        // Give this player a balance tracker.  
        BalanceTracker balanceTracker = balanceTrackers[players.Count - 1];
        balanceTracker.gameObject.SetActive(true);
        newPlayer.SetBalanceTracker(balanceTracker);
    }

    public void StartGame()
    {
        StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame()
    {
        yield return CameraController.instance.LerpToViewBoardTarget(2f); //Starts the game with the camera lerping to its main position. I takes 5 seconds to do this effect.
        
        // Simulate taking turns.  
        for (int i = 0; i < 35; i++)
        {
            foreach (Player player in players)
            {
                bool doubles = true;
                int doubleRolls = 0;
                while (doubles)
                {
                    if (!player.IsAI())
                    {
                        if (player.isInJail)
                        {
                            JailActions.JailAction choosenAction = JailActions.JailAction.UNDECIDED;
                            while(choosenAction == JailActions.JailAction.UNDECIDED)
                            {
                                yield return JailActions.Instance.GetUserInput(player.hasJailFreeCard);
                                choosenAction = JailActions.Instance.GetJailAction();

                                if(choosenAction == JailActions.JailAction.ROLL)
                                {
                                    print("rolling");
                                }
                                else if(choosenAction == JailActions.JailAction.PAY)
                                {
                                    player.AdjustBalanceBy(-50);
                                    player.isInJail = false; 
                                    print(player.name + " paid 50 to get out of jail");
                                }
                                else if(choosenAction == JailActions.JailAction.JAILFREECARD)
                                {
                                    player.hasJailFreeCard = false;
                                    player.isInJail = false;
                                    print(player.name + " used their jail free card");
                                }
                            }
                        }

                        TurnActions.UserAction chosenAction = TurnActions.UserAction.UNDECIDED;
                        while (chosenAction != TurnActions.UserAction.ROLL)
                        {
                            yield return TurnActions.instance.GetUserInput(true);
                            chosenAction = TurnActions.instance.GetChosenAction();

                            if (chosenAction == TurnActions.UserAction.ROLL)
                            {
                                Debug.Log(player.name +" rolling");
                            }
                            else if(chosenAction == TurnActions.UserAction.MORTGAGE)
                            {
                                TurnActions.UserAction action = TurnActions.UserAction.UNDECIDED;
                                while(action != TurnActions.UserAction.MORTGAGE)
                                {
                                    foreach(Ownable own in player.currentOwnables)
                                    {
                                        own.ShowUnMortgagedProperty();
                                    }

                                    yield return TurnActions.instance.GetUserInputMortgage(player);
                                    action = TurnActions.instance.GetChosenActionnMortgage();

                                    if(action == TurnActions.UserAction.MORTGAGE)
                                    {
                                        foreach(Ownable own in player.currentOwnables)
                                        {
                                            own.reset();
                                        }
                                    }
                                }
                            }
                            else
                            {                               
                                Debug.LogError("Not implemented >:(");
                                yield return new WaitForSeconds(2);
                                
                            }
                        }
                    }
                    else
                    {
                        if (player.isInJail)
                        {
                            player.isInJail = false;  
                            //Ai logic if hes in jail
                        }
                    }


                    // Roll dies.  
                    yield return DieRoller.instance.RollDie();
                    int[] dieRollResults = DieRoller.instance.GetDieRollResults();

                    // Too many doubles 
                    if (dieRollResults.Length != dieRollResults.Distinct().Count())
                    {
                        doubleRolls++;
                        
                        if (doubleRolls >= 3)
                        {
                            yield return player.JumpToSpace(InJail.instance, 1f);
                            break;
                        }
                    }
                    else
                    {
                        doubles = false;
                        if (player.isInJail)
                            break;
                    }

                    //result = dieRollResults.Sum(); 
                    yield return player.MoveSpaces( result );

                    if (player.isInJail)
                    {
                        break;
                    }
                }
                
                if (!player.IsAI())
                {
                    //yield return TurnActions.instance.GetUserInput(false);
                    TurnActions.UserAction chosenAction = TurnActions.UserAction.UNDECIDED;

                    while (chosenAction != TurnActions.UserAction.ROLL)
                    {
                        yield return TurnActions.instance.GetUserInput(false);
                        chosenAction = TurnActions.instance.GetChosenAction();

                        if (chosenAction == TurnActions.UserAction.ROLL)
                        {
                            Debug.Log(player.name + "'s turn ended");
                        }
                        else if (chosenAction == TurnActions.UserAction.MORTGAGE)
                        {
                            TurnActions.UserAction action = TurnActions.UserAction.UNDECIDED;
                            while (action != TurnActions.UserAction.MORTGAGE)
                            {
                                foreach (Ownable own in player.currentOwnables)
                                {
                                    own.ShowUnMortgagedProperty();
                                }

                                yield return TurnActions.instance.GetUserInputMortgage(player);
                                action = TurnActions.instance.GetChosenActionnMortgage();

                                if (action == TurnActions.UserAction.MORTGAGE)
                                {
                                    foreach (Ownable own in player.currentOwnables)
                                    {
                                        own.reset();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("Not implemented >:(");
                            yield return new WaitForSeconds(2);

                        }
                    }
                }
            }
        }
    }
}
