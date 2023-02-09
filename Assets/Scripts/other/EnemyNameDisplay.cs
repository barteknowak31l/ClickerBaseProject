using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyNameDisplay : MonoBehaviour
{
    public Enemy enemy;
    public TextMeshPro text;


    // Update is called once per frame
    void Update()
    {
        if(enemy.ENEMY_IS_ALIVE)
        {
            text.text = enemy.ENEMY_NAME;
        }
        else
        {
            text.text = "";
        }
    }
}
