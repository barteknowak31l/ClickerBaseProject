using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentLevelText : MonoBehaviour
{
  public  TextMeshProUGUI text;
  public  PlayerStats stats;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        stats = GameManager.Instance.playerStats;
    }

    private void Update()
    {
        text.text = "Current Level: " + stats.getEnemyLevel();
    }


}
