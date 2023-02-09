using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : Companion
{

    public float BUFF_multiplier;
    public float DEBUFF_multiplier;

    public float TIME_INTERVAL;

    //use this instead of start() function
    protected override void initCompanion()
    {
        COMPANION_NUMBER = player.companion.BARD_HIRED;
        LEVEL = player.companion.BARD_LVL;

        enemy = player.player.enemy;
    }

    protected override IEnumerator action()
    {
            yield return new WaitForSeconds(TIME_INTERVAL);
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
                    {
                        player.BARD_CLICKDMG_BUFF = 1 + LEVEL * BUFF_multiplier; // lvl1 = 1% 2 = 2% ...
                        player.BARD_ENEMYDMG_DEBUFF = 1 + LEVEL * DEBUFF_multiplier; // lvl1 = 1% 2 = 2% ...
                    }
                    else
                    {
                        player.BARD_CLICKDMG_BUFF = 1 + LEVEL * BUFF_multiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                        player.BARD_ENEMYDMG_DEBUFF = 1 + LEVEL * DEBUFF_multiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                    }
                    break;
                }
            case 1:
                {
                    if (player.specialPerks.MERC_PASSIVE_BOOST == 0)
                    {
                        player.BARD_CLICKDMG_BUFF = 1 + LEVEL * BUFF_multiplier; // lvl1 = 1% 2 = 2% ...
                        player.BARD_ENEMYDMG_DEBUFF = 1 + LEVEL * DEBUFF_multiplier; // lvl1 = 1% 2 = 2% ...
                    }
                    else
                    {
                        player.BARD_CLICKDMG_BUFF = 1 + LEVEL * BUFF_multiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
                        player.BARD_ENEMYDMG_DEBUFF = 1 + LEVEL * DEBUFF_multiplier * (1 + (float)PASSIVE_SPECIAL_BUFF * player.specialPerks.MERC_PASSIVE_BOOST); // lvl1 = 1% 2 = 2% ...
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
                    player.BARD_CLICKDMG_BUFF = 1; // lvl1 = 1% 2 = 2% ...
                    player.BARD_ENEMYDMG_DEBUFF = 1; // lvl1 = 1% 2 = 2% ...
                    break;
                }
            case 1:
                {
                    player.BARD_CLICKDMG_BUFF = 1; // lvl1 = 1% 2 = 2% ...
                    player.BARD_ENEMYDMG_DEBUFF = 1; // lvl1 = 1% 2 = 2% ...
                    break;
                }
            default:
                break;
        }
    }
}
