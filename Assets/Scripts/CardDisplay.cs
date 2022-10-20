using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CardDisplay : MonoBehaviour
{
    //public GameObject[] TaxTile, PinkTile, OrangeTile, RedTile, YellowTile, BlueTile, PurpleTile, WhiteTile, ChanceTile, CommunityTile;
    public int cardNo;
    public string cardType;
    public Card card;

    public TMP_Text TitleText;
    public TMP_Text TaxText;
    public TMP_Text purchasePriceText;
    public TMP_Text mortgageValueText;
    public TMP_Text rentText;
    public TMP_Text rentWithColorSetText;
    public TMP_Text rentWith1HouseText;
    public TMP_Text rentWith2HouseText;
    public TMP_Text rentWith3HouseText;
    public TMP_Text rentWith4HouseText;
    public TMP_Text rentWithHotelText;
    public TMP_Text houseCostText;
    public TMP_Text hotelCostText;





    private void Start()
    {
        TitleText.text = card.name;

        if (TaxText)
        {
            TaxText.text = "Pay $" + card.payAmount.ToString();
        }
        if (purchasePriceText)
        {
            purchasePriceText.text = card.purchasePrice.ToString();
        }
        if (mortgageValueText)
        {
            mortgageValueText.text = card.mortgageValue.ToString();
        }
        if (rentText)
        {
            rentText.text = card.rent.ToString();
        }
        if (rentWithColorSetText)
        {
            rentWithColorSetText.text = card.rentWithColourSet.ToString();
        }
        if (rentWith1HouseText)
        {
            rentWith1HouseText.text = card.rentWith1House.ToString();
        }
        if (rentWith2HouseText)
        {
            rentWith2HouseText.text = card.rentWith2House.ToString();
        }
        if (rentWith3HouseText)
        {
            rentWith3HouseText.text = card.rentWith3House.ToString();
        }
        if (rentWith4HouseText)
        {
            rentWith4HouseText.text = card.rentWith4House.ToString();
        }
        if (rentWithHotelText)
        {
            rentWithHotelText.text = card.rentWithHotel.ToString();
        }
        if (houseCostText)
        {
            houseCostText.text = card.houseCost.ToString();
        }
        if (hotelCostText)
        {
            hotelCostText.text = card.hotelCost.ToString();
        }



    }

    private void Update()
    {
        
    }
}
