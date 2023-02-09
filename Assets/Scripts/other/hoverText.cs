using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hoverText : MonoBehaviour
{
    public GameObject hoverField;
    public TextMeshProUGUI hover;

    public void onHover()
    {
        Debug.Log("HOVER");
        hoverField.SetActive(true);
    }
    public void stopHover()
    {
        Debug.Log("STOPHOVER");
        hoverField.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
