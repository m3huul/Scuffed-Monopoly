using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InJail : BoardLocation
{
    public static InJail instance;
    protected override void AdditionalInit()
    {
        instance = this;
    }
    
    public override void PassBy(Player player)
    {
        player.isInJail = false;
    }

    public override IEnumerator LandOn(Player player)
    {
        player.isInJail = true;
        player.transform.LookAt(transform.parent.GetChild(0).transform);
        yield return null;
    }
}
