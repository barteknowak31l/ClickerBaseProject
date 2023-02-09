using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandColor : MonoBehaviour
{
    public PlayerStats stats;
    public SpriteRenderer s;
    public Color c1;
    public Color c2;
    public Color c3;
    public Color c4;

    public void changeColor(int c)
    {
        switch(c)
        {
            case 1:
                {
                    s.color = c1;
                    break;
                }
            case 2:
                {
                    s.color = c2;
                    break;
                }

            case 3:
                {
                    s.color = c3;
                    break;
                }
            case 4:
                {
                    s.color = c4;
                    break;
                }
        }
    }


}
