using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftUIButtons : MonoBehaviour
{

    public PlayerStats stats;

    public GameObject perksUI;
    public GameObject mercenariesUI;
    public GameObject specialPerksUI;
    public GameObject dimensionUI;


    private void Start()
    {
        perksUI.SetActive(false);
        mercenariesUI.SetActive(false);
        specialPerksUI.SetActive(false);
        dimensionUI.SetActive(false);
    }

    public void perksOnClick()
    {
        mercenariesUI.SetActive(false);
        specialPerksUI.SetActive(false);
        dimensionUI.SetActive(false);

        if (perksUI.activeInHierarchy)
        {
            perksUI.SetActive(false);
        }
        else
        {
            perksUI.SetActive(true);
        }

        stats.settingsMenu.SetActive(false);
    }

    public void mercenariesOnClick()
    {
        perksUI.SetActive(false);
        specialPerksUI.SetActive(false);
        dimensionUI.SetActive(false);

        if (mercenariesUI.activeInHierarchy)
        {
            mercenariesUI.SetActive(false);
        }
        else
        {
            mercenariesUI.SetActive(true);
        }

        stats.settingsMenu.SetActive(false);
    }

    public void specialPerksOnClick()
    {
        perksUI.SetActive(false);
        mercenariesUI.SetActive(false);
        dimensionUI.SetActive(false);

        if (specialPerksUI.activeInHierarchy)
        {
            specialPerksUI.SetActive(false);
        }
        else
        {
            specialPerksUI.SetActive(true);
        }

        stats.settingsMenu.SetActive(false);
    }

    public void dimensionOnClick()
    {
        perksUI.SetActive(false);
        mercenariesUI.SetActive(false);
        specialPerksUI.SetActive(false);

        if (dimensionUI.activeInHierarchy)
        {
            dimensionUI.SetActive(false);
        }
        else
        {
            dimensionUI.SetActive(true);
        }

        stats.settingsMenu.SetActive(false);
    }


    public void resetOnclick()
    {

    }


}
