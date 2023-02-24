using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Companion : MonoBehaviour
{

    //enemy to deal dmg
    protected Enemy enemy;

    //player to give companion buffs;
    [SerializeField]
    protected PlayerStats player;

    public int LEVEL;
    public double LEVEL_UP_COST;
    public double LEVEL_UP_COST_MULT;
    public double costStaticDiv;
    public double logBase;

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
        double goldDrop = player.player.enemy.enemyGoldFormula(LEVEL);

        LEVEL_UP_COST = System.Math.Max(((basedOnEnemyHP(LEVEL) / costStaticDiv) * System.Math.Max(System.Math.Log(LEVEL, logBase), 1) * LEVEL_UP_COST_MULT),
                                            System.Math.Max(goldDrop, goldDrop * System.Math.Log(LEVEL + 1, logBase)) * LEVEL_UP_COST_MULT);


        LEVEL_UP_COST *= LEVEL_UP_COST_MULT * System.Math.Log(LEVEL+2, 2);

        if (player.specialPerks.MERC_COST_REDUCTION > 0)
            LEVEL_UP_COST *= (1 - player.specialPerks.MERC_COST_REDUCTION * LVL_COST_REDUCTION);
    }

    double basedOnEnemyHP(int level)
    {
        double L;

        //wielomianowe koszty

        double mult = 1000f;
        double exp = 1.12;

        L = mult * level * level + System.Math.Pow(exp, level);

        return L;
    }

    protected abstract void onDismiss();

}
