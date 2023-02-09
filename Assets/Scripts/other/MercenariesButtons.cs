using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MercenariesButtons : MonoBehaviour
{
    public PlayerStats stats;
    public Companion merc;

    public TextMeshProUGUI name;
    public string name_string;

    public TextMeshProUGUI cost;
    public TextMeshProUGUI lvl;

    public CompanionAnimation compAnim0;
    public CompanionAnimation compAnim1;

    public bool isWarrior = false;
    public bool isArcher = false;

    private void Start()
    {
        name.text = name_string;

        if (merc == null)
        {
            return;
        }
        setText();
        compAnim0.setAnimation();
    }

    private void Update()
    {
        
    }

    public void setText()
    {
        if (merc == null)
        {
            return;
        }

        merc.calculateCost();
        cost.text = "COST: " + GameManager.Instance.formatScientific(merc.LEVEL_UP_COST);
        lvl.text = "LVL: "+merc.LEVEL.ToString();
    }

    public void BUY_OnClick()
    {
        if(isWarrior && stats.companion.WARRIOR_LVL >= stats.companion.MAX_WARRIOR_LVL)
        {
            return;
        }
        if (isArcher && stats.companion.ARCHER_LVL >= stats.companion.MAX_ARCHER_LVL)
        {
            return;
        }

        if (stats.GOLD >= merc.LEVEL_UP_COST)
        {
            stats.GOLD -= merc.LEVEL_UP_COST;
            merc.levelUp();

            cost.text = "COST: " + GameManager.Instance.formatScientific(merc.LEVEL_UP_COST);
            lvl.text = "LVL: " + merc.LEVEL.ToString();

            stats.companion.setCosts();


            stats.setStats();

        }
    }

    public void HIRE_OnClick()
    {
        stats.companion.hire(merc);

        compAnim0.setAnimation();
        compAnim1.setAnimation();


        stats.setStats();
    }

    public void DISMISS_OnClick()
    {
        stats.companion.dismiss(merc);


        compAnim0.setAnimation();
        compAnim1.setAnimation();

        stats.setStats();
    }
}
