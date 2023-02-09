using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Companion
{
    //wieksze obrazenia ale wolniej 
    //boost dps gracza


    public double DAMAGE;
    public double damageMultiplier;
    public float boostMultiplier;
    public float TIME_INTERVAL;



    //use this instead of start() function
    protected override void initCompanion()
    {
        COMPANION_NUMBER = player.companion.MAGE_HIRED;
        LEVEL = player.companion.MAGE_LVL;


        DAMAGE = player.DPC * damageMultiplier;
        enemy = player.player.enemy;
        StartCoroutine(action());
    }

    protected override IEnumerator action()
    {

        while (true)
        {
            if (COMPANION_NUMBER != -1 && player.player.PLAYER_DEAD == false && player.player.changingLevel == false)
            {
                //zadaj dmg przeciwnikowi
                calculateStatsValues();
                enemy.takeDMG(DAMAGE/ACTION_SPEED);
                Debug.Log("Mage just attacked for " + DAMAGE + ", "+ TIME_INTERVAL/ACTION_SPEED);
            }
            yield return new WaitForSeconds(TIME_INTERVAL/ACTION_SPEED);
        }
    }


    protected override void calculateStatsValues()
    {
        DAMAGE = player.DPC * damageMultiplier;
    }

    protected override void buffPlayer()
    {
        //apply buff based on companion level
        switch (COMPANION_NUMBER)
        {
            case 0:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                        player.COMP1_DPS = 1 + LEVEL * boostMultiplier; // lvl1 = 1% 2 = 2% ...
                    else
                        player.COMP1_DPS = 1 + LEVEL * boostMultiplier * (1 + PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                    break;
                }
            case 1:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                        player.COMP2_DPS = 1 + LEVEL * boostMultiplier; // lvl1 = 1% 2 = 2% ...
                    else
                        player.COMP2_DPS = 1 + LEVEL * boostMultiplier * (1 + PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                    break;
                }
            default:
                break;
        }
    }

    protected override void onDismiss()
    {
        switch (COMPANION_NUMBER)
        {
            case 0:
                {
                    player.COMP1_DPS = 1;
                    break;
                }
            case 1:
                {
                    player.COMP2_DPS = 1;
                    break;
                }
            default:
                break;
        }
    }

}
