using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBarColor : MonoBehaviour
{
    public Image fill;
    public PlayerStats stats;
    double ratio;

    public Color c1;
    public Color c2;


    

    private void Update()
    {
        ratio = System.Math.Max(stats.DPC, stats.DPS) / stats.player.enemy.DAMAGE;

        //fill.color = Color.Lerp(Color.red, Color.green, System.Math.Clamp((float)ratio, 0, 1));
        fill.color = Color.Lerp(c2, c1, System.Math.Clamp((float)ratio, 0, 1));

    }

}
