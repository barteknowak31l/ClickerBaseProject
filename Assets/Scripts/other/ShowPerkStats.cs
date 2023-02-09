using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPerkStats : MonoBehaviour
{
    public PlayerStats stats;

    public TextMeshProUGUI dpc;
    public TextMeshProUGUI dps;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI hp;


    private void Update()
    {
        dpc.text = GameManager.Instance.formatScientific(stats.DPC);
        dps.text = GameManager.Instance.formatScientific(stats.DPS);
        hp.text = GameManager.Instance.formatScientific(stats.HP);

        /*        if (stats.ARMOR.ToString().Length >= 3)
                    armor.text = ((stats.ARMOR * 100).ToString()).Substring(0, 4) + "%";
                else
                    armor.text = (stats.ARMOR).ToString() + "%";*/

        armor.text = string.Format("{0:0.00}",stats.ARMOR*100) + "%";
    
    }

}
