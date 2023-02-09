using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchWarButtons : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerCompanion comp;
    public bool isWarrior;

    private void Update()
    {
        if(isWarrior)
        {
            if(comp.warrior.LEVEL >= comp.MAX_WARRIOR_LVL)
            {
                text.text = "MAX";
            }
            else
            {
                text.text = "BUY";
            }
        }
        else
        {
            if (comp.archer.LEVEL >= comp.MAX_ARCHER_LVL)
            {
                text.text = "MAX";
            }
            else
            {
                text.text = "BUY";
            }
        }
    }
}
