using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityChest : MonoBehaviour
{
    public List<Sprite> Sprites;
    public List<Sprite> Chance;


    //execute after roll
    //randomRange sprites
    //return sprite
    public KeyValuePair<int, Sprite> RandomSprite(string LN)
    {
        if(LN == "Chance")
        {
            int n = Random.Range(0, Sprites.Count);
            Sprite s = Chance[n];
            
            return new KeyValuePair<int, Sprite>(n, s);
        }
        else if(LN == "Community")
        {
            int n = Random.Range(0, Sprites.Count);
            Sprite s = Sprites[n];
            
            return new KeyValuePair<int, Sprite>(n,s);
        }
        return new KeyValuePair<int, Sprite>(0, null);
    }
}

