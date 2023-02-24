using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPerks : MonoBehaviour, IDataPersistence
{
    public int POINTS;

    public int ARMOR_PEN;

    public int PERK_COST_REDUCTION;

    public int MERC_COST_REDUCTION;

    public int MERC_PASSIVE_BOOST;

    public int ENEMY_HP_REDUCTION;

    public void LoadData(GameData data)
    {
        this.POINTS = data.POINTS;
        this.ARMOR_PEN = data.ARMOR_PEN_PERKS;
        this.PERK_COST_REDUCTION = data.PERK_COST_REDUCTION;
        this.MERC_COST_REDUCTION = data.MERC_COST_REDUCTION;
        this.MERC_PASSIVE_BOOST = data.MERC_PASSIVE_BOOST;
        this.ENEMY_HP_REDUCTION = data.ENEMY_HP_REDUCTION;
    }

    public void SaveData(GameData data)
    {
        data.POINTS = this.POINTS;
        data.ARMOR_PEN_PERKS = this.ARMOR_PEN;
        data.PERK_COST_REDUCTION = this.PERK_COST_REDUCTION;
        data.MERC_COST_REDUCTION = this.MERC_COST_REDUCTION;
        data.MERC_PASSIVE_BOOST = this.MERC_PASSIVE_BOOST;
        data.ENEMY_HP_REDUCTION = this.ENEMY_HP_REDUCTION;

    }

    public void afterLoadData()
    {
        ;
    }

}
