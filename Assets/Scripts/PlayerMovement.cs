using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public struct Inventory
    {
        public List<KeyValuePair<int, string>> Tiles;
    }

    public Animator PlayMovementAnim;
    [SerializeField] public List<Transform> Posi = new();
    //public bool moveAllowed;
    public float speed;
    public float duration;

    public float Value = 0, angle = 90;
    int count = 0;   //10 steps count
    float journey = 0f;
    int steps= 0;

    //public uiElements ui;
    public Inventory inventory;
    private bool Turn;

    private void Start()
    {
        inventory = new Inventory
        {
            Tiles = new List<KeyValuePair<int, string>>()
        };
        //inventory.Tiles.Add(new KeyValuePair<int, string>(2, "nani"));
        //Debug.Log(inventory.Tiles[0].Key);
        //inventory.Tiles.Contains("blue", 0);
        //string i = inventory.Tiles[0].Key;
    }

    private void Update()
    {
        if (Turn)
        {
            transform.DORotate(new Vector3(0f, angle, 0f), 2f);
            Turn = false;
        }
        if( angle == 360f)
        {
            angle = 0f;
        }
    }

    public void StartMove(int i)
    {
        StartCoroutine(Move(i));
    }

    public IEnumerator Move(int finalDestination)
    {
        PlayMovementAnim = GetComponentInChildren<Animator>();
        while (finalDestination>0)
        {
            steps++;
            steps %= Posi.Count;
  
            StartCoroutine(Lerping(steps));
            yield return new WaitForSeconds(2f);
            journey = 0;

            finalDestination--;
            count++;
            if(count == 10)
            {
                Turn = true;
                yield return new WaitForSeconds(1.8f);
                count = 0;
                angle += 90;
            }
        }
        Monopoly.instance.coroutineAllowed = true;
        OnReachingDestination();
        
    }

    public IEnumerator Lerping(int i)
    {
        Vector3 startingPosition = transform.position;
        while (journey <= duration)
        {
            journey += Time.deltaTime*speed;
            PlayMovementAnim.SetBool("Jump", true);
            if (journey > 0.8f)
            {
                PlayMovementAnim.SetBool("Jump", false);
            }
            transform.position = Vector3.Lerp(startingPosition, Posi[i].position, journey);

            yield return null;
        }
       
    }

    public void OnReachingDestination()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, -transform.up, out Hit))
        {
            for(int i = 0; i < 2; i++)
            {
                if (GameMode.instance.players[i].GetComponent<PlayerMovement>().inventory.Tiles.Contains(new KeyValuePair<int, string>(Hit.collider.GetComponent<Platform>().cardNo, Hit.collider.GetComponent<Platform>().state.ToString())))
                {
                    Debug.Log("a player alerady has this card");
                    break;
                }
            }
            Hit.collider.GetComponent<Platform>().PlatformState();
        }
    }

}
