using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    public TextMeshPro text;
    public PlayerStats stats;

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.Instance.formatScientific(stats.GOLD);
    }
}
