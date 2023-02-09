using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetDimensionsButton : MonoBehaviour
{

    public PlayerStats stats;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.STAGE_COMPLETED)
        {
            text.text = "RESET DIMENSIONS";
        }
        else
        {
            text.text = "LOCKED";
        }
    }

    public void OnClick()
    {
        stats.incrementStage();
    }

}
