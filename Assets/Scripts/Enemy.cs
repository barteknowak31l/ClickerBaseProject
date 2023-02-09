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

    public double DAMAGE;
    public double DAMAGE_MULTIPLIER;
    public double DAMAGE_DIVIDER;

    public double ARMOR;
    public double ARMOR_BASE;
    public double ARMOR_MAX;
    public double ARMOR_EXP;
    public double ARMOR_MULT;

    public double ARMOR_PEN;

    public double GOLD ;
    public double GOLD_MULTIPLIER;

    public double STAGE_MULT;

    public bool isBoss;
    public double BOSS_HP_MULT;



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
        isBoss = false;

        //anim.Play("idle");

        //start applying DPS
        StartCoroutine(attack());
        initializeEnemy();


        regularPos = new Vector3(5.84f,-2.25f,0f);
        regularScale = new Vector3(1.245872f, 1.245872f, 1.245872f);

        bossPos = new Vector3(5.84f, -1.6f, 0f);
        bossScale = new Vector3(2.1533f, 2.1533f, 2.1533f);

        transform.position = regularPos;
        transform.localScale = regularScale;


    }


    public void initializeEnemy()
    {

        type = Random.Range(0, 17);

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
        if(ENEMY_IS_ALIVE == false)
        {
            return;
        }


        var go = Instantiate(DmgDealtText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = "-"+GameManager.Instance.formatScientific(d);
        



        if(enemyIsAttacking == false)
        {
            //anim.Play("hurt");
            playHurt();
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
    }


    void calculateHP()
    {

        if (player.stats.getEnemyLevel() <= 140)
        {
            HP = System.Math.Ceiling(10 * (player.stats.getEnemyLevel() - 1 + System.Math.Pow(1.55f, player.stats.getEnemyLevel() - 1)));
        }
        else if (player.stats.getEnemyLevel() > 140 && player.stats.getEnemyLevel() <= 500)
        {
            HP = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, player.stats.getEnemyLevel() - 140)));
        }
        else if (player.stats.getEnemyLevel() > 500 && player.stats.getEnemyLevel() <= 200000)
        {
            double product = 1;
            for (int i = 501; i < player.stats.getEnemyLevel(); i++)
            {
                product *= (1.145 + 0.001 * Mathf.Floor((i - 1) / 500));
            }

            HP = System.Math.Ceiling(10 * (139 + System.Math.Pow(1.55f, 139) * System.Math.Pow(1.145f, 360) * product));


        }
        else
        {
            HP = System.Math.Ceiling(System.Math.Pow(1.545f, player.stats.getEnemyLevel() - 200001) * 1.240f * System.Math.Pow(10, 25409) + (player.stats.getEnemyLevel() - 1) * 10);
        }

        //co 10 enemy jest trudniejszy
        int y = 0;
        int tmp = player.stats.getEnemyLevel();
        while (tmp > 10)
        {
            tmp -= 10;
            y++;
        }

        if (player.stats.getEnemyLevel() > 10)
            HP *= (double)((player.stats.getEnemyLevel() + 1) / 10f) * System.Math.Pow(1.5,y); 

        if (isBoss)
        {
            if (player.stats.specialPerks.BOSS_HP_REDUCTION == 0)
                HP *= BOSS_HP_MULT;
            else
                HP = HP * BOSS_HP_MULT * player.stats.specialPerks.BOSS_HP_REDUCTION * 0.1f;
        }

    }

    void calculateGold()
    {
        if(player.stats.getEnemyLevel() < 75)
        {
            GOLD = (HP / 15) * GOLD_MULTIPLIER;
        }
        else
        {
            GOLD = (HP / 15) * GOLD_MULTIPLIER * System.Math.Min(3, System.Math.Pow(1.025f, player.stats.getEnemyLevel() - 75));
        }


    }

    void calculateDamage()
    {

        if (player.stats.getEnemyLevel() < 75)
        {
            DAMAGE = (HP / DAMAGE_DIVIDER) * DAMAGE_MULTIPLIER * player.stats.BARD_ENEMYDMG_DEBUFF;
        }
        else
        {
            DAMAGE = (HP / DAMAGE_DIVIDER) * DAMAGE_MULTIPLIER * System.Math.Min(3, System.Math.Pow(1.025f, player.stats.getEnemyLevel() - 75)) * player.stats.BARD_ENEMYDMG_DEBUFF;
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


