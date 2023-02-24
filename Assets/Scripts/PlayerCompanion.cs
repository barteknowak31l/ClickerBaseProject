using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompanion : MonoBehaviour, IDataPersistence
{
    public PlayerStats stats;

    public Companion merc0;
    public Companion merc1;

    public Companion warrior;
    public Companion mage;
    public Companion archer;
    public Companion cleric;
    public Companion thief;
    public Companion bard;

    //COSTS
    public double WARRIOR_COST;
    public double MAGE_COST;
    public double ARCHER_COST;
    public double CLERIC_COST;
    public double THIEF_COST;
    public double BARD_COST;

    //LEVELS
    public int WARRIOR_LVL;
    public int MAGE_LVL;
    public int ARCHER_LVL;
    public int CLERIC_LVL;
    public int THIEF_LVL;
    public int BARD_LVL;

    [Header("HIRED")]
    public int WARRIOR_HIRED;
    public int MAGE_HIRED;
    public int ARCHER_HIRED;
    public int CLERIC_HIRED;
    public int THIEF_HIRED;
    public int BARD_HIRED;


    public float MAX_WARRIOR_LVL=1000f;
    public float MAX_ARCHER_LVL=1000f;



    void initData()
    {
        if(WARRIOR_HIRED == 0)
        {
            merc0 = warrior;
        }

        if(MAGE_HIRED == 0)
        {
            merc0 = mage;
        }

        if(ARCHER_HIRED == 0)
        {
            merc0 = archer;
        }

        if(CLERIC_HIRED == 0)
        {
            merc0 = cleric;
        }

        if(THIEF_HIRED == 0)
        {
            merc0 = thief;
        }
        if(BARD_HIRED == 0)
        {
            merc0 = bard;
        }

        if (WARRIOR_HIRED == 1)
        {
            merc1 = warrior;
        }

        if (MAGE_HIRED == 1)
        {
            merc1 = mage;
        }

        if (ARCHER_HIRED == 1)
        {
            merc1 = archer;
        }

        if (CLERIC_HIRED == 1)
        {
            merc1 = cleric;
        }

        if (THIEF_HIRED == 1)
        {
            merc1 = thief;
        }
        if (BARD_HIRED == 1)
        {
            merc1 = bard;
        }


        warrior.LEVEL = WARRIOR_LVL;
        warrior.COMPANION_NUMBER = WARRIOR_HIRED;
        //warrior.calculateCost();

        mage.LEVEL = MAGE_LVL;
        mage.COMPANION_NUMBER = MAGE_HIRED;
       // mage.calculateCost();

        archer.LEVEL = ARCHER_LVL;
        archer.COMPANION_NUMBER = ARCHER_HIRED;
       // archer.calculateCost();

        cleric.LEVEL = CLERIC_LVL;
        cleric.COMPANION_NUMBER = CLERIC_HIRED;
        //cleric.calculateCost();

        thief.LEVEL = THIEF_LVL;
        thief.COMPANION_NUMBER = THIEF_HIRED;
       // thief.calculateCost();

        bard.LEVEL = BARD_LVL;
        bard.COMPANION_NUMBER = BARD_HIRED;
        // bard.calculateCost();


        stats.companionAnim0.startAnimation();
        stats.companionAnim1.startAnimation();

    }

    public void hire(Companion c)
    {

        if(c.LEVEL <= 0)
        {
            return;
        }

        if (merc0 == null && merc0 != c && merc1 != c)
        {
            merc0 = c;
            merc0.hire(0);
        }
        else if (merc1 == null && merc0 != c && merc1 != c)
        {
            merc1 = c;
            merc1.hire(1);
        }

        setHired();

    }

    public void dismiss(Companion c)
    {
        if (merc0 == c)
        {
            merc0.dismiss();
            merc0 = null;
        }
        else if (merc1 == c)
        {
            merc1.dismiss();
            merc1 = null;
        }

        setHired();
    }

    public void setCosts()
    {
        WARRIOR_COST = warrior.LEVEL_UP_COST;
        MAGE_COST = mage.LEVEL_UP_COST;
        ARCHER_COST = archer.LEVEL_UP_COST;
        CLERIC_COST = cleric.LEVEL_UP_COST;
        THIEF_COST = thief.LEVEL_UP_COST;
        BARD_COST = bard.LEVEL_UP_COST;

        setLvls();
        setHired();
    }

    void setLvls()
    {
        //LEVELS
        WARRIOR_LVL = warrior.LEVEL;
        MAGE_LVL = mage.LEVEL;
        ARCHER_LVL = archer.LEVEL;
        CLERIC_LVL = cleric.LEVEL;
        THIEF_LVL = thief.LEVEL;
        BARD_LVL = bard.LEVEL;
    }

    void setHired()
    {
        WARRIOR_HIRED = warrior.COMPANION_NUMBER;
        MAGE_HIRED = mage.COMPANION_NUMBER;
        ARCHER_HIRED = archer.COMPANION_NUMBER;
        CLERIC_HIRED = cleric.COMPANION_NUMBER;
        THIEF_HIRED = thief.COMPANION_NUMBER;
        BARD_HIRED = bard.COMPANION_NUMBER;
    }

    public void updateCompanionsStatistics()
    {

        if(warrior != null)
        warrior.updateStatictics();
        
        if(mage != null)
        mage.updateStatictics();
        
        if(archer != null)
        archer.updateStatictics();

        if(cleric != null)
        cleric.updateStatictics();

        if(thief!=null)
        thief.updateStatictics();

        if(bard!=null)
        bard.updateStatictics();
    }

    public void resetCompanion()
    {
        warrior.LEVEL = 0;
        warrior.calculateCost();
        warrior.COMPANION_NUMBER = -1;
        mage.LEVEL = 0;
        mage.calculateCost();
        mage.COMPANION_NUMBER = -1;
        archer.LEVEL = 0;
        archer.calculateCost();
        archer.COMPANION_NUMBER = -1;
        cleric.LEVEL = 0;
        cleric.calculateCost();
        cleric.COMPANION_NUMBER = -1;
        thief.LEVEL = 0;
        thief.calculateCost();
        thief.COMPANION_NUMBER = -1;
        bard.LEVEL = 0;
        bard.calculateCost();
        bard.COMPANION_NUMBER = -1;
        setLvls();
        setCosts();
    }


    public void LoadData(GameData data)
    {
        this.WARRIOR_LVL = data.WARRIOR_LVL;
        this.WARRIOR_HIRED = data.WARRIOR_HIRED;

        this.ARCHER_LVL = data.ARCHER_LVL;
        this.ARCHER_HIRED = data.ARCHER_HIRED;

        this.MAGE_LVL = data.MAGE_LVL;
        this.MAGE_HIRED = data.MAGE_HIRED;

        this.CLERIC_LVL = data.CLERIC_LVL;
        this.CLERIC_HIRED = data.CLERIC_HIRED;

        this.THIEF_LVL = data.THIEF_LVL;
        this.THIEF_HIRED = data.THIEF_HIRED;

        this.BARD_LVL = data.BARD_LVL;
        this.BARD_HIRED = data.BARD_HIRED;

        initData();


    }

    public void SaveData(GameData data)
    {
        data.WARRIOR_LVL = this.WARRIOR_LVL;
        data.WARRIOR_HIRED = this.WARRIOR_HIRED;

        data.ARCHER_LVL = this.ARCHER_LVL;
        data.ARCHER_HIRED = this.ARCHER_HIRED;

        data.MAGE_LVL = this.MAGE_LVL;
        data.MAGE_HIRED = this.MAGE_HIRED;

        data.CLERIC_LVL = this.CLERIC_LVL;
        data.CLERIC_HIRED = this.CLERIC_HIRED;

        data.THIEF_LVL = this.THIEF_LVL;
        data.THIEF_HIRED = this.THIEF_HIRED;

        data.BARD_LVL = this.BARD_LVL;
        data.BARD_HIRED = this.BARD_HIRED ;
    }


    public void hireAfterLoad()
    {
    
        if(merc0 != null)
        {
            Companion c0 = merc0;
            dismiss(merc0);
            hire(c0);
        }
        if (merc1 != null)
        {
            Companion c1 = merc1;
            dismiss(merc1);
            hire(c1);
        }
    }


    public void afterLoadData()
    {
        ;
    }
}
