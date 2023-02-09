using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHpDisplay : MonoBehaviour
{
    public PlayerStats stats;
    Enemy enemy;

    public TextMeshProUGUI text;

    private void Start()
    {
        enemy = stats.player.enemy;
    }

    private void Update()
    {
        text.text = GameManager.Instance.formatScientific(enemy.healthPoints) + " / " +  GameManager.Instance.formatScientific(enemy.HP);
    }
}
