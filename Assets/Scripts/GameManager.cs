using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //enumerators
    public enum enemyType
    {
        none = 0,
        snowman = 1
    }


    //level related
    public int currentLevel;

    public Enemy enemy;
    [SerializeField]
    public int[] enemiesOnLevel;
    public int enemiesKilled;
    public bool isEnemyReady;
    

    public PlayerStats playerStats;






    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        currentLevel = 0;
        enemiesKilled = 0;
        isEnemyReady = false;
    }


    public string formatScientific(double x)
    {

        if(x<=1)
        {
            return "0k";
        }

        //znajdz wykladnik
        int exp =0;

        double tmp = x;
        while(tmp >= 1)
        {
            tmp = tmp / (double)10;
            exp++;
        }

        exp--;
        //  string s = x.ToString("E5"); //string.Format("{0:#.##e00}", x);
        //s = s.Remove(1,1);


        string s ="";//= string.Format("{0:000.##e00}", x);

        //na podstawie wykladnika wytnij odpowiednio stringa

        if (exp%3 == 0)
        {
            // s = s.Substring(0, 1);
            s = string.Format("{0:0.##e00}", x);

        }

        if (exp % 3 == 1)
        {
            // s = s.Substring(0, 2);
            s = string.Format("{0:00.##e00}", x);
        }

        if (exp % 3 == 2)
        {
            // s = s.Substring(0, 3);
            s = string.Format("{0:000.##e00}", x);

        }

        s = s.Remove(s.Length - 1);
        s = s.Remove(s.Length - 1);
        s = s.Remove(s.Length - 1);


        if (x <= 1000)
        {
            return s + " k";
        }

        if (System.Math.Pow(10,3) < x && x <= System.Math.Pow(10,6))
        {
            return s + " kk";
        }

        if (System.Math.Pow(10, 6) < x && x <= System.Math.Pow(10, 9))
        {
            return s + " kkk" ;
        }


        if (System.Math.Pow(10, 9) < x && x <= System.Math.Pow(10, 12))
        {
            return s + " m" ;
        }

        if (System.Math.Pow(10, 12) < x && x <= System.Math.Pow(10, 15))
        {
            return s + " mm" ;
        }

        if (System.Math.Pow(10, 15) < x && x <= System.Math.Pow(10, 18))
        {
            return s + " mmm" ;
        }


        if (System.Math.Pow(10, 18) < x && x <= System.Math.Pow(10, 21))
        {
            return s + " b" ;
        }

        if (System.Math.Pow(10, 21) < x && x <= System.Math.Pow(10, 24))
        {
            return s + " bb" ;
        }

        if (System.Math.Pow(10, 24) < x && x <= System.Math.Pow(10, 27))
        {
            return s + " bbb" ;
        }


        if (System.Math.Pow(10, 27) < x && x <= System.Math.Pow(10, 30))
        {
            return s + " t" ;
        }

        if (System.Math.Pow(10, 30) < x && x <= System.Math.Pow(10, 33))
        {
            return s + " tt" ;
        }

        if (System.Math.Pow(10, 33) < x && x <= System.Math.Pow(10, 36))
        {
            return s + " ttt" ;
        }

        if (System.Math.Pow(10, 36) < x && x <= System.Math.Pow(10, 39))
        {
            return s + " q" ;
        }

        if (System.Math.Pow(10, 39) < x && x <= System.Math.Pow(10, 42))
        {
            return s + " qq" ;
        }

        if (System.Math.Pow(10, 42) < x && x <= System.Math.Pow(10, 45))
        {
            return s + " qqq" ;
        }


        if (System.Math.Pow(10, 45) < x && x <= System.Math.Pow(10, 48))
        {
            return s + " a" ;
        }

        if (System.Math.Pow(10, 48) < x && x <= System.Math.Pow(10, 51))
        {
            return s + " aa" ;
        }

        if (System.Math.Pow(10, 51) < x && x <= System.Math.Pow(10, 54))
        {
            return s + " aaa" ;
        }

        if (System.Math.Pow(10, 54) < x && x <= System.Math.Pow(10, 57))
        {
            return s + " z" ;
        }

        if (System.Math.Pow(10, 57) < x && x <= System.Math.Pow(10, 60))
        {
            return s + " zz" ;
        }

        if (System.Math.Pow(10, 60) < x && x <= System.Math.Pow(10, 63))
        {
            return s + " zzz" ;
        }


        if (System.Math.Pow(10, 63) < x && x <= System.Math.Pow(10, 66))
        {
            return s + " w" ;
        }

        if (System.Math.Pow(10, 66) < x && x <= System.Math.Pow(10, 69))
        {
            return s + " ww" ;
        }

        if (System.Math.Pow(10, 69) < x && x <= System.Math.Pow(10, 72))
        {
            return s + " www" ;
        }

        if (System.Math.Pow(10, 72) < x && x <= System.Math.Pow(10, 75))
        {
            return s + " s" ;
        }

        if (System.Math.Pow(10, 75) < x && x <= System.Math.Pow(10, 78))
        {
            return s + " ss" ;
        }

        if (System.Math.Pow(10, 78) < x && x <= System.Math.Pow(10, 81))
        {
            return s + " sss" ;
        }

        if (System.Math.Pow(10, 81) < x && x <= System.Math.Pow(10, 84))
        {
            return s + " x" ;
        }

        if (System.Math.Pow(10, 84) < x && x <= System.Math.Pow(10, 87))
        {
            return s + " xx" ;
        }

        if (System.Math.Pow(10, 87) < x && x <= System.Math.Pow(10, 90))
        {
            return s + " xxx" ;
        }

        if (System.Math.Pow(10, 90) < x && x <= System.Math.Pow(10, 93))
        {
            return s + " e" ;
        }

        if (System.Math.Pow(10, 93) < x && x <= System.Math.Pow(10, 96))
        {
            return s + " ee" ;
        }

        if (System.Math.Pow(10, 96) < x && x <= System.Math.Pow(10, 99))
        {
            return s + " eee" ;
        }

        if (System.Math.Pow(10, 99) < x && x <= System.Math.Pow(10, 102))
        {
            return s + " d" ;
        }

        if (System.Math.Pow(10, 102) < x && x <= System.Math.Pow(10, 105))
        {
            return s + " dd" ;
        }

        if (System.Math.Pow(10, 105) < x && x <= System.Math.Pow(10, 108))
        {
            return s + " ddd" ;
        }

        if (System.Math.Pow(10, 108) < x && x <= System.Math.Pow(10, 111))
        {
            return s + " c" ;
        }

        if (System.Math.Pow(10, 111) < x && x <= System.Math.Pow(10, 114))
        {
            return s + " cc" ;
        }

        if (System.Math.Pow(10, 114) < x && x <= System.Math.Pow(10, 117))
        {
            return s + " ccc" ;
        }
        if (System.Math.Pow(10, 117) < x && x <= System.Math.Pow(10, 120))
        {
            return s + " r" ;
        }

        if (System.Math.Pow(10, 120) < x && x <= System.Math.Pow(10, 123))
        {
            return s + " rr" ;
        }

        if (System.Math.Pow(10, 123) < x && x <= System.Math.Pow(10, 126))
        {
            return s + " rrr" ;
        }

        if (System.Math.Pow(10, 126) < x && x <= System.Math.Pow(10, 129))
        {
            return s + " f" ;
        }

        if (System.Math.Pow(10, 129) < x && x <= System.Math.Pow(10, 132))
        {
            return s + " ff" ;
        }

        if (System.Math.Pow(10, 132) < x && x <= System.Math.Pow(10, 135))
        {
            return s + " fff" ;
        }

        if (System.Math.Pow(10, 135) < x && x <= System.Math.Pow(10, 138))
        {
            return s + " v" ;
        }

        if (System.Math.Pow(10, 138) < x && x <= System.Math.Pow(10, 141))
        {
            return s + " vv" ;
        }

        if (System.Math.Pow(10, 141) < x && x <= System.Math.Pow(10, 144))
        {
            return s + " vvv" ;
        }

        if (System.Math.Pow(10, 144) < x && x <= System.Math.Pow(10, 147))
        {
            return s + " g" ;
        }

        if (System.Math.Pow(10, 147) < x && x <= System.Math.Pow(10, 150))
        {
            return s + " gg" ;
        }

        if (System.Math.Pow(10, 150) < x && x <= System.Math.Pow(10, 153))
        {
            return s + " ggg" ;
        }

        if (System.Math.Pow(10, 153) < x && x <= System.Math.Pow(10, 156))
        {
            return s + " y" ;
        }

        if (System.Math.Pow(10, 156) < x && x <= System.Math.Pow(10, 159))
        {
            return s + " yy" ;
        }

        if (System.Math.Pow(10, 159) < x && x <= System.Math.Pow(10, 162))
        {
            return s + " yyy" ;
        }

        if (System.Math.Pow(10, 162) < x && x <= System.Math.Pow(10, 165))
        {
            return s + " h" ;
        }

        if (System.Math.Pow(10, 165) < x && x <= System.Math.Pow(10, 168))
        {
            return s + " hh" ;
        }

        if (System.Math.Pow(10, 168) < x && x <= System.Math.Pow(10, 171))
        {
            return s + " hhh" ;
        }

        if (System.Math.Pow(10, 171) < x && x <= System.Math.Pow(10, 174))
        {
            return s + " n" ;
        }

        if (System.Math.Pow(10, 174) < x && x <= System.Math.Pow(10, 177))
        {
            return s + " nn" ;
        }

        if (System.Math.Pow(10, 177) < x && x <= System.Math.Pow(10, 180))
        {
            return s + " nnn" ;
        }

        if (System.Math.Pow(10, 180) < x && x <= System.Math.Pow(10, 183))
        {
            return s + " u" ;
        }

        if (System.Math.Pow(10, 183) < x && x <= System.Math.Pow(10, 186))
        {
            return s + " uu" ;
        }

        if (System.Math.Pow(10, 186) < x && x <= System.Math.Pow(10, 189))
        {
            return s + " uuu" ;
        }

        if (System.Math.Pow(10, 189) < x && x <= System.Math.Pow(10, 192))
        {
            return s + " j" ;
        }

        if (System.Math.Pow(10, 192) < x && x <= System.Math.Pow(10, 195))
        {
            return s + " jj" ;
        }

        if (System.Math.Pow(10, 195) < x && x <= System.Math.Pow(10, 198))
        {
            return s + " jjj" ;
        }

        if (System.Math.Pow(10, 198) < x && x <= System.Math.Pow(10, 201))
        {
            return s + " i" ;
        }

        if (System.Math.Pow(10, 201) < x && x <= System.Math.Pow(10, 204))
        {
            return s + " ii" ;
        }

        if (System.Math.Pow(10, 204) < x && x <= System.Math.Pow(10, 207))
        {
            return s + " iii" ;
        }

        if (System.Math.Pow(10, 207) < x && x <= System.Math.Pow(10, 210))
        {
            return s + " o" ;
        }

        if (System.Math.Pow(10, 210) < x && x <= System.Math.Pow(10, 213))
        {
            return s + " oo" ;
        }

        if (System.Math.Pow(10, 213) < x && x <= System.Math.Pow(10, 216))
        {
            return s + " ooo" ;
        }

        if (System.Math.Pow(10, 216) < x && x <= System.Math.Pow(10, 219))
        {
            return s + " l" ;
        }

        if (System.Math.Pow(10, 219) < x && x <= System.Math.Pow(10, 222))
        {
            return s + " ll" ;
        }

        if (System.Math.Pow(10, 222) < x && x <= System.Math.Pow(10, 225))
        {
            return s + " lll" ;
        }

        if (System.Math.Pow(10, 225) < x && x <= System.Math.Pow(10, 228))
        {
            return s + " p" ;
        }

        if (System.Math.Pow(10, 228) < x && x <= System.Math.Pow(10, 231))
        {
            return s + " pp" ;
        }

        if (System.Math.Pow(10, 231) < x && x <= System.Math.Pow(10, 234))
        {
            return s + " ppp" ;
        }


        if (System.Math.Pow(10, 234) < x && x <= System.Math.Pow(10, 237))
        {
            return s + " K" ;
        }

        if (System.Math.Pow(10, 237) < x && x <= System.Math.Pow(10, 240))
        {
            return s + " KK" ;
        }

        if (System.Math.Pow(10, 240) < x && x <= System.Math.Pow(10, 243))
        {
            return s + " KKK" ;
        }

        if (System.Math.Pow(10, 243) < x && x <= System.Math.Pow(10, 246))
        {
            return s + " M" ;
        }

        if (System.Math.Pow(10, 246) < x && x <= System.Math.Pow(10, 249))
        {
            return s + " MM" ;
        }

        if (System.Math.Pow(10, 249) < x && x <= System.Math.Pow(10, 252))
        {
            return s + " MMM" ;
        }

        if (System.Math.Pow(10, 252) < x && x <= System.Math.Pow(10, 255))
        {
            return s + " B" ;
        }

        if (System.Math.Pow(10, 255) < x && x <= System.Math.Pow(10, 258))
        {
            return s + " BB" ;
        }

        if (System.Math.Pow(10, 258) < x && x <= System.Math.Pow(10, 261))
        {
            return s + " BBB" ;
        }

        if (System.Math.Pow(10, 261) < x && x <= System.Math.Pow(10, 264))
        {
            return s + " T" ;
        }

        if (System.Math.Pow(10, 264) < x && x <= System.Math.Pow(10, 267))
        {
            return s + " TT" ;
        }

        if (System.Math.Pow(10, 267) < x && x <= System.Math.Pow(10, 270))
        {
            return s + " TTT" ;
        }

        if (System.Math.Pow(10, 270) < x && x <= System.Math.Pow(10, 273))
        {
            return s + " Q" ;
        }

        if (System.Math.Pow(10, 273) < x && x <= System.Math.Pow(10, 276))
        {
            return s + " QQ" ;
        }

        if (System.Math.Pow(10, 276) < x && x <= System.Math.Pow(10, 279))
        {
            return s + " QQQ" ;
        }

        if (System.Math.Pow(10, 279) < x && x <= System.Math.Pow(10, 282))
        {
            return s + " A" ;
        }

        if (System.Math.Pow(10, 282) < x && x <= System.Math.Pow(10, 285))
        {
            return s + " AA" ;
        }

        if (System.Math.Pow(10, 285) < x && x <= System.Math.Pow(10, 288))
        {
            return s + " AAA" ;
        }

        if (System.Math.Pow(10, 288) < x && x <= System.Math.Pow(10, 291))
        {
            return s + " Z" ;
        }

        if (System.Math.Pow(10, 291) < x && x <= System.Math.Pow(10, 294))
        {
            return s + " ZZ" ;
        }

        if (System.Math.Pow(10, 294) < x && x <= System.Math.Pow(10, 297))
        {
            return s + " ZZZ" ;
        }


        if (System.Math.Pow(10, 297) < x && x <= System.Math.Pow(10, 300))
        {
            return s + " GOD" ;
        }


        return string.Format("{0:#.##e00}", x);
    }

}
