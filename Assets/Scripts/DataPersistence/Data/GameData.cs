using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    //public variables to be saved

    //PlayerStats
    public double GOLD;
    public int CURRENT_LEVEL;
    public int RESURRECT_LEVEL;
    public int MAX_LEVEL;
    public int MAX_ZONE;
    public int STAGE;
    public int MAX_STAGE_REACHED;
    public bool STAGE_COMPLETED;
    public string ZONE_NAME;

    public double DPC;
    public double FLAT_DPC;
    public double PERK_DPC;
    public double COMP1_DPC;
    public double COMP2_DPC;
    public double RESET_PERKS_DPC;


    public double DPS;
    public double FLAT_DPS;
    public double PERK_DPS;
    public double COMP1_DPS;
    public double COMP2_DPS;
    public double RESET_PERKS_DPS;

    public double HP;
    public double CURRENT_HP;
    public double FLAT_HP;
    public double PERK_HP;
    public double COMP1_HP;
    public double COMP2_HP;
    public double RESET_PERKS_HP;


    public double ARMOR;
    public double FLAT_ARMOR;
    public double PERK_ARMOR;
    public double COMP1_ARMOR;
    public double COMP2_ARMOR;
    public double RESET_POINTS_ARMOR;
    public double RESET_PERKS_ARMOR;

    public double ARMOR_PEN;


    //prestige levels
    public double RESET_POINTS_DPC;
    public double RESET_POINTS_DPS;
    public double RESET_POINTS_HP;
    public double RESET_POINTS_GOLD;

    ////PlayerPerks
    public int DPC_PERKS;
    public int DPS_PERKS;
    public int HP_PERKS;
    public int ARMOR_PERKS;


    //special perks
    public int POINTS;
    public int ARMOR_PEN_PERKS;
    public int PERK_COST_REDUCTION;
    public int MERC_COST_REDUCTION;
    public int MERC_PASSIVE_BOOST;
    public int ENEMY_HP_REDUCTION;
    public int maxBossesKilled;

    //PlayerCompanion
    public int WARRIOR_LVL;
    public int MAGE_LVL;
    public int ARCHER_LVL;
    public int CLERIC_LVL;
    public int THIEF_LVL;
    public int BARD_LVL;

    public int WARRIOR_HIRED;
    public int MAGE_HIRED;
    public int ARCHER_HIRED;
    public int CLERIC_HIRED;
    public int THIEF_HIRED;
    public int BARD_HIRED;


    public int RESETS_DONE;
    public int MAX_LEVEL_REACHED;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.GOLD = 1;
        this.CURRENT_LEVEL = 1;
        this.MAX_LEVEL = 1;
        this.MAX_ZONE = 1;
        this.RESURRECT_LEVEL = 1;
        this.STAGE = 1;
        this.MAX_STAGE_REACHED = 0;
        this.STAGE_COMPLETED = false;
        this.ZONE_NAME = "Lacustria";

        this.DPC = 6;
        this.FLAT_DPC = 1;
        this.COMP1_DPC = 1;
        this.COMP2_DPC = 1;
        this.RESET_PERKS_DPC = 1;

        this.DPS = 6;
        this.FLAT_DPS = 1;
        this.PERK_DPS = 1;
        this.COMP1_DPS = 1;
        this.COMP2_DPS = 1;
        this.RESET_PERKS_DPS = 1;

        this.HP = 10;
        this.CURRENT_HP = HP;
        this.FLAT_HP = 1;
        this.PERK_HP = 1;
        this.COMP1_HP = 1;
        this.COMP2_HP = 1;
        this.RESET_PERKS_HP = 1;

        this.ARMOR = 0;
        this.FLAT_ARMOR = 0;
        this.PERK_ARMOR = 0;
        this.COMP1_ARMOR = 0;
        this.COMP2_ARMOR = 0;
        this.RESET_POINTS_ARMOR = 1;
        this.RESET_PERKS_ARMOR = 1;

        this.ARMOR_PEN = 0;


        //prestige
        this.RESET_POINTS_DPC = 1;
        this.RESET_POINTS_DPS = 1;
        this.RESET_POINTS_HP = 1;
        this.RESET_POINTS_GOLD = 0;

        //playerPersks
        this.DPC_PERKS = 1;
        this.DPS_PERKS = 1;
        this.HP_PERKS = 1;
        this.ARMOR_PERKS = 1;


        //companions
        this.WARRIOR_LVL = 0;
        this.WARRIOR_HIRED = -1;

        this.MAGE_LVL = 0;
        this.MAGE_HIRED = -1;

        this.ARCHER_LVL = 0;
        this.ARCHER_HIRED = -1;

        this.CLERIC_LVL = 0;
        this.CLERIC_HIRED = -1;

        this.THIEF_LVL = 0;
        this.THIEF_HIRED = -1;

        this.BARD_LVL = 0;
        this.BARD_HIRED = -1;


        this.RESETS_DONE = 0;
        this.MAX_LEVEL_REACHED = 1;


        //special perks
        this.POINTS=0;
        this.PERK_COST_REDUCTION=0;
        this.MERC_COST_REDUCTION=0;
        this.MERC_PASSIVE_BOOST=0;
        this.ENEMY_HP_REDUCTION=0;
        this.maxBossesKilled=0;

}
}