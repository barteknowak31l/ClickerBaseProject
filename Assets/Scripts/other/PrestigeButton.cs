using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrestigeButton : MonoBehaviour
{
    public PlayerStats stats;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text_max;
    private int lvl;
    private int[] levels;


    private void Start()
    {
        levels = new int[10];

        levels[0] = 0;
        levels[1] = 121;
        levels[2] = 241;
        levels[3] = 361;
        levels[4] = 481;
        levels[5] = 601;
        levels[6] = 721;
        levels[7] = 841;
        levels[8] = 961;
        levels[9] = 1081; // final boss
        
        lvl = stats.resetsDone + 1;
    }

    private void Update()
    {

        if (stats.resetsDone < 9)
            lvl = levels[stats.resetsDone + 1];
        else
            lvl = 10;


        if(lvl == 10)
        {
            text.text = "Maximum prestige!";
        }
        else
        {
            if (stats.MAX_LEVEL_REACHED < lvl)
                text.text = "Next prestige available after " + lvl + " lvl";
            else
                text.text = "Prestige reset ready!";

        }

        text_max.text = "Maximum level reached: " + stats.MAX_LEVEL_REACHED;

    }

    public void onClick()
    {
        //check if reset is valid - each reset can be done after several lvls
        if (lvl == 10 || stats.MAX_LEVEL_REACHED < levels[stats.resetsDone+1])
            return;


        for(int i = 0; i<levels.Length; i++)
        {
            if(stats.MAX_LEVEL_REACHED >= levels[i])
            {
                stats.setResetsDone(i);
            }
        }


        stats.specialResetStats();
    }
}
