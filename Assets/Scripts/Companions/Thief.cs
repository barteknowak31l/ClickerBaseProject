using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Companion
{
    //warrior zadaje sredni DMG po srednim czasie
    //boostuje dpc gracza

    public double STEAL_AMOUNT;
    public float stealPercentage;
    public float boostMultiplier;
    public float TIME_INTERVAL;

    //use this instead of start() function
    protected override void initCompanion()
    {
        COMPANION_NUMBER = player.companion.THIEF_HIRED;
        LEVEL = player.companion.THIEF_LVL;

        enemy = player.player.enemy;
        STEAL_AMOUNT = enemy.GOLD * stealPercentage;
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
                STEAL_AMOUNT = enemy.GOLD * stealPercentage;
                player.GOLD += STEAL_AMOUNT/ACTION_SPEED;
                Debug.Log("Thief just stole " + STEAL_AMOUNT);
            }
            yield return new WaitForSeconds(TIME_INTERVAL/ACTION_SPEED);
        }
    }

    protected override void calculateStatsValues()
    {
        buffPlayer();
    }

    protected override void buffPlayer()
    {
        //apply buff based on companion level
        switch (COMPANION_NUMBER)
        {
            case 0:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                        player.ADDITIONAL_GOLD_DROP = 1 + LEVEL * boostMultiplier; // lvl1 = 1% 2 = 2% ...
                    else
                        player.ADDITIONAL_GOLD_DROP = 1 + LEVEL * boostMultiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                    break;
                }
            case 1:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                        player.ADDITIONAL_GOLD_DROP = 1 + LEVEL * boostMultiplier; // lvl1 = 1% 2 = 2% ...
                    else
                        player.ADDITIONAL_GOLD_DROP = 1 + LEVEL * boostMultiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
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
                    player.ADDITIONAL_GOLD_DROP = 1;
                    break;
                }
            case 1:
                {
                    player.ADDITIONAL_GOLD_DROP = 1;
                    break;
                }
            default:
                break;
        }
    }
}
