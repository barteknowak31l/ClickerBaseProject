using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHpDisplay : MonoBehaviour
{
    public PlayerStats stats;

    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = GameManager.Instance.formatScientific(stats.CURRENT_HP) + " / " + GameManager.Instance.formatScientific(stats.HP);
    }

}
