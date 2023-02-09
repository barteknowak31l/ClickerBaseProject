using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public double max;
    public double current;
    public Image mask;

    private void Update()
    {
        getCurrentFill();
    }

    void getCurrentFill()
    {
        double fillAmount = current / max;
        mask.fillAmount = (float)fillAmount;
    }

}
