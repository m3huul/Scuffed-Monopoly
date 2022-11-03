using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Ownable : BoardLocation
{   
    public Player owner;

    [SerializeField] public string propertyName;
    [SerializeField] public string colorName;
    [SerializeField] public int purchasePrice;
    [SerializeField] public int mortgageValue;
    [SerializeField] public Sprite deed;
    [SerializeField] public MeshRenderer OwnerColorIndicator;
    
    public sealed override void PassBy(Player player)
    {}

    public sealed override IEnumerator LandOn(Player player)
    {
        if (owner == null)
        {
            if (!player.IsAI())
            {
                yield return LerpCameraViewToThisLocation();
                yield return OwnablePurchaseDialog.instance.OfferPurchase(this);

                if (OwnablePurchaseDialog.instance.resultingDecision)
                {
                    player.AdjustBalanceBy(-purchasePrice);
                    player.currentOwnables.Add(this);
                    owner = player;

                    OwnerColorIndicator.material = player.playerColor;
                    OwnerColorIndicator.gameObject.SetActive(true);
                }
                else
                {
                    //TODO Auction logic here.
                }

                yield return LerpCameraViewBackToMainBoardView();
            }
            else
            {
                print("ai will choose either to buy or skip");
                yield return new WaitForSeconds(2f);

                string result = player.ai.BuyOrSkip(this);
                if (result == "buy")
                {
                    player.AdjustBalanceBy(-purchasePrice);
                    player.currentOwnables.Add(this);
                    owner = player;
                    print(result);
                }
                else if(result == "skip")
                {
                    print(result);
                }
                else
                    print(result);
            }
        }
        else
        {
            if (owner != player)
            {
                int toCharge = ChargePlayer();
                player.AdjustBalanceBy(-toCharge);
                owner.AdjustBalanceBy(toCharge);
            }
            else
            {
                if (BuildHouses(this))
                {
                    print("you can build house");
                }
                //else
                //{
                //    print("you dont have all the properties of this color");
                //}
            }
        }
    }

    protected abstract int ChargePlayer();

    protected abstract bool BuildHouses(Ownable owner);
}
