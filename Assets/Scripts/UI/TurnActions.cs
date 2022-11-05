using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnActions : MonoBehaviour
{
    public static TurnActions instance;

    void Awake()
    {
        instance = this;
    }

    [SerializeField] private Text rollText;
    
    public enum UserAction {ROLL, TRADE, MORTGAGE, BUILD, UNDECIDED}
    private UserAction chosenAction = UserAction.UNDECIDED;
    private UserAction chosenActionMortgage = UserAction.UNDECIDED;
    public UserAction GetChosenAction()
    {
        return chosenAction;
    }

    public IEnumerator GetUserInput(bool enableRoll)
    {
        chosenAction = UserAction.UNDECIDED;
        
        transform.GetChild(0).gameObject.SetActive(true);
        rollText.text = enableRoll ? "ROLL" : "End Turn";

        while (chosenAction == UserAction.UNDECIDED)
            yield return null;
        
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public UserAction GetChosenActionnMortgage()
    {
        return chosenActionMortgage;
    }

    public IEnumerator GetUserInputMortgage(Player player)
    {
        chosenActionMortgage = UserAction.UNDECIDED;

        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(2).gameObject.SetActive(false);

        while (chosenActionMortgage == UserAction.UNDECIDED)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100))
                {
                    Debug.Log(hit.transform.name);
                    foreach(Ownable own in player.currentOwnables)
                    {
                        if(hit.collider.GetComponent<Ownable>() == own && own.isMortgaged == false)
                        {
                            own.isMortgaged = true;
                            own.reset();
                            player.AdjustBalanceBy(+own.mortgageValue);
                        }
                        else if(hit.collider.GetComponent<Ownable>()== own && own.isMortgaged == true)
                        {
                            own.isMortgaged = false;
                            own.ShowUnMortgagedProperty();
                            player.AdjustBalanceBy(-own.mortgageValue);
                        }
                    }
                }
            }

            yield return null;
        }
            

        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
    }

    public void Roll()
    {
        chosenAction = UserAction.ROLL;
    }

    public void Trade()
    {
        chosenAction = UserAction.TRADE;
    }

    public void Mortgage()
    {
        chosenAction = UserAction.MORTGAGE;
        chosenActionMortgage = UserAction.MORTGAGE;
    }

    public void Build()
    {
        chosenAction = UserAction.BUILD;
    }
}
