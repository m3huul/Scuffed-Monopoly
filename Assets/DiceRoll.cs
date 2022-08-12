using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public int RollNo1,RollNo2;
    public PlayerMovement Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Roll()
    {
        RollNo1 = Random.Range(1, 7);
        RollNo2 = Random.Range(1, 7);
        Debug.Log(RollNo1 + " " + RollNo2);
        Player.StartCoroutine(Player.Move(RollNo1,RollNo2));
    }
}
