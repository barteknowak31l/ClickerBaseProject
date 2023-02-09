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

        if(DPC_PERKS <=140)
        {
            player.PERK_DPC = System.Math.Ceiling(10 * (DPC_PERKS - 1 + System.Math.Pow(1.55f,DPC_PERKS-1)));
        }
        else if(DPC_PERKS > 140  && DPC_PERKS <=500)
        {
            player.PERK_DPC = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f,139) * System.Math.Pow(1.145f,DPC_PERKS - 140) ));
        }
        else if(DPC_PERKS > 500 && DPC_PERKS <= 200000)
        {
            double product = 1;
            for(int i = 501; i <DPC_PERKS; i++)
            {
                product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
            }

            player.PERK_DPC = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * (float)product) );


        }
        else
        {
            player.PERK_DPC = System.Math.Ceiling(System.Math.Pow(1.545f, DPC_PERKS - 200001) * 1.240f * System.Math.Pow(10, 25409) + (DPC_PERKS - 1) * 10);
        }

    }

    public void calculateDPS()
    {
        calculateDPScost();

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
        }
    }


    public void calculateHP()
    {

        calculateHPcost();

        if (HP_PERKS <= 140)
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
        }
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

        //Debug.Log(level);

        if (level <= 140)
        {
            L = System.Math.Ceiling(10 * (level - 1 + System.Math.Pow(1.55f, level - 1)));
        }
        else if (level > 140 && level <= 500)
        {
            L = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, level - 140)));
        }
        else if (level > 500 && level <= 200000)
        {
            double product = 1;
            for (int i = 501; i < level; i++)
            {
                product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
            }

            L = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * product));


        }
        else
        {
            L = System.Math.Ceiling(System.Math.Pow(1.545f, level - 200001) * 1.240f * System.Math.Pow(10, 25409) + (level - 1) * 10);
        }


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
        if (DPC_PERKS < 75)
        {
            DPC_PERK_COST = (basedOnEnemyHP(DPC_PERKS) / 15) * DPC_PERK_COST_MULT * PERK_COST_MULTIPLIER;
        }
        else
        {
            DPC_PERK_COST = (basedOnEnemyHP(DPC_PERKS) / 15) * DPC_PERK_COST_MULT * System.Math.Min(3, System.Math.Pow(1.025f, DPC_PERKS - 75)) * PERK_COST_MULTIPLIER;
        }

        if(player.specialPerks.PERK_COST_REDUCTION > 0)
        DPC_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);

    }


    public void calculateDPScost()
    {
        if (DPS_PERKS < 75)
        {
            DPS_PERK_COST = (basedOnEnemyHP(DPS_PERKS) / 15) * DPS_PERK_COST_MULT * PERK_COST_MULTIPLIER;
        }
        else
        {
            DPS_PERK_COST = (basedOnEnemyHP(DPS_PERKS) / 15) * DPS_PERK_COST_MULT * System.Math.Min(3, System.Math.Pow(1.025f, DPS_PERKS - 75)) * PERK_COST_MULTIPLIER;
        }

        if (player.specialPerks.PERK_COST_REDUCTION > 0)
        DPS_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);
    }

    public void calculateHPcost()
    {
        if (HP_PERKS < 75)
        {
            HP_PERK_COST = (basedOnEnemyHP(HP_PERKS) / 15) * HP_PERK_COST_MULT * PERK_COST_MULTIPLIER;
        }
        else
        {
            HP_PERK_COST = (basedOnEnemyHP(HP_PERKS) / 15) * HP_PERK_COST_MULT * System.Math.Min(3, System.Math.Pow(1.025f, HP_PERKS - 75)) * PERK_COST_MULTIPLIER;
        }
        if (player.specialPerks.PERK_COST_REDUCTION > 0)
            HP_PERK_COST *= (1 - player.specialPerks.PERK_COST_REDUCTION * PERK_COST_REDUCTION);
    }

    public void calculateARRMORcost()
    {
        if (ARMOR_PERKS < 75)
        {
            ARMOR_PERK_COST = (basedOnEnemyHPforArmor(ARMOR_PERKS) / 15) * ARMOR_PERK_COST_MULT * PERK_COST_MULTIPLIER;
        }
        else
        {
            ARMOR_PERK_COST = (basedOnEnemyHPforArmor(ARMOR_PERKS) / 15) * ARMOR_PERK_COST_MULT * System.Math.Min(3, System.Math.Pow(1.025f, ARMOR_PERKS - 75)) * PERK_COST_MULTIPLIER;
        }

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
}


