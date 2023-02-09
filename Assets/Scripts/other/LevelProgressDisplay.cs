using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressDisplay : MonoBehaviour
{
    public PlayerStats stats;

    public TextMeshProUGUI text;

    private void Update()
    {
        if(stats.CURRENT_LEVEL%30 !=0)
        text.text = (stats.CURRENT_LEVEL % 30).ToString() + " / 30";
        else
        text.text = "BOSS";
    }

}
