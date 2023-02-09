using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAnimation : MonoBehaviour
{
    public int id;
    public Animator anim;

    public PlayerStats stats;
    public void setAnimation()
    {
        //pierwszy merc
        if(stats.companion.merc0 != null && id == 0)
        {
            if(stats.companion.WARRIOR_HIRED == 0)
            {
                if(stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("warrior_attack");
                }
                else
                {
                    anim.Play("warrior_run");
                }
            }


            if (stats.companion.MAGE_HIRED == 0)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("mage_attack");
                }
                else
                {
                    anim.Play("mage_run");
                }
            }



            if (stats.companion.ARCHER_HIRED == 0)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("archer_attack");
                }
                else
                {
                    anim.Play("archer_run");
                }
            }



            if (stats.companion.CLERIC_HIRED == 0)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("cleric_attack");
                }
                else
                {
                    anim.Play("cleric_run");
                }
            }


            if (stats.companion.THIEF_HIRED == 0)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("thief_attack");
                }
                else
                {
                    anim.Play("thief_run");
                }
            }


            if (stats.companion.BARD_HIRED == 0)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("bard_attack");
                }
                else
                {
                    anim.Play("bard_run");
                }
            }


        }
        //drugi merc
       else if (stats.companion.merc1 != null && id == 1)
        {
            if (stats.companion.WARRIOR_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("warrior_attack");
                }
                else
                {
                    anim.Play("warrior_run");
                }
            }


            if (stats.companion.MAGE_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("mage_attack");
                }
                else
                {
                    anim.Play("mage_run");
                }
            }



            if (stats.companion.ARCHER_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("archer_attack");
                }
                else
                {
                    anim.Play("archer_run");
                }
            }



            if (stats.companion.CLERIC_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("cleric_attack");
                }
                else
                {
                    anim.Play("cleric_run");
                }
            }


            if (stats.companion.THIEF_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("thief_attack");
                }
                else
                {
                    anim.Play("thief_run");
                }
            }


            if (stats.companion.BARD_HIRED == 1)
            {
                if (stats.player.enemy.ENEMY_IS_ALIVE)
                {
                    anim.Play("bard_attack");
                }
                else
                {
                    anim.Play("bard_run");
                }
            }


        }
        else
        {
            if(stats.companion.merc0 == null && id == 0)
            {
                anim.Play("idle");
            }

            if (stats.companion.merc1 == null && id == 1)
            {
                anim.Play("idle");
            }
        }



    }



    public void startAnimation()
    {
        //pierwszy merc
        if (stats.companion.merc0 != null && id == 0)
        {
            if (stats.companion.WARRIOR_HIRED == 0)
            {

                    anim.Play("warrior_attack");

            }


            if (stats.companion.MAGE_HIRED == 0)
            {

                    anim.Play("mage_attack");

            }



            if (stats.companion.ARCHER_HIRED == 0)
            {

                    anim.Play("archer_attack");

            }



            if (stats.companion.CLERIC_HIRED == 0)
            {

                    anim.Play("cleric_attack");

            }


            if (stats.companion.THIEF_HIRED == 0)
            {

                    anim.Play("thief_attack");

            }


            if (stats.companion.BARD_HIRED == 0)
            {

                    anim.Play("bard_attack");

            }


        }
        //drugi merc
        else if (stats.companion.merc1 != null && id == 1)
        {
            if (stats.companion.WARRIOR_HIRED == 1)
            {

                    anim.Play("warrior_attack");

            }


            if (stats.companion.MAGE_HIRED == 1)
            {

                    anim.Play("mage_attack");

            }



            if (stats.companion.ARCHER_HIRED == 1)
            {

                    anim.Play("archer_attack");


            }



            if (stats.companion.CLERIC_HIRED == 1)
            {

                    anim.Play("cleric_attack");

            }


            if (stats.companion.THIEF_HIRED == 1)
            {

                    anim.Play("thief_attack");

            }


            if (stats.companion.BARD_HIRED == 1)
            {

                    anim.Play("bard_attack");

            }


        }
        else
        {
            if (stats.companion.merc0 == null && id == 0)
            {
                anim.Play("idle");
            }

            if (stats.companion.merc1 == null && id == 1)
            {
                anim.Play("idle");
            }
        }

    }


    public void onAnimSpeedChange()
    {
        anim.speed = stats.animationSpeed;
    }


}
