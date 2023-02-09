using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Companion : MonoBehaviour
{

    //enemy to deal dmg
    protected Enemy enemy;

    //player to give companion buffs;
    protected PlayerStats player;

    public int LEVEL;
    public double LEVEL_UP_COST;
    public double LEVEL_UP_COST_MULT;

    [Range(0,0.16f)]
    public double LVL_COST_REDUCTION;

    [Range(0, 0.16f)]
    public double PASSIVE_SPECIAL_BUFF;

    //number of companion in a party;
    public int COMPANION_NUMBER;

    public float ACTION_SPEED=10;



    void Start()
    {
        COMPANION_NUMBER = -1;
        if(LVL_COST_REDUCTION == 0)
        {
            LVL_COST_REDUCTION = 0.1f;
        }
        if (PASSIVE_SPECIAL_BUFF == 0)
        {
            PASSIVE_SPECIAL_BUFF = 0.1f;
        }


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        initCompanion();
        calculateCost();



    }


    //wczytuje odpowiednie info z save
    protected abstract void initCompanion();

    //zadawanie dmg, heal... - pasywna akcja w zaleznosci od klasy
    protected abstract IEnumerator action();

    //oblicza odpowiednie statystyki na podstawie poziomu kompana    
    protected abstract void calculateStatsValues();

    //apply buffs based on calss type
    protected abstract void buffPlayer();

    public void updateStatictics()
    {
        calculateStatsValues();
    }
    public void levelUp()
    {
        LEVEL++;
        calculateStatsValues();
        calculateCost();
        buffPlayer();
    }

    public void hire(int num)
    {
        COMPANION_NUMBER = num;

       

        calculateStatsValues();
        buffPlayer();
    }

    public void dismiss()
    {
        onDismiss();
        COMPANION_NUMBER = -1;
    }

    public void calculateCost()
    {
        if (LEVEL + 1 < 75)
        {
            LEVEL_UP_COST = (basedOnEnemyHP(LEVEL + 1) / 15) * LEVEL_UP_COST_MULT;
        }
        else
        {
            LEVEL_UP_COST = (basedOnEnemyHP(LEVEL + 1) / 15) * LEVEL_UP_COST_MULT * System.Math.Min(3, System.Math.Pow(1.025f, LEVEL + 1 - 75));
        }

        if (player.specialPerks.MERC_COST_REDUCTION > 0)
            LEVEL_UP_COST *= (1 - player.specialPerks.MERC_COST_REDUCTION * LVL_COST_REDUCTION);
    }

    double basedOnEnemyHP(int level)
    {
        double L;

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

    protected abstract void onDismiss();

}
