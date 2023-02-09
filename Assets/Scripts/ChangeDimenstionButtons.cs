using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeDimenstionButtons : MonoBehaviour
{
    public int dimension;
    public PlayerStats stats;

    public TextMeshProUGUI dim;


    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public void OnClick()
    {
        if (dimension <= stats.MAX_ZONE)
            stats.ChangeDimension(dimension);
    }




    private void Update()
    {
       if(dimension > stats.MAX_ZONE)
        {
            dim.text = "LOCKED";
        }
        else
        {
           switch(dimension)
            {
                case 1:
                    {
                        dim.text = stats.ZONE_NAME1;
                        break;
                    }
                case 2:
                    {
                        dim.text = stats.ZONE_NAME2;
                        break;
                    }
                case 3:
                    {
                        dim.text = stats.ZONE_NAME3;
                        break;
                    }
                case 4:
                    {
                        dim.text = stats.ZONE_NAME4;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

}
