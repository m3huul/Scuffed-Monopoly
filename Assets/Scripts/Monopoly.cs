using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Monopoly : MonoBehaviour
{
    public static Monopoly instance;

    public Action nextTurn;
    public TextMeshProUGUI rolledNo;
    public GameObject[] taxCards, purplePropertyCards, lightBluePropertyCards, propertyCards, DarkBluePropertyCards;

    public int RollNo1, RollNo2, total;
    public int whosTurn = 1;
    public int pay;
    public bool coroutineAllowed = true;

    //public enum action
    //{
    //    pay,
    //    moveAhead
    //}

    private void Awake()
    {
        instance = this;
    }

    

    public void Next /*DoAction*/(/*action action*/)
    {
        //switch (action)
        //{
        //    case action.pay:
        //        OnClickPay();
        //        break;
        //    case action.moveAhead:
        //        GameMode.instance.playerIndex++;
        //        nextTurn();
        //        print("move ahead");
        //        break;
        //}
        GameMode.instance.playerIndex++;
        nextTurn();
    }
    //public void OnClickPurchase()
    //{
    //    for(int i = 0; i < 22; i++)
    //    {
    //        if (propertyCards[i].activeInHierarchy)
    //        {
    //            pay= propertyCards[i].GetComponent<CardDisplay>().card.purchasePrice;
    //            break;
    //        }
    //    }
    //}
    //public void OnClickMortgage()
    //{
    //    for (int i = 0; i < 22; i++)
    //    {
    //        if (propertyCards[i].activeInHierarchy)
    //        {
    //            pay = propertyCards[i].GetComponent<CardDisplay>().card.mortgageValue;
    //            break;
    //        }
    //    }
    //}

    //public void OnClickBuy()
    //{
    //    for(int i = 0; i < 22; i++)
    //    {
    //        if (pay != 0)
    //        {
    //            if (propertyCards[i].activeInHierarchy)
    //            {
    //                GameMode.instance.playerMoney[GameMode.instance.playerIndex] -= pay;
    //                GameMode.instance.players[GameMode.instance.playerIndex].GetComponent<PlayerMovement>().inventory.Tiles.Add(new KeyValuePair<int, string>(propertyCards[i].GetComponent<CardDisplay>().cardNo, propertyCards[i].GetComponent<CardDisplay>().cardType));
    //                Debug.Log(GameMode.instance.players[GameMode.instance.playerIndex].GetComponent<PlayerMovement>().inventory.Tiles[0]);
    //                //propertyCards[i].GetComponent<CardDisplay>().card.propertyOwnedBy = GameMode.instance.playerIndex + 1;
    //                propertyCards[i].SetActive(false);
    //                GameMode.instance.playerIndex++;
    //                nextTurn();
    //                break;
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("select purchase or mortgage");
    //        }
    //    }
    //}

    //Testing funtion
    public void OnClickAuction()
    {
        try
        {
            for(int i=0; i < 22; i++)
            {
                if (propertyCards[i].activeInHierarchy)
                {
                    propertyCards[i].SetActive(false);
                }
            }   
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("This Was For Testin :)");
        }
        nextTurn();
    }
    

    //Tax card Function --- Player is Taxed
    //public void OnClickPay()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (taxCards[i].activeInHierarchy)
    //        {
    //            GameMode.instance.playerMoney[GameMode.instance.playerIndex] -= taxCards[i].GetComponent<CardDisplay>().card.payAmount;
    //            taxCards[i].SetActive(false);
    //            nextTurn();
    //            break;
    //        } 
    //    }
    //}

    public void Roll()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RollingDice());
        }
    }

    IEnumerator RollingDice()
    {
        coroutineAllowed = false;
        for (int i = 20; i >= 0; i--)
        {
            RollNo1 = UnityEngine.Random.Range(1, 7);
            RollNo2 = UnityEngine.Random.Range(1, 7);
            rolledNo.text = (RollNo1 + RollNo2).ToString();
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log(RollNo1 + " " + RollNo2);
        total = RollNo1 + RollNo2;
        
        GameMode.instance.MovePlayer(total);
    }




    //Turn Cards On
    public void ShowPurplePropertyCard(int n)
    {
        if (n == 0)
        {
            purplePropertyCards[n].SetActive(true);
        }
        if (n == 1)
        {
            purplePropertyCards[n].SetActive(true);
        }
    }

    public void ShowLightBluePropertyCard(int n)
    {
        if (n == 0)
        {
            lightBluePropertyCards[n].SetActive(true);
        }
        if (n == 1)
        {
            lightBluePropertyCards[n].SetActive(true);
        }
        if (n == 2)
        {
            lightBluePropertyCards[n].SetActive(true);
        }
    }

    public void ShowPayCard(int n)
    {
        if (n == 0)
        {
            taxCards[n].SetActive(true);
        }
        if (n == 1)
        {
            taxCards[n].SetActive(true);
        }
        if (n == 2)
        {
            taxCards[n].SetActive(true);
        }
        if (n == 3)
        {
            taxCards[n].SetActive(true);
        }
    }

    public void ShowDarkBlueCard(int cardNo)
    {
        if (cardNo == 0)
        {
            DarkBluePropertyCards[cardNo].SetActive(true);
        }
        if(cardNo == 1)
        {
            DarkBluePropertyCards[cardNo].SetActive(true);
        }
    }
    //Turn Cards On

}
