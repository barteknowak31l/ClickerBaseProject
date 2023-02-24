using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using TMPro;


public class Enemy : MonoBehaviour
{
    public Player player;
    public Animator backgroundAnim;
    public ProgressBar hpBar;
    public GameObject hpBg;

    [SerializeField] // current hp
    public double healthPoints;    
    public double HP;
    public int LEVEL;

    [Header("balance stats")]
    public double DAMAGE_MULTIPLIER;
    public double DAMAGE_DIVIDER;
    public double GOLD_MULTIPLIER;
    public double GOLD_DIVIDER;
    public double GOLD_STATIC_DIVIDER = 15;
    public double BOSS_HP_MULT;
    public double IRIDIUM_HP_REDUCTION;
    public double HP_EXP = 1.15f;
    public double HP_DIVIDER = 1.5f;
    [Header("")]

    public double DAMAGE;

    public double ARMOR;
    public double ARMOR_BASE;
    public double ARMOR_MAX;
    public double ARMOR_EXP;
    public double ARMOR_MULT;

    public double ARMOR_PEN;

    public double GOLD ;


    public double STAGE_MULT;

    public bool isBoss;



    public float TIME_INTERVAL;
    public int ACTION_SPEED;

    public bool ENEMY_IS_ALIVE;

    public string ENEMY_NAME;


    Animator anim;
    SpriteRenderer spriteRenderer;

    bool enemyIsAttacking;


    Vector3 regularPos;
    Vector3 regularScale;

    Vector3 bossPos;
    Vector3 bossScale;


    public GameObject DmgDealtText;

    EnemyNamesSystem names;

    int type;

    private void Start()
    {
        anim = GetComponent<Animator>();
        names = GetComponent<EnemyNamesSystem>();

        anim.speed = player.stats.animationSpeed;
        backgroundAnim.speed = player.stats.animationSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        enemyIsAttacking = false;

        LEVEL = player.stats.getEnemyLevel();
        isBoss = (LEVEL % 30 == 0);


        //anim.Play("idle");

        //start applying DPS



        regularPos = new Vector3(5.84f,-2.25f,0f);
        regularScale = new Vector3(1.245872f, 1.245872f, 1.245872f);

        bossPos = new Vector3(5.84f, -1.6f, 0f);
        bossScale = new Vector3(2.1533f, 2.1533f, 2.1533f);


        StartCoroutine(attack());
        initializeEnemy();

    }


    public void initializeEnemy()
    {

        type = Random.Range(0, 17);


        LEVEL = player.stats.getEnemyLevel();
        isBoss = (LEVEL % 30 == 0);

        spriteRenderer.enabled = true;
        //set stats based on current lvl (1-120) and stage (strefa,wymiar) - fields currentLevel and stage in PlayerStats
        setStats();

        if(isBoss)
        {
            transform.position = bossPos;
            transform.localScale = bossScale;
        }
        else
        {
            transform.position = regularPos;
            transform.localScale = regularScale;
        }


        //show enemy on screen and start animation when ready
        //anim.Play("idle");
        playIdle();
    }

    IEnumerator attack()
    {
        while(true)
        {
            if(ENEMY_IS_ALIVE)
            {
                enemyIsAttacking = true;
                //anim.Play("attack");
                playAttack();

                player.takeDMG(DAMAGE / ACTION_SPEED);
                //Debug.Log("ENEMY: just attacked player for " + DAMAGE);
            }
            yield return new WaitForSeconds(TIME_INTERVAL/ ACTION_SPEED);
        }
    }

    void endOfAttackAnim()
    {
        enemyIsAttacking = false;
    }

    public void takeDMG(double d)
    {
        if(ENEMY_IS_ALIVE == false || GameManager.Instance.isInMenu)
        {
            return;
        }


        var go = Instantiate(DmgDealtText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-"+GameManager.Instance.formatScientific(d);
        



        if(enemyIsAttacking == false)
        {
            //anim.Play("hurt");
            //playHurt();
        }

        //temporary - there will be a formula that includes armorpen and armor stats
        healthPoints -= calculateTakenDMG(d);
        hpBar.current = healthPoints;

        if(healthPoints <=0)
        {
            onEnemyDeath();
        }

    }

    double calculateTakenDMG(double d)
    { 
        calculateARMOR();
        return d * (1 - ARMOR);
    }


    public void setAlive()
    {
        if(ENEMY_IS_ALIVE == false)
        {
            resetEnemy();
        }
    }

    public void onEnemyDeath()
    {
        //anim.Play("die");
        playDie();

        player.stats.fullHeal();


        if(isBoss)
        {
            player.stats.afterBossKilled();
        }


        ENEMY_IS_ALIVE = false;

        backgroundAnim.Play("transition");
        //resetEnemy(); wykonuje sie na koniec animacji transition
        player.stats.incrementLvl();
        player.onLevelChange();
        hpBg.SetActive(false);
        hpBar.gameObject.SetActive(false);
        dropGold();
        
    }

    void endOfDieAnim()
    {
        //spriteRenderer.enabled = false;
        resetEnemy();
    }

    public void resetEnemy()
    {
        initializeEnemy();
        player.stopRunning();

        hpBar.gameObject.SetActive(true);
        hpBg.SetActive(true);
        backgroundAnim.Play("idle");
    }

    void setStats()
    {

        //temporary - tu bedzie funkcja losujaca tworzaca losowa nazwe enemy
        ENEMY_NAME = names.randomName();//"The Obsidian Colossus of Eternal Flames";

        //set stats based on level and stage/ formulas to be added
        calculateHP();
        healthPoints = HP;

        calculateDamage();

        ARMOR = 1;
        ARMOR_PEN = 1;

        calculateGold();

        TIME_INTERVAL = 1;


        ENEMY_IS_ALIVE = true;

        hpBar.max = HP;
        hpBar.current = HP;
    }

    void dropGold()
    {
        player.stats.GOLD += GOLD * player.stats.ADDITIONAL_GOLD_DROP;

        if(player.stats.GOLD > GameManager.Instance.biggestNumber)
        {
            player.stats.GOLD = GameManager.Instance.biggestNumber;
        }

    }


    void calculateHP()
    {
        HP =  1000f*player.stats.getEnemyLevel()*player.stats.getEnemyLevel() + 5*player.stats.DPC + System.Math.Ceiling((player.stats.getEnemyLevel()/100)*player.stats.DPC)  + System.Math.Pow(HP_EXP, player.stats.getEnemyLevel());

        if (isBoss)
        {
            HP *= BOSS_HP_MULT;
        }

        if(player.stats.specialPerks.ENEMY_HP_REDUCTION>0)
        HP = HP * (1 - player.stats.specialPerks.ENEMY_HP_REDUCTION *IRIDIUM_HP_REDUCTION);

        HP = HP / HP_DIVIDER;

        if (HP > GameManager.Instance.biggestNumber)
        {
            HP = GameManager.Instance.biggestNumber;
        }


    }

    void calculateGold()
    {

        /*        double exp = player.stats.RESET_POINTS_GOLD;

                GOLD = ((HP / GOLD_STATIC_DIVIDER) * GOLD_MULTIPLIER / GOLD_DIVIDER) * System.Math.Pow(10, exp);

                if (player.stats.getEnemyLevel() > 75)
                {
                    GOLD *= 3;
                }*/

        GOLD = enemyGoldFormula(player.stats.getEnemyLevel());


    }

    public double enemyGoldFormula(int lvl)
    {
        double exp = player.stats.RESET_POINTS_GOLD;
        double hp = 1000f * lvl * lvl + 5 * player.stats.perks.DPC_formula(lvl) + System.Math.Ceiling((lvl / 100) * player.stats.perks.DPC_formula(lvl)) + System.Math.Pow(1.2, lvl);
       
        if (player.stats.specialPerks.ENEMY_HP_REDUCTION > 0)
            hp = hp * player.stats.specialPerks.ENEMY_HP_REDUCTION * IRIDIUM_HP_REDUCTION;

        double gold = ((hp / GOLD_STATIC_DIVIDER) * GOLD_MULTIPLIER / GOLD_DIVIDER) * System.Math.Pow(10, exp);

        if (lvl>75)
        {
            gold *= 3;
        }


        if (gold > GameManager.Instance.biggestNumber)
        {
            gold = GameManager.Instance.biggestNumber;
        }

        return gold;
    }

    void calculateDamage()
    {



        double mult = 10f;

        int lvl = player.stats.getEnemyLevel();

        if (lvl > 120)
        {
            mult = 20f;
        }
        else if (lvl > 240)
        {
            mult = 80f;
        }
        else if (lvl > 360)
        {
            mult = 160f;
        }
        else if (lvl > 480)
        {
            mult = 320f;
        }
        else if (lvl > 600)
        {
            mult = 640f;
        }
        else if (lvl > 720)
        {
            mult = 1280f;
        }
        else if (lvl > 840)
        {
            mult = 3840f;
        }
        else if (lvl > 960)
        {
            mult = 11520f;
        }
        else if (lvl > 1080)
        {
            mult = 34560f;
        }
        else if (lvl > 1200)
        {
            mult = 103680f;
        }
        else if (lvl > 1320)
        {
            mult = 311040f;
        }
        else if (lvl > 1440)
        {
            mult = 933120f;
        }
        else if (lvl > 1560)
        {
            mult = 2799360f;
        }
        else if (lvl > 1660)
        {
            mult = 8398080f;
        }
        else if (lvl > 1800)
        {
            mult = 25194240f;
        }
        else if (lvl > 1920)
        {
            mult = 75582720f;
        }
        else if (lvl > 2040)
        {
            mult = 226748160f;
        }
        else if (lvl > 2160)
        {
            mult = 680244480f;
        }
        else if (lvl > 2280)
        {
            mult = 2040733440f;
        }
        else if (lvl > 2400)
        {
            mult = 6122200320f;
        }


        DAMAGE = 10 + (System.Math.Pow(lvl, 2f)*mult)* DAMAGE_MULTIPLIER/ DAMAGE_DIVIDER;

        DAMAGE = System.Math.Max(DAMAGE, player.stats.getMaxHP()/30);


        if (DAMAGE > GameManager.Instance.biggestNumber)
        {
            DAMAGE = GameManager.Instance.biggestNumber;
        }


    }

    void calculateARMOR()
    {
        double x = (player.stats.getEnemyLevel() / (player.stats.MAXIMUM_STAGE * 120f));
        ARMOR =  System.Math.Clamp(( ARMOR_BASE + System.Math.Pow(x,ARMOR_EXP) - player.stats.ARMOR_PEN ) * ARMOR_MULT, ARMOR_BASE,  ARMOR_MAX);
    }

    public void onAnimSpeedChange()
    {
        anim.speed = player.stats.animationSpeed;
        backgroundAnim.speed = player.stats.animationSpeed;

    }


    void playIdle()
    {
        switch(type)
        {
            case 0:
                {
                    anim.Play("idle");
                    break;
                }
            case 1:
                {
                    anim.Play("idle1");
                    break;
                }
            case 2:
                {
                    anim.Play("idle2");
                    break;
                }
            case 3:
                {
                    anim.Play("idle3");
                    break;
                }
            case 4:
                {
                    anim.Play("idle4");
                    break;
                }
            case 5:
                {
                    anim.Play("idle5");
                    break;
                }
            case 6:
                {
                    anim.Play("idle6");
                    break;
                }
            case 7:
                {
                    anim.Play("idle7");
                    break;
                }
            case 8:
                {
                    anim.Play("idle8");
                    break;
                }
            case 9:
                {
                    anim.Play("idle9");
                    break;
                }
            case 10:
                {
                    anim.Play("idle10");
                    break;
                }
            case 11:
                {
                    anim.Play("idle11");
                    break;
                }
            case 12:
                {
                    anim.Play("idle12");
                    break;
                }
            case 13:
                {
                    anim.Play("idle13");
                    break;
                }
            case 14:
                {
                    anim.Play("idle14");
                    break;
                }
            case 15:
                {
                    anim.Play("idle15");
                    break;
                }
            case 16:
                {
                    anim.Play("idle16");
                    break;
                }
            case 17:
                {
                    anim.Play("idle17");
                    break;
                }
            case 18:
                {
                    anim.Play("idle18");
                    break;
                }
        }
    }


    void playAttack()
    {
        switch (type)
        {
            case 0:
                {
                    anim.Play("attack");
                    break;
                }
            case 1:
                {
                    anim.Play("attack1");
                    break;
                }
            case 2:
                {
                    anim.Play("attack2");
                    break;
                }
            case 3:
                {
                    anim.Play("attack3");
                    break;
                }
            case 4:
                {
                    anim.Play("attack4");
                    break;
                }
            case 5:
                {
                    anim.Play("attack5");
                    break;
                }
            case 6:
                {
                    anim.Play("attack6");
                    break;
                }
            case 7:
                {
                    anim.Play("attack7");
                    break;
                }
            case 8:
                {
                    anim.Play("attack8");
                    break;
                }
            case 9:
                {
                    anim.Play("attack9");
                    break;
                }
            case 10:
                {
                    anim.Play("attack10");
                    break;
                }
            case 11:
                {
                    anim.Play("attack11");
                    break;
                }
            case 12:
                {
                    anim.Play("attack12");
                    break;
                }
            case 13:
                {
                    anim.Play("attack13");
                    break;
                }
            case 14:
                {
                    anim.Play("attack14");
                    break;
                }
            case 15:
                {
                    anim.Play("attack15");
                    break;
                }
            case 16:
                {
                    anim.Play("attack16");
                    break;
                }
            case 17:
                {
                    anim.Play("attack17");
                    break;
                }
            case 18:
                {
                    anim.Play("attack18");
                    break;
                }
        }
    }

    void playHurt()
    {
        switch (type)
        {
            case 0:
                {
                    anim.Play("hurt");
                    break;
                }
            case 1:
                {
                    anim.Play("hurt1");
                    break;
                }
            case 2:
                {
                    anim.Play("hurt2");
                    break;
                }
            case 3:
                {
                    anim.Play("hurt3");
                    break;
                }
            case 4:
                {
                    anim.Play("hurt4");
                    break;
                }
            case 5:
                {
                    anim.Play("hurt5");
                    break;
                }
            case 6:
                {
                    anim.Play("hurt6");
                    break;
                }
            case 7:
                {
                    anim.Play("hurt7");
                    break;
                }
            case 8:
                {
                    anim.Play("hurt8");
                    break;
                }
            case 9:
                {
                    anim.Play("hurt9");
                    break;
                }
            case 10:
                {
                    anim.Play("hurt10");
                    break;
                }
            case 11:
                {
                    anim.Play("hurt11");
                    break;
                }
            case 12:
                {
                    anim.Play("hurt12");
                    break;
                }
            case 13:
                {
                    anim.Play("hurt13");
                    break;
                }
            case 14:
                {
                    anim.Play("hurt14");
                    break;
                }
            case 15:
                {
                    anim.Play("hurt15");
                    break;
                }
            case 16:
                {
                    anim.Play("hurt16");
                    break;
                }
            case 17:
                {
                    anim.Play("hurt17");
                    break;
                }
            case 18:
                {
                    anim.Play("hurt18");
                    break;
                }
        }
    }

    void playDie()
    {
        switch (type)
        {
            case 0:
                {
                    anim.Play("die");
                    break;
                }
            case 1:
                {
                    anim.Play("die1");
                    break;
                }
            case 2:
                {
                    anim.Play("die2");
                    break;
                }
            case 3:
                {
                    anim.Play("die3");
                    break;
                }
            case 4:
                {
                    anim.Play("die4");
                    break;
                }
            case 5:
                {
                    anim.Play("die5");
                    break;
                }
            case 6:
                {
                    anim.Play("die6");
                    break;
                }
            case 7:
                {
                    anim.Play("die7");
                    break;
                }
            case 8:
                {
                    anim.Play("die8");
                    break;
                }
            case 9:
                {
                    anim.Play("die9");
                    break;
                }
            case 10:
                {
                    anim.Play("die10");
                    break;
                }
            case 11:
                {
                    anim.Play("die11");
                    break;
                }
            case 12:
                {
                    anim.Play("die12");
                    break;
                }
            case 13:
                {
                    anim.Play("die13");
                    break;
                }
            case 14:
                {
                    anim.Play("die14");
                    break;
                }
            case 15:
                {
                    anim.Play("die15");
                    break;
                }
            case 16:
                {
                    anim.Play("die16");
                    break;
                }
            case 17:
                {
                    anim.Play("die17");
                    break;
                }
            case 18:
                {
                    anim.Play("die18");
                    break;
                }
        }
    }
}


