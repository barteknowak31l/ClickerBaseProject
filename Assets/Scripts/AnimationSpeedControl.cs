using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationSpeedControl : MonoBehaviour
{
    public int maxAnimSpeed;
    public PlayerStats stats;
    public TextMeshProUGUI text;

    public void OnClick()
    {
        if(stats.animationSpeed == 1)
        {
            stats.animationSpeed = maxAnimSpeed ;
            stats.onAnimSpeedChange();

            text.text = "SLOW ANIMATION";

        }
        else
        {
            stats.animationSpeed = 1;
            stats.onAnimSpeedChange();

            text.text = "FAST ANIMATION";
        }
    }
}
