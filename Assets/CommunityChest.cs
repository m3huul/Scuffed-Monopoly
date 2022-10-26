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
    public Sprite RandomSprite(string LN)
    {
        if(LN == "Chance")
        {
            Sprite n = Chance[Random.Range(0, Chance.Count)];
            print(n);
            return n;
        }
        else if(LN == "Community")
        {
            Sprite s = Sprites[Random.Range(0, Sprites.Count)];
            print(s);
            return s;
        }
        return null;
    }

    public Sprite RandomChance()
    {
        Sprite s = Chance[Random.Range(0, Sprites.Count)];
        print(s);
        return s;
    }

    //print sprite details
}

