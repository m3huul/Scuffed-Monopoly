using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> Posi = new List<Transform>();
    public float speed;
    public float duration = 5f;
    public NavMeshAgent nav;
    public float percent;
    float journey = 0f;

    void Start()
    {

    }

    void Update()
    {
        journey = Mathf.Clamp(journey, journey, duration);

    }
    public IEnumerator Move(int Roll1, int Roll2)
    {
        int finalDestination = Roll1 + Roll2;
        
        for (int i = 1; i <= finalDestination; i++)
        {
            while (journey <= duration)
            {
                journey += speed * Time.deltaTime;
                
                //percent = journey / duration;

                nav.destination = Vector3.Lerp(Posi[i - 1].position, Posi[i].position, journey);
            }
            yield return new WaitForSeconds(2f);
            journey = 0;
        }   
    }
}
