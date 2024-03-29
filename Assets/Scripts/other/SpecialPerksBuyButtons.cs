using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialPerksBuyButtons : MonoBehaviour
{
    public PlayerStats stats;

    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI t3;
    public TextMeshProUGUI t4;


    private void Update()
    {
        if(stats.specialPerks.ENEMY_HP_REDUCTION >= stats.maxIridiumPerkLvl)
        {
            t1.text = "MAX";
        }
        else
        {
            t1.text = "BUY";
        }


        if (stats.specialPerks.PERK_COST_REDUCTION >= stats.maxIridiumPerkLvl)
        {
            t2.text = "MAX";
        }
        else
        {
            t2.text = "BUY";
        }

        if (stats.specialPerks.MERC_PASSIVE_BOOST >= stats.maxIridiumPerkLvl)
        {
            t3.text = "MAX";
        }
        else
        {
            t3.text = "BUY";
        }

        if (stats.specialPerks.MERC_COST_REDUCTION >= stats.maxIridiumPerkLvl)
        {
            t4.text = "MAX";
        }
        else
        {
            t4.text = "BUY";
        }

    }


}
