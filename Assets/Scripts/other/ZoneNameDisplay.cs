using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneNameDisplay : MonoBehaviour
{

    public PlayerStats stats;
    public TextMeshPro text;


    // Update is called once per frame
    void Update()
    {
        text.text = stats.ZONE_NAME + "     x" + stats.STAGE.ToString();
    }
}
