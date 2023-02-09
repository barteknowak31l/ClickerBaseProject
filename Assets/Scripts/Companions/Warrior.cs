using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Companion
{
    //warrior zadaje sredni DMG po srednim czasie
    //boostuje dpc gracza

    public double DAMAGE;
    public float damageMultiplier;
    public float boostMultiplier;
    public float TIME_INTERVAL;

    public double MAX_ARMOR_BUFF;

    
    //use this instead of start() function
    protected override void initCompanion()
    {
        COMPANION_NUMBER = player.companion.WARRIOR_HIRED;
        LEVEL = player.companion.WARRIOR_LVL;


        //wczytaj dane z save
        DAMAGE = player.DPC * damageMultiplier;

        enemy = player.player.enemy;

        StartCoroutine(action());
    }

    protected override IEnumerator action()
    {

        while(true)
        {
            if (COMPANION_NUMBER != -1 && player.player.PLAYER_DEAD == false && player.player.changingLevel == false)
            {
                //zadaj dmg przeciwnikowi
                calculateStatsValues();
                enemy.takeDMG(DAMAGE/ACTION_SPEED);
                //Debug.Log("Warrior just attacked for " + DAMAGE);
            }
            yield return new WaitForSeconds(TIME_INTERVAL/ACTION_SPEED);
        }
    }

    protected override void calculateStatsValues()
    {
        DAMAGE = player.DPC * damageMultiplier;
        buffPlayer();
    }

    protected override void buffPlayer()
    {
        //apply buff based on companion level
        switch(COMPANION_NUMBER)
        {
            case 0:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                    {
                        if (LEVEL < 1000)
                        {
                            player.COMP1_ARMOR = MAX_ARMOR_BUFF * ((float)LEVEL / player.companion.MAX_WARRIOR_LVL);
                        }
                        else
                        {
                            player.COMP1_ARMOR = MAX_ARMOR_BUFF;
                        }
                    }
                    else
                    {
                        if (LEVEL < 1000)
                        {
                            player.COMP1_ARMOR = MAX_ARMOR_BUFF * ((float)LEVEL / player.companion.MAX_WARRIOR_LVL) * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST);
                        }
                        else
                        {
                            player.COMP1_ARMOR = MAX_ARMOR_BUFF * PASSIVE_SPECIAL_BUFF;
                        }

                        if(player.COMP1_ARMOR > MAX_ARMOR_BUFF)
                        {
                            player.COMP1_ARMOR = MAX_ARMOR_BUFF;
                        }

                    }
                    break; 
                }
            case 1:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                    {
                        if (LEVEL < 1000)
                        {
                            player.COMP2_ARMOR = MAX_ARMOR_BUFF * ((float)LEVEL / player.companion.MAX_WARRIOR_LVL);
                        }
                        else
                        {
                            player.COMP2_ARMOR = MAX_ARMOR_BUFF;
                        }
                    }
                    else
                    {
                        if (LEVEL < 1000)
                        {
                            player.COMP2_ARMOR = MAX_ARMOR_BUFF * ((float)LEVEL / player.companion.MAX_WARRIOR_LVL) * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST);
                        }
                        else
                        {
                            player.COMP2_ARMOR = MAX_ARMOR_BUFF * PASSIVE_SPECIAL_BUFF;
                        }

                        if (player.COMP2_ARMOR > MAX_ARMOR_BUFF)
                        {
                            player.COMP2_ARMOR = MAX_ARMOR_BUFF;
                        }
                    }
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
                    player.COMP1_ARMOR = 0;
                    break;
                }
            case 1:
                {
                    player.COMP2_ARMOR = 0;
                    break;
                }
            default:
                break;
        }
    }

}
