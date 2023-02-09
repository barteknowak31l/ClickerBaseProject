using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkButtons : MonoBehaviour
{
    public PlayerPerks perks;

    public TextMeshProUGUI DPC_text_cost;
    public TextMeshProUGUI DPS_text_cost;
    public TextMeshProUGUI HP_text_cost;
    public TextMeshProUGUI ARMOR_text_cost;
    public TextMeshProUGUI ARMOR_PEN_text_cost;

    public TextMeshProUGUI DPC_text_lvl;
    public TextMeshProUGUI DPS_text_lvl;
    public TextMeshProUGUI HP_text_lvl;
    public TextMeshProUGUI ARMOR_text_lvl;
    public TextMeshProUGUI ARMOR_PEN_text_lvl;
    
    
    public TextMeshProUGUI ARMOR_BUTTON_TEXT;

    

    private void Start()
    {
        updateTextFields();
    }

    public void updateTextFields()
    {
        DPC_text_lvl.text = "LVL: " + perks.DPC_PERKS.ToString();
        DPS_text_lvl.text = "LVL: " + perks.DPS_PERKS.ToString();
        HP_text_lvl.text =  "LVL: " + perks.HP_PERKS.ToString();
        ARMOR_text_lvl.text = "LVL: " + perks.ARMOR_PERKS.ToString();
        ARMOR_PEN_text_lvl.text = "LVL: " + perks.ARMOR_PEN_PERKS.ToString();

        DPC_text_cost.text = "COST: " + GameManager.Instance.formatScientific(perks.DPC_PERK_COST);
        DPS_text_cost.text = "COST: " + GameManager.Instance.formatScientific(perks.DPS_PERK_COST);
        HP_text_cost.text = "COST: " + GameManager.Instance.formatScientific(perks.HP_PERK_COST);
        ARMOR_text_cost.text = "COST: " + GameManager.Instance.formatScientific(perks.ARMOR_PERK_COST);
        ARMOR_PEN_text_cost.text = "COST: " + GameManager.Instance.formatScientific(perks.ARMOR_PEN_PERK_COST);

        if (perks.ARMOR_PERKS >= perks.MAX_ARMOR_PERKS)
        {
            ARMOR_BUTTON_TEXT.text = "MAX";
        }
        else
        {
            ARMOR_BUTTON_TEXT.text = "BUY";
        }

    }

    public void DPCOnClick()
    {
        if(perks.player.GOLD >= perks.DPC_PERK_COST)
        {
            perks.player.GOLD -= perks.DPC_PERK_COST;
            perks.DPC_PERKS++;
            perks.calculateDPC();
            perks.player.setDPC();
            updateTextFields();
            perks.player.companion.updateCompanionsStatistics();
        }
    }

    public void DPSOnClick()
    {
        if (perks.player.GOLD >= perks.DPS_PERK_COST)
        {
            perks.player.GOLD -= perks.DPS_PERK_COST;
            perks.DPS_PERKS++;
            perks.calculateDPS();
            perks.player.setDPS();
            updateTextFields();
        }
    }
    public void HPOnClick()
    {
        if (perks.player.GOLD >= perks.HP_PERK_COST)
        {
            perks.player.GOLD -= perks.HP_PERK_COST;
            perks.HP_PERKS++;
            perks.calculateHP();
            perks.player.setHP();
            updateTextFields();
        }
    }

    public void ARMOROnClick()
    {
        if(perks.ARMOR_PERKS >= perks.MAX_ARMOR_PERKS)
        {
            ARMOR_BUTTON_TEXT.text = "MAX";
            return;
        }

        if (perks.player.GOLD >= perks.ARMOR_PERK_COST)
        {
            ARMOR_BUTTON_TEXT.text = "BUY";
            perks.player.GOLD -= perks.ARMOR_PERK_COST;
            perks.ARMOR_PERKS++;
            perks.calculateARMOR();
            perks.player.setARMOR();
            updateTextFields();
        }
    }

    public void ARMORPENOnClick()
    {
        if (perks.player.GOLD >= perks.ARMOR_PEN_PERK_COST)
        {
            perks.player.GOLD -= perks.ARMOR_PEN_PERK_COST;
            perks.ARMOR_PEN_PERKS++;
            perks.calculateARMOR_PEN();
            perks.player.setARMOR_PEN();
            updateTextFields();
        }
    }


}
