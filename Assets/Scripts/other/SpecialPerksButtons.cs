using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialPerksButtons : MonoBehaviour
{

    public PlayerStats stats;

    public TextMeshProUGUI armor_pen_lvl;

    public TextMeshProUGUI perk_cost_red_lvl;

    public TextMeshProUGUI merc_cost_red_lvl;

    public TextMeshProUGUI merc_passive_boost_lvl;

    public TextMeshProUGUI boss_hp_red_lvl;


    public TextMeshProUGUI points;
    public TextMeshProUGUI when_next_point;




    private void Update()
    {
        points.text = "IRIDIUM: " + stats.specialPerks.POINTS.ToString();

        if(stats.maxBossesKilled==0)
        {
            when_next_point.text = "Next Iridium will be availble after beating  " + ((stats.maxBossesKilled + 1)).ToString() + "st boss      (after " + ((stats.maxBossesKilled + 1) * 30).ToString() + " level)";
        }
        else if(stats.maxBossesKilled == 1)
        {
            when_next_point.text = "Next Iridium will be availble after beating  " + ((stats.maxBossesKilled + 1)).ToString() + "nd boss      (after " + ((stats.maxBossesKilled + 1) * 30).ToString() + " level)";
        }
        else if(stats.maxBossesKilled == 2)
        {
            when_next_point.text = "Next Iridium will be availble after beating  " + ((stats.maxBossesKilled + 1)).ToString() + "rd boss      (after " + ((stats.maxBossesKilled + 1) * 30).ToString() + " level)";
        }
        else
        {
            when_next_point.text = "Next Iridium will be availble after beating  " + ((stats.maxBossesKilled + 1)).ToString() + "th boss      (after " + ((stats.maxBossesKilled + 1) * 30).ToString() + " level)";
        }

        perk_cost_red_lvl.text = stats.specialPerks.PERK_COST_REDUCTION.ToString();
        merc_cost_red_lvl.text = stats.specialPerks.MERC_COST_REDUCTION.ToString();
        merc_passive_boost_lvl.text = stats.specialPerks.MERC_PASSIVE_BOOST.ToString();
        boss_hp_red_lvl.text = stats.specialPerks.ENEMY_HP_REDUCTION.ToString();
    }

    public void ARMOR_PEN_OnClick()
    {
        if(stats.specialPerks.POINTS > 0 && stats.specialPerks.ARMOR_PEN < stats.maxIridiumPerkLvl)
        {
            Debug.Log("PLAYER BOUGHT ARMOR PEN");
            stats.specialPerks.POINTS--;
            stats.specialPerks.ARMOR_PEN++;

            //onClickRoutine();

            armor_pen_lvl.text = stats.specialPerks.ARMOR_PEN.ToString();

            //stats.specialResetStats();
        }
    }


    public void PERK_COST_REDUCTION_OnClick()
    {
        if (stats.specialPerks.POINTS > 0 && stats.specialPerks.PERK_COST_REDUCTION < stats.maxIridiumPerkLvl)
        {
            stats.specialPerks.POINTS--;
            stats.specialPerks.PERK_COST_REDUCTION++;

            perk_cost_red_lvl.text = stats.specialPerks.PERK_COST_REDUCTION.ToString();

            //stats.specialResetStats();
            //onClickRoutine();
        }
    }

    public void MERC_COST_REDUCTION_OnClick()
    {
        if (stats.specialPerks.POINTS > 0 && stats.specialPerks.MERC_COST_REDUCTION < stats.maxIridiumPerkLvl)
        {
            stats.specialPerks.POINTS--;
            stats.specialPerks.MERC_COST_REDUCTION++;

            merc_cost_red_lvl.text = stats.specialPerks.MERC_COST_REDUCTION.ToString();

            //stats.specialResetStats();
            //onClickRoutine();
        }
    }

    public void MERC_PASSIVE_BOOST_OnClick()
    {
        if (stats.specialPerks.POINTS > 0 && stats.specialPerks.MERC_PASSIVE_BOOST < stats.maxIridiumPerkLvl)
        {
            stats.specialPerks.POINTS--;
            stats.specialPerks.MERC_PASSIVE_BOOST++;


            merc_passive_boost_lvl.text = stats.specialPerks.MERC_PASSIVE_BOOST.ToString();

            //stats.specialResetStats();
            //onClickRoutine();
        }
    }

    public void BOSS_HP_REDUCTION_OnClick()
    {
        if (stats.specialPerks.POINTS > 0 && stats.specialPerks.ENEMY_HP_REDUCTION < stats.maxIridiumPerkLvl)
        {
            stats.specialPerks.POINTS--;
            stats.specialPerks.ENEMY_HP_REDUCTION++;

            boss_hp_red_lvl.text = stats.specialPerks.ENEMY_HP_REDUCTION.ToString();

            //stats.specialResetStats();
            //onClickRoutine();
        }
    }


    void onClickRoutine()
    {
        if (stats.CURRENT_LEVEL <= 30)
        {
            stats.landColor.changeColor(1);
            stats.backgroundRenderer.sprite = stats.zone1;
        }

        if (stats.CURRENT_LEVEL > 30 && stats.CURRENT_LEVEL <= 60)
        {
            stats.landColor.changeColor(2);
            stats.backgroundRenderer.sprite = stats.zone2;
        }

        if (stats.CURRENT_LEVEL > 60 && stats.CURRENT_LEVEL <= 90)
        {
            stats.landColor.changeColor(3);
            stats.backgroundRenderer.sprite = stats.zone3;
        }

        if (stats.CURRENT_LEVEL > 90 && stats.CURRENT_LEVEL <= 120)
        {
            stats.landColor.changeColor(4);
            stats.backgroundRenderer.sprite = stats.zone4;
        }

        //stats.companionAnim0.anim.Play("idle");
        //stats.companionAnim1.anim.Play("idle");
        stats.player.enemy.initializeEnemy();
    }

}
