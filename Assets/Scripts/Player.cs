using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//funkcje zwiazane z atakowaniem 

public class Player : MonoBehaviour
{

    public PlayerStats stats;
    public Enemy enemy;

    public bool PLAYER_DEAD;

    public Sprite alive;
    public Sprite dead;

    Animator anim;
    SpriteRenderer spriteRenderer;

    public bool changingLevel;
    bool dieAnimEnded;

    void Start()
    {
        PLAYER_DEAD = false;
        dieAnimEnded = false;
        changingLevel = false;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        anim.speed = stats.animationSpeed;

        anim.Play("idle");
        StartCoroutine(applyDPS());
    }

    void restartPlayer()
    {
        PLAYER_DEAD = false;
        dieAnimEnded = false;
        changingLevel = false;
        stats.CURRENT_HP = stats.HP;
        stats.HP_BAR.current = stats.CURRENT_HP;
        spriteRenderer.sprite = alive;
        anim.enabled = true;

    }

    public void applyDPC()
    {
        if(PLAYER_DEAD || changingLevel)
        {
            return;
        }
        enemy.takeDMG(stats.DPC);
        anim.Play("attack");
        //Debug.Log("PLAYER: just attacked enemy for " + stats.DPC + " DPC");
    }

    IEnumerator applyDPS()
    {
        while(true)
        {
            if (PLAYER_DEAD == false && changingLevel == false)
            {
                enemy.takeDMG(stats.DPS/10);
                //anim.Play("attack");
               // Debug.Log("PLAYER: just attacked enemy for " + stats.DPS + " DPS");
            }
            yield return new WaitForSeconds(stats.TIME_INTERVAL/10);
        }
    }

    public void takeDMG(double d)
    {
        if(PLAYER_DEAD || GameManager.Instance.isInMenu)
        {
            return;
        }

        calculateTakenDMG(d);


        if (stats.CURRENT_HP <=0)
        {
            onPlayerDeath();
        }

    }

    void calculateTakenDMG(double d)
    {
        double dmg;
        if (stats.perks.ARMOR_PERKS  > 1)
        {
            dmg = d * (1-stats.ARMOR);

        }
        else
        {
            dmg = d;
        }

        if(dmg < 0)
        {
            return;
        }
        
        stats.CURRENT_HP -= dmg;
        stats.HP_BAR.current = stats.CURRENT_HP;
    }

    public void onPlayerDeath()
    {
        anim.Play("die");
        PLAYER_DEAD = true;


    }

    void stopAnimation()
    {
        spriteRenderer.sprite = dead;
        dieAnimEnded = true;
        anim.enabled = false;
        resurrectPlayer();
    }

    public void resurrectPlayer()
    {
        if (PLAYER_DEAD && dieAnimEnded)
        {
            dieAnimEnded = false;
            PLAYER_DEAD = false;
            stats.CURRENT_LEVEL = stats.RESURRECT_LEVEL-1;
            stats.incrementLvl();
            stats.CURRENT_HP = stats.HP;
            stats.HP_BAR.current = stats.CURRENT_HP;

            spriteRenderer.sprite = alive;

            anim.enabled = true;
            anim.Play("idle");

            enemy.resetEnemy();
            Debug.Log("PLAYER DEATH - RESET");
        }
    }


    public void ChangeDimension()
    {
        restartPlayer();
    }


    public void onLevelChange()
    {
        changingLevel = true;
        anim.SetBool("transition", true);
        stats.companionAnim0.setAnimation();
        stats.companionAnim1.setAnimation();
    }
    public void stopRunning()
    {
        changingLevel = false;
        anim.SetBool("transition", false);
        stats.companionAnim0.setAnimation();
        stats.companionAnim1.setAnimation();
    }

    public void onAnimSpeedChange()
    {
        anim.speed = stats.animationSpeed;
    }
}
