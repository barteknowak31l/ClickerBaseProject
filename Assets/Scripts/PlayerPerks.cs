using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerks : MonoBehaviour,IDataPersistence
{
    public PlayerStats player;

    public double PERK_COST_MULTIPLIER;

    [Range(0,0.16f)]
    public float PERK_COST_REDUCTION;

    //perki - liczba posiadanych perkow danego typu, koszt perka
    [SerializeField]
    public int DPC_PERKS;
    [SerializeField]
    public double DPC_PERK_COST;
    public double DPC_PERK_COST_MULT;
    [SerializeField]
    public int DPS_PERKS;
    [SerializeField]
    public double DPS_PERK_COST;
    public double DPS_PERK_COST_MULT;
    [SerializeField]
    public int HP_PERKS;
    [SerializeField]
    public double HP_PERK_COST;
    public double HP_PERK_COST_MULT;
    [SerializeField]
    public int ARMOR_PERKS;
    public int MAX_ARMOR_PERKS;
    public float MAX_ARMOR_VALUE;
    [SerializeField]
    public double ARMOR_PERK_COST;
    public double ARMOR_PERK_COST_MULT;
    [SerializeField]
    public int ARMOR_PEN_PERKS;
    [SerializeField]
    public double ARMOR_PEN_PERK_COST;
    public double ARMOR_PEN_PERK_COST_MULT;

    public double costStaticDiv = 20;
    public double logBase = 23;
    public double goldDropCostDivider=2;

    void Start()
    {
        //wczytaj liczbe posiadanych perkow z save
        initPerks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initPerks()
    {
        //DPC_PERKS = 1;
        //calculateDPC();


        //DPS_PERKS = 1;
        //calculateDPS();


        //HP_PERKS = 1;
        //calculateHP();


        //ARMOR_PERKS = 1;
        //calculateARMOR();



        ARMOR_PEN_PERKS = 1;
        ARMOR_PEN_PERK_COST = 1;
    }

    public void calculateDPC()
    {

        calculateDPCcost();


        double mult = 5f;

        if (DPC_PERKS > 100)
        {
            mult = 8f;
        }
        else if (DPC_PERKS > 200)
        {
            mult = 20f;
        }
        else if (DPC_PERKS > 300)
        {
            mult = 60f;
        }
        else if (DPC_PERKS > 400)
        {
            mult = 100f;
        }
        else if (DPC_PERKS > 500)
        {
            mult = 150f;
        }
        else if (DPC_PERKS > 600)
        {
            mult = 300f;
        }
        else if(DPC_PERKS >700)
        {
            mult = 500f;
        }
        else if(DPC_PERKS > 800)
        {
            mult = 800f;
        }
        else if(DPC_PERKS>900)
        {
            mult = 1000f;
        }
        else if(DPC_PERKS > 1000)
        {
            mult = 1200f;
        }

        player.PERK_DPC = 500 + mult * DPC_PERKS * DPC_PERKS + mult * DPC_PERKS / 2f;


    }
    public double DPC_formula(int lvl)
    {
        double mult = 5f;

        if (lvl > 100)
        {
            mult = 8f;
        }
        else if (lvl > 200)
        {
            mult = 20f;
        }
        else if (lvl > 300)
        {
            mult = 60f;
        }
        else if (lvl > 400)
        {
            mult = 100f;
        }
        else if (lvl > 500)
        {
            mult = 150f;
        }
        else if (lvl > 600)
        {
            mult = 300f;
        }
        else if (lvl > 700)
        {
            mult = 500f;
        }
        else if (lvl > 800)
        {
            mult = 800f;
        }
        else if (lvl > 900)
        {
            mult = 1000f;
        }
        else if (lvl > 1000)
        {
            mult = 1200f;
        }

        return (500 + mult * lvl * lvl + mult * lvl / 2f)*System.Math.Pow(10,player.RESET_POINTS_DPC);
    }

    public void calculateDPS()
    {
        calculateDPScost();
        /*
                if (DPS_PERKS <= 140)
                {
                    player.PERK_DPS = System.Math.Ceiling(10 * (DPS_PERKS - 1 + System.Math.Pow(1.55f, DPS_PERKS - 1)));
                }
                else if (DPS_PERKS > 140 && DPS_PERKS <= 500)
                {
                    player.PERK_DPS = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, DPS_PERKS - 140)));
                }
                else if (DPS_PERKS > 500 && DPS_PERKS <= 200000)
                {
                    double product = 1;
                    for (int i = 501; i < DPS_PERKS; i++)
                    {
                        product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
                    }

                    player.PERK_DPS = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * product));


                }
                else
                {
                    player.PERK_DPS = System.Math.Ceiling(System.Math.Pow(1.545f, DPS_PERKS - 200001) * 1.240f * System.Math.Pow(10, 25409) + (DPS_PERKS - 1) * 10);
                }*/


        double mult = 5f;

        if (DPS_PERKS > 100)
        {
            mult = 8f;
        }
        else if (DPS_PERKS > 200)
        {
            mult = 20f;
        }
        else if (DPS_PERKS > 300)
        {
            mult = 60f;
        }
        else if (DPS_PERKS > 400)
        {
            mult = 100f;
        }
        else if (DPS_PERKS > 500)
        {
            mult = 150f;
        }
        else if (DPS_PERKS > 600)
        {
            mult = 300f;
        }
        else if (DPS_PERKS > 700)
        {
            mult = 500f;
        }
        else if (DPS_PERKS > 800)
        {
            mult = 800f;
        }
        else if (DPS_PERKS > 900)
        {
            mult = 1000f;
        }
        else if (DPS_PERKS > 1000)
        {
            mult = 1200f;
        }

        player.PERK_DPS = 500 + mult * DPS_PERKS * DPS_PERKS + mult * DPS_PERKS / 2f;

    }


    public void calculateHP()
    {

        calculateHPcost();

        /*        if (HP_PERKS <= 140)
                {
                    player.PERK_HP = System.Math.Ceiling(10 * (HP_PERKS - 1 + System.Math.Pow(1.55f, HP_PERKS - 1)));
                }
                else if (HP_PERKS > 140 && HP_PERKS <= 500)
                {
                    player.PERK_HP = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, HP_PERKS - 140)));
                }
                else if (HP_PERKS > 500 && HP_PERKS <= 200000)
                {
                    double product = 1;
                    for (int i = 501; i < HP_PERKS; i++)
                    {
                        product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
                    }

                    player.PERK_HP = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * product));


                }
                else
                {
                    player.PERK_HP = System.Math.Ceiling(System.Math.Pow(1.545f, HP_PERKS - 200001) * 1.240f * System.Math.Pow(10, 25409) + (HP_PERKS - 1) * 10);
                }*/


        double mult = 5f;

        if (HP_PERKS > 100)
        {
            mult = 10f;
        }
        else if (HP_PERKS > 200)
        {
            mult = 40f;
        }
        else if (HP_PERKS > 300)
        {
            mult = 60f;
        }
        else if (HP_PERKS > 400)
        {
            mult = 100f;
        }
        else if (HP_PERKS > 500)
        {
            mult = 200f;
        }
        else if (HP_PERKS > 600)
        {
            mult = 400f;
        }
        else if (HP_PERKS > 700)
        {
            mult = 800f;
        }
        else if (HP_PERKS > 800)
        {
            mult = 1600f;
        }
        else if (HP_PERKS > 900)
        {
            mult = 3200f;
        }
        else if (HP_PERKS > 1000)
        {
            mult = 6400f;
        }

        player.PERK_HP = 500 + mult * HP_PERKS * HP_PERKS + mult * HP_PERKS / 2f;


    }

    public void calculateARMOR()
    {
        calculateARRMORcost();

        //old version - doesnt work with modifying dmg taken by player
        /*        if (ARMOR_PERKS <= 140)
                {
                    player.PERK_ARMOR = System.Math.Ceiling(10 * (ARMOR_PERKS - 1 + System.Math.Pow(1.55f, ARMOR_PERKS - 1)));
                }
                else if (ARMOR_PERKS > 140 && ARMOR_PERKS <= 500)
                {
                    player.PERK_ARMOR = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, ARMOR_PERKS - 140)));
                }
                else if (ARMOR_PERKS > 500 && ARMOR_PERKS <= 200000)
                {
                    double product = 1;
                    for (int i = 501; i < ARMOR_PERKS; i++)
                    {
                        product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
                    }

                    player.PERK_ARMOR = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * product));


                }
                else
                {
                    player.PERK_ARMOR = System.Math.Ceiling(System.Math.Pow(1.545f, ARMOR_PERKS - 200001) * 1.240f * System.Math.Pow(10, 25409) + (ARMOR_PERKS - 1) * 10);
                }*/

        //doesot work well too
/*        if (ARMOR_PERKS < 75)
        {
            player.PERK_ARMOR = (basedOnEnemyHP(ARMOR_PERKS) / 15);
        }
        else
        {
            player.PERK_ARMOR = (basedOnEnemyHP(ARMOR_PERKS) / 15)* System.Math.Min(3, System.Math.Pow(1.025f, ARMOR_PERKS - 75));
        }*/

        player.PERK_ARMOR = ((float)ARMOR_PERKS / (float)MAX_ARMOR_PERKS) * MAX_ARMOR_VALUE;


    }

    public void calculateARMOR_PEN()
    {
        throw new System.NotImplementedException();
    }

    double basedOnEnemyHP(int level)
    {
        double L;

        //wielomianowe koszty

        double mult = 1000f;
        double exp = 1.12;

        L = mult *level * level + System.Math.Pow(exp, level) + 5*player.perks.DPC_formula(level) + System.Math.Ceiling((level / 100) * player.perks.DPC_formula(level));

        return L;
    }

    double basedOnEnemyHPforArmor(int level)
    {
        double L;

        //Debug.Log(level);

        if (level <= 140)
        {
            L = System.Math.Ceiling(100 * (level - 1 + System.Math.Pow(10f, level - 1)));
        }
        else if (level > 140 && level <= 500)
        {
            L = System.Math.Ceiling(10 * (210 + System.Math.Pow(3.4f, 139) * System.Math.Pow(3.4f, level - 140)));
        }
        else
        {
            L = 1;
        }

        return L;
    }

    public void calculateDPCcost()
    {

        double goldDrop = player.player.enemy.enemyGoldFormula(DPC_PERKS); 

        DPC_PERK_COST = System.Math.Max(((basedOnEnemyHP(DPC_PERKS) / costStaticDiv) * System.Math.Max(System.Math.Log(DPC_PERKS, logBase), 1) * DPC_PERK_COST_MULT * PERK_COST_MULTIPLIER),
                                             goldDrop / goldDropCostDivider);
/*        if (DPC_PERKS > 75)
        {
            DPC_PERK_COST *= 2;
        }*/


        if(player.specialPerks.PERK_COST_REDUCTION > 0)
        DPC_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);

    }


    public void calculateDPScost()
    {
        double goldDrop = player.player.enemy.enemyGoldFormula(DPS_PERKS);

        DPS_PERK_COST = System.Math.Max(((basedOnEnemyHP(DPS_PERKS) / costStaticDiv) * System.Math.Max(System.Math.Log(DPS_PERKS, logBase), 1) * DPS_PERK_COST_MULT * PERK_COST_MULTIPLIER),
                                goldDrop/ goldDropCostDivider);
/*        if (DPS_PERKS > 75)
        {
            DPS_PERK_COST *= 2;
        }*/


        if (player.specialPerks.PERK_COST_REDUCTION > 0)
            DPS_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);
    }

    public void calculateHPcost()
    {
        double goldDrop = player.player.enemy.enemyGoldFormula(HP_PERKS);

        HP_PERK_COST = System.Math.Max(((basedOnEnemyHP(HP_PERKS) / costStaticDiv) * System.Math.Max(System.Math.Log(HP_PERKS, logBase), 1) * HP_PERK_COST_MULT * PERK_COST_MULTIPLIER),
                                        goldDrop / goldDropCostDivider);
/*        if (HP_PERKS > 75)
        {
            HP_PERK_COST *= 2;
        }*/


        if (player.specialPerks.PERK_COST_REDUCTION > 0)
            HP_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);
    }

    public void calculateARRMORcost()
    {
        double goldDrop = player.player.enemy.enemyGoldFormula(ARMOR_PERKS + player.RESET_ARMOR_COST_MULT);

        ARMOR_PERK_COST = System.Math.Max(((basedOnEnemyHP(ARMOR_PERKS + player.RESET_ARMOR_COST_MULT) / costStaticDiv) * System.Math.Max(System.Math.Log(ARMOR_PERKS + player.RESET_ARMOR_COST_MULT, logBase), 1) * ARMOR_PERK_COST_MULT * PERK_COST_MULTIPLIER),
                                            goldDrop / goldDropCostDivider);
/*        if (ARMOR_PERKS > 75)
        {
            ARMOR_PERK_COST *= 3;
        }*/


        if (player.specialPerks.PERK_COST_REDUCTION > 0)
            ARMOR_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);
    }

    public void resetPerks()
    {
        DPC_PERKS = 1;
        DPS_PERKS = 1;
        HP_PERKS = 1;
        ARMOR_PERKS=1;
        

        calculateDPC();
        calculateDPS();
        calculateHP();
        calculateARMOR();
    }


    public void calculateAll()
    {
        calculateARMOR();
        calculateDPC();
        calculateDPS();
        calculateHP();
    }


    public void LoadData(GameData data)
    {
        this.DPC_PERKS = data.DPC_PERKS;
        this.DPS_PERKS = data.DPS_PERKS;
        this.HP_PERKS = data.HP_PERKS;
        this.ARMOR_PERKS = data.ARMOR_PERKS;

        calculateARMOR();
        calculateDPC();
        calculateDPS();
        calculateHP();

        player.setStats();
    }

    public void SaveData(GameData data)
    {
        calculateARMOR();
        calculateDPC();
        calculateDPS();
        calculateHP();


        data.DPC_PERKS = this.DPC_PERKS;
        data.DPS_PERKS = this.DPS_PERKS;
        data.HP_PERKS = this.HP_PERKS;
        data.ARMOR_PERKS = this.ARMOR_PERKS;


    }


    public void CaclulateCosts()
    {
        calculateDPCcost();
        calculateDPScost();
        calculateARRMORcost();
        calculateHPcost();
    }

    public void afterLoadData()
    {
        calculateAll();
    }

}


