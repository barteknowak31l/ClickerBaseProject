using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerStats : MonoBehaviour, IDataPersistence
{
    [Header("Player references")]
    public Player player;
    public PlayerPerks perks;
    public PlayerCompanion companion;
    public SpecialPerks specialPerks;
    public PerkButtons perkButtons1;
    public PerkButtons perkButtons2;
    public PerkButtons perkButtons3;
    public PerkButtons perkButtons4;
    public MercenariesButtons mercButton1;
    public MercenariesButtons mercButton2;
    public MercenariesButtons mercButton3;
    public MercenariesButtons mercButton4;
    public MercenariesButtons mercButton5;
    public MercenariesButtons mercButton6;


    [Header("Bars")]
    public ProgressBar LEVEL_PROGRESS_BAR;
    public ProgressBar HP_BAR;

    [Header("Level info")]
    public int CURRENT_LEVEL;
    public int RESURRECT_LEVEL;
    public int RESURRECT_LEVEL_DISTANCE;
    public int MAX_LEVEL;
    public int MAX_LEVEL_REACHED;
    public int MAX_ZONE;
    public int STAGE;
    public int MAX_STAGE_REACHED;
    public int MAXIMUM_STAGE;
    public bool STAGE_COMPLETED;
    public string ZONE_NAME;
    public string ZONE_NAME1;
    public string ZONE_NAME2;
    public string ZONE_NAME3;
    public string ZONE_NAME4;

    public int resetsDone;

    [Header("Stats")]
    public double GOLD;
    public int maxBossesKilled; //keeps track of farther boss killed


    [Header("Prestige multipliers")]
    public double RESET_POINTS_GOLD;
    public double RESET_POINTS_DPC;
    public double RESET_POINTS_DPS;
    public double RESET_POINTS_HP;
    public int RESET_ARMOR_COST_MULT;

    public int maxIridiumPerkLvl;

    [Header("CLICKDMG")]
    //DPC - damage per click
    public double DPC;

    public double FLAT_DPC;
    public double PERK_DPC;
    public double COMP1_DPC;
    public double COMP2_DPC;
    public double RESET_PERKS_DPC;

    [Header("DPS")]
    //DPS - passive damage
    public double DPS;

    public float TIME_INTERVAL;

    public double FLAT_DPS;
    public double PERK_DPS;
    public double COMP1_DPS;
    public double COMP2_DPS;
    public double RESET_PERKS_DPS;


    [Header("HP")]
    //HP
    public double HP;
    public double CURRENT_HP;

    public double FLAT_HP;
    public double PERK_HP;
    public double COMP1_HP;
    public double COMP2_HP;
    public double RESET_PERKS_HP;

    [Header("ARMOR")]
    //ARMOR- procent ignorowanych obrazen (dmg przeciwnika - armor = dmg otrzymany) ?
    public double ARMOR_INFLUENCE;
    public double ARMOR;

    public double FLAT_ARMOR;
    public double PERK_ARMOR;
    public double COMP1_ARMOR;
    public double COMP2_ARMOR;
    public double RESET_POINTS_ARMOR;
    public double RESET_PERKS_ARMOR;

    [Header("ARMOR_PEN")]
    //ARMOR_PEN - przebicie pancerza
    public double ARMOR_PEN;

    public double FLAT_ARMOR_PEN;
    public double PERK_ARMOR_PEN;
    public double COMP1_ARMOR_PEN;
    public double COMP2_ARMOR_PEN;
    public double RESET_POINTS_ARMOR_PEN;
    public double RESET_PERKS_ARMOR_PEN;

    [Header("Companion utilities")]
    //thief class
    public float ADDITIONAL_GOLD_DROP;

    //bard class
    public float BARD_CLICKDMG_BUFF;
    public float BARD_ENEMYDMG_DEBUFF;

    [Header("Background handle")]
    public SpriteRenderer backgroundRenderer;
    public Sprite zone1;
    public Sprite zone2;
    public Sprite zone3;
    public Sprite zone4;

    [Header("Animations")]
    public float animationSpeed;
    public CompanionAnimation companionAnim0;
    public CompanionAnimation companionAnim1;


    [Header("Controls")]
    public GameObject perkMenu;
    public GameObject mercMenu;
    public GameObject specialMenu;
    public GameObject dimensionMenu;
    public GameObject settingsMenu;
    public GameObject aboutPanel;


    [Header("Audio")]
    public AudioSource audio;
    public AudioClip[] clips;
    int clipPlaying=0;


    public LandColor landColor;

    private void Awake()
    {
        Screen.SetResolution(1600, 900, false);
        Application.runInBackground = true;
        initStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        perks.calculateAll();
        setStats();
        CURRENT_HP = HP;

        clipPlaying = Random.Range(0, clips.Length - 1);
    }

    void Update()
    {
        if(audio.isPlaying==false)
        {
            audio.clip = clips[clipPlaying];
            audio.Play();

            clipPlaying++;
            if(clipPlaying >= clips.Length)
            {
                clipPlaying = 0;
            }
        }


        if (Input.GetKeyDown("escape"))
        {
            if (perkMenu.active == false && mercMenu.active == false && specialMenu.active == false && dimensionMenu.active == false && settingsMenu.active == false)
            {
                perkMenu.SetActive(false);
                mercMenu.SetActive(false);
                specialMenu.SetActive(false);
                dimensionMenu.SetActive(false);

                settingsMenu.SetActive(true);
            }
            else
            {
                perkMenu.SetActive(false);
                mercMenu.SetActive(false);
                specialMenu.SetActive(false);
                dimensionMenu.SetActive(false);
                settingsMenu.SetActive(false);
            }

            aboutPanel.SetActive(false);

        }

        

    }

    public void settingsOnClick()
    {
        if (settingsMenu.active == false)
        {
            perkMenu.SetActive(false);
            mercMenu.SetActive(false);
            specialMenu.SetActive(false);
            dimensionMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
        else
        {
            perkMenu.SetActive(false);
            mercMenu.SetActive(false);
            specialMenu.SetActive(false);
            dimensionMenu.SetActive(false);
            settingsMenu.SetActive(false);
        }
    }

    public void aboutOnClick()
    {
        aboutPanel.SetActive(true);
    }

    public void saveAndQuit()
    {
        Application.Quit();
    }

    public void muteSoundOnClick()
    {
        //todo sound
    }
    void initStats()
    {

        //CURRENT_LEVEL = 1;
        //MAX_LEVEL = 1;
        //MAX_ZONE = 1;
        //RESURRECT_LEVEL = 1;
        //STAGE = 1;
        MAXIMUM_STAGE = 30;
        //MAX_STAGE_REACHED = 0;
        //STAGE_COMPLETED = false;
        //ZONE_NAME = ZONE_NAME1;

        //GOLD = 1;
        ADDITIONAL_GOLD_DROP = 1;

        BARD_ENEMYDMG_DEBUFF = 1;
        BARD_CLICKDMG_BUFF = 1;

        //DPC - damage per click
        //DPC = 1;
        //FLAT_DPC = 1;
        //COMP1_DPC = 1;
        //COMP2_DPC = 1;
        //RESET_POINTS_DPC = 1;
        //RESET_PERKS_DPC = 1;

        //DPS - passive damage
        //DPS = 1;
        TIME_INTERVAL = 1;
        //FLAT_DPS = 1;
        //PERK_DPS = 1;
        //COMP1_DPS = 1;
        //COMP2_DPS = 1;
        //RESET_POINTS_DPS = 1;
        //RESET_PERKS_DPS = 1;

        //HP
        //HP = 20;
        //CURRENT_HP = HP;
        //FLAT_HP = 1;
        //PERK_HP = 1;
        //COMP1_HP = 1;
        //COMP2_HP = 1;
        //RESET_POINTS_HP = 1;
        //RESET_PERKS_HP = 1;


        //ARMOR- procent ignorowanych obrazen (dmg przeciwnika - armor = dmg otrzymany) ?
        //ARMOR = 1;
        //FLAT_ARMOR = 1;
        //PERK_ARMOR = 1;
        //COMP1_ARMOR = 0;
        //COMP2_ARMOR = 0;
        //RESET_POINTS_ARMOR = 1;
        //RESET_PERKS_ARMOR = 1;

        //ARMOR_PEN - przebicie pancerza
        //ARMOR_PEN = 0;
        //FLAT_ARMOR_PEN = 0;
        //PERK_ARMOR_PEN = 0;
        //COMP1_ARMOR_PEN = 0;
        //COMP2_ARMOR_PEN = 0;
        //RESET_POINTS_ARMOR_PEN = 0;
        //RESET_PERKS_ARMOR_PEN = 0;

        HP_BAR.max = HP;
        HP_BAR.current = CURRENT_HP;

        //setStats();

    }

    public void setDPC()
    {
        DPC = FLAT_DPC * PERK_DPC * COMP1_DPC * COMP2_DPC * System.Math.Pow(10, RESET_POINTS_DPC) * RESET_PERKS_DPC * BARD_CLICKDMG_BUFF;

        if(DPC > GameManager.Instance.biggestNumber)
        {
            DPC = GameManager.Instance.biggestNumber;
        }

    }

    public void setDPS()
    {
        DPS = FLAT_DPS * PERK_DPS * COMP1_DPS * COMP2_DPS * System.Math.Pow(10, RESET_POINTS_DPS) * RESET_PERKS_DPS;

        if (DPS > GameManager.Instance.biggestNumber)
        {
            DPS = GameManager.Instance.biggestNumber;
        }
    }

    public void setHP()
    {
        double ratio = CURRENT_HP / HP;

        HP = FLAT_HP * PERK_HP * COMP1_HP * COMP2_HP * System.Math.Pow(10,RESET_POINTS_HP) * RESET_PERKS_HP;

        if (HP > GameManager.Instance.biggestNumber)
        {
            HP = GameManager.Instance.biggestNumber;
        }


        CURRENT_HP = HP * ratio;
        HP_BAR.current = CURRENT_HP;
        HP_BAR.max = HP;
    }

    public double getMaxHP()
    {
        return FLAT_HP * PERK_HP * COMP1_HP * COMP2_HP * System.Math.Pow(10, RESET_POINTS_HP) * RESET_PERKS_HP;
    }
    public void setARMOR()
    {
        ARMOR = PERK_ARMOR + COMP1_ARMOR + COMP2_ARMOR;
    }

    public void setARMOR_PEN()
    {
        ARMOR_PEN = 0.1 * specialPerks.ARMOR_PEN;
    }


    public void setStats()
    {
        handleResetPoints();

        setDPC();
        setDPS();
        setHP();
        setARMOR();
        setARMOR_PEN();
    }

    public void incrementLvl()
    {
        CURRENT_LEVEL++;

        if(getEnemyLevel() > MAX_LEVEL_REACHED)
        {
            MAX_LEVEL_REACHED = getEnemyLevel();
        }


        if (CURRENT_LEVEL > MAX_LEVEL)
        {
            MAX_LEVEL = CURRENT_LEVEL;
        }

        if (CURRENT_LEVEL == 30 || CURRENT_LEVEL == 60 || CURRENT_LEVEL == 90 || CURRENT_LEVEL == 120)
        {
            LEVEL_PROGRESS_BAR.current = LEVEL_PROGRESS_BAR.max;
            player.enemy.isBoss = true;
        }
        else
        {
            LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;
            player.enemy.isBoss = false;
        }



        if (CURRENT_LEVEL > 120)
        {
            CURRENT_LEVEL = 91;
            player.ChangeDimension();

            CURRENT_LEVEL = 117;
            RESURRECT_LEVEL = 117;

            STAGE_COMPLETED = true;
        }

        if (CURRENT_LEVEL <= 30)
        {
            ZONE_NAME = ZONE_NAME1;
           // RESURRECT_LEVEL = 1;
            if (MAX_ZONE < 1)
                MAX_ZONE = 1;
            backgroundRenderer.sprite = zone1;
            landColor.changeColor(1);
        }

        if (CURRENT_LEVEL > 30 && CURRENT_LEVEL <= 60)
        {
            ZONE_NAME = ZONE_NAME2;
           // RESURRECT_LEVEL = 31;
            if (MAX_ZONE < 2)
                MAX_ZONE = 2;
            backgroundRenderer.sprite = zone2;
            landColor.changeColor(2);
        }

        if (CURRENT_LEVEL > 60 && CURRENT_LEVEL <= 90)
        {
            ZONE_NAME = ZONE_NAME3;
           // RESURRECT_LEVEL = 61;
            if (MAX_ZONE < 3)
                MAX_ZONE = 3;
            backgroundRenderer.sprite = zone3;
            landColor.changeColor(3);
        }

        if (CURRENT_LEVEL > 90 && CURRENT_LEVEL <= 120)
        {
            ZONE_NAME = ZONE_NAME4;
            //RESURRECT_LEVEL = 91;
            if (MAX_ZONE < 4)
                MAX_ZONE = 4;
            backgroundRenderer.sprite = zone4;
            landColor.changeColor(4);
        }

        RESURRECT_LEVEL = CURRENT_LEVEL - RESURRECT_LEVEL_DISTANCE;
        if (RESURRECT_LEVEL <= 0)
        {
            RESURRECT_LEVEL = 1;
        }

        if(RESURRECT_LEVEL  == 28 || RESURRECT_LEVEL == 29 || RESURRECT_LEVEL == 30)
        {
            RESURRECT_LEVEL = 31;
        }

        if (RESURRECT_LEVEL == 58 || RESURRECT_LEVEL == 59 || RESURRECT_LEVEL == 60)
        {
            RESURRECT_LEVEL = 61;
        }

        if (RESURRECT_LEVEL == 88 || RESURRECT_LEVEL == 89 || RESURRECT_LEVEL == 90)
        {
            RESURRECT_LEVEL = 91;
        }


    }

    public void ChangeDimension(int dimension)
    {

        setStats();

        switch (dimension)
        {
            case 1:
                {
                    //reset player
                    player.ChangeDimension();

                    landColor.changeColor(1);

                    //update napisu ZONE_NAME, paska progresu i reset t³a
                    ZONE_NAME = ZONE_NAME1;
                    backgroundRenderer.sprite = zone1;

                    CURRENT_LEVEL = 1;
                    RESURRECT_LEVEL = 1;
                    LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;

                    //reset enemy
                    if (player.enemy.ENEMY_IS_ALIVE)
                        player.enemy.initializeEnemy();

                    break;
                }
            case 2:
                {

                    player.ChangeDimension();

                    landColor.changeColor(2);
                    //update napisu ZONE_NAME, paska progresu i reset t³a
                    ZONE_NAME = ZONE_NAME2;
                    backgroundRenderer.sprite = zone2;

                    //zmien stage
                    CURRENT_LEVEL = 31;
                    RESURRECT_LEVEL = 31;
                    LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;

                    //reset enemy
                    player.enemy.initializeEnemy();
                    //reset player
                    break;
                }
            case 3:
                {

                    //reset player
                    player.ChangeDimension();
                    landColor.changeColor(3);
                    //update napisu ZONE_NAME, paska progresu i reset t³a
                    ZONE_NAME = ZONE_NAME3;
                    backgroundRenderer.sprite = zone3;

                    //zmien stage
                    CURRENT_LEVEL = 61;
                    RESURRECT_LEVEL = 61;
                    LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;

                    //reset enemy
                    player.enemy.initializeEnemy();

                    break;
                }
            case 4:
                {

                    player.ChangeDimension();
                    landColor.changeColor(4);
                    //update napisu ZONE_NAME, paska progresu i reset t³a
                    ZONE_NAME = ZONE_NAME4;
                    backgroundRenderer.sprite = zone4;


                    //zmien stage
                    CURRENT_LEVEL = 91;
                    RESURRECT_LEVEL = 91;
                    LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;

                    //reset enemy
                    player.enemy.initializeEnemy();
                    //reset player

                    break;
                }
            default:
                {
                    break;
                }
        }
    }


    public void incrementStage()
    {
        if (!STAGE_COMPLETED)
        {
            return;
        }

        if (STAGE > MAX_STAGE_REACHED)
        {
            MAX_STAGE_REACHED = STAGE;
            //specialPerks.POINTS++;
        }

        STAGE_COMPLETED = false;
        STAGE++;
        MAX_ZONE = 1;
        MAX_LEVEL = 1;


        ChangeDimension(1);

    }

    public int getEnemyLevel()
    {
        int level = 120 * (STAGE) + CURRENT_LEVEL - 120;

        return level;
    }


    public void heal(double heal)
    {
        if(GameManager.Instance.isInMenu)
        {
            return;
        }

        CURRENT_HP += heal;

        if (CURRENT_HP > HP)
        {
            CURRENT_HP = HP;
        }
        HP_BAR.current = CURRENT_HP;
    }


    public void specialResetStats()
    {
        CURRENT_LEVEL = 1;
        MAX_LEVEL = 1;
        MAX_ZONE = 1;
        RESURRECT_LEVEL = 1;
        STAGE = 1;
        MAXIMUM_STAGE = 30;
        STAGE_COMPLETED = false;
        ZONE_NAME = ZONE_NAME1;

        LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;

        GOLD = 1;
        ADDITIONAL_GOLD_DROP = 1;

        BARD_ENEMYDMG_DEBUFF = 1;
        BARD_CLICKDMG_BUFF = 1;

        //DPC - damage per click
        DPC = 1;
        FLAT_DPC = 1;
        PERK_DPC = 1;
        COMP1_DPC = 1;
        COMP2_DPC = 1;
        RESET_POINTS_DPC = 1;
        RESET_PERKS_DPC = 1;

        //DPS - passive damage
        DPS = 1;
        TIME_INTERVAL = 1;
        FLAT_DPS = 1;
        PERK_DPS = 1;
        COMP1_DPS = 1;
        COMP2_DPS = 1;
        RESET_POINTS_DPS = 1;
        RESET_PERKS_DPS = 1;

        //HP
        HP = 10;
        FLAT_HP = 1;
        PERK_HP = 1;
        COMP1_HP = 1;
        COMP2_HP = 1;
        RESET_POINTS_HP = 1;
        RESET_PERKS_HP = 1;


        //ARMOR- procent ignorowanych obrazen (dmg przeciwnika - armor = dmg otrzymany) ?
        ARMOR = 0;
        FLAT_ARMOR = 0;
        PERK_ARMOR = 0;
        COMP1_ARMOR = 0;
        COMP2_ARMOR = 0;
        RESET_POINTS_ARMOR = 1;
        RESET_PERKS_ARMOR = 1;

        //ARMOR_PEN - przebicie pancerza
        ARMOR_PEN = 0;
        FLAT_ARMOR_PEN = 0;
        PERK_ARMOR_PEN = 0;
        COMP1_ARMOR_PEN = 0;
        COMP2_ARMOR_PEN = 0;
        RESET_POINTS_ARMOR_PEN = 0;
        RESET_PERKS_ARMOR_PEN = 0;

        HP_BAR.max = HP;
        HP_BAR.current = CURRENT_HP;

        player.ChangeDimension();
        perks.resetPerks();
        companion.resetCompanion();

        if(companion.merc0 != null)
        {
            companion.dismiss(companion.merc0);
        }
        if (companion.merc1 != null)
        {
            companion.dismiss(companion.merc1);
        }

        setStats();
        CURRENT_HP = HP;

        player.enemy.HP = 0;

        perkButtons1.updateTextFields();
        perkButtons2.updateTextFields();
        perkButtons3.updateTextFields();
        perkButtons4.updateTextFields();

        mercButton1.setText();
        mercButton2.setText();
        mercButton3.setText();
        mercButton4.setText();
        mercButton5.setText();
        mercButton6.setText();


    }

    public void onAnimSpeedChange()
    {
        player.onAnimSpeedChange();
        player.enemy.onAnimSpeedChange();
        companionAnim0.onAnimSpeedChange();
        companionAnim1.onAnimSpeedChange();
    }



    public void fullHeal()
    {
        CURRENT_HP = HP;
        HP_BAR.current = CURRENT_HP;
        HP_BAR.max = HP;
    }

    public void handleResetPoints()
    {
        switch(resetsDone)
        {
            case 0:
                {
                    RESET_POINTS_DPC = 1;
                    RESET_POINTS_DPS = 1;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 0;
                    RESET_ARMOR_COST_MULT = 0;
                    break;
                }
            case 1:
                {
                    RESET_POINTS_DPC = 9.5;
                    RESET_POINTS_DPS = 9.4;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 2.4;
                    RESET_ARMOR_COST_MULT = 121;
                    break;
                }
            case 2:
                {
                    RESET_POINTS_DPC = 17;
                    RESET_POINTS_DPS = 16.9;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 4.5;
                    RESET_ARMOR_COST_MULT = 241;
                    break;
                }
            case 3:
                {
                    RESET_POINTS_DPC = 25.9;
                    RESET_POINTS_DPS = 25.8;
                    RESET_POINTS_HP = 1f;
                    RESET_POINTS_GOLD = 6;
                    RESET_ARMOR_COST_MULT = 361;
                    break;
                }
            case 4:
                {
                    RESET_POINTS_DPC = 37;
                    RESET_POINTS_DPS = 36.5;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 8.1;
                    RESET_ARMOR_COST_MULT = 481;
                    break;
                }
            case 5:
                {
                    RESET_POINTS_DPC = 44;
                    RESET_POINTS_DPS = 43.9;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 11;
                    RESET_ARMOR_COST_MULT = 601;
                    break;
                }
            case 6:
                {
                    RESET_POINTS_DPC = 51.5;
                    RESET_POINTS_DPS = 51.3;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 13.74;
                    RESET_ARMOR_COST_MULT = 721;
                    break;
                }
            case 7:
                {
                    RESET_POINTS_DPC = 60;
                    RESET_POINTS_DPS = 59.9;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 16.3;
                    RESET_ARMOR_COST_MULT = 841;
                    break;
                }
            case 8:
                {
                    RESET_POINTS_DPC = 67;
                    RESET_POINTS_DPS = 66.9;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 18.65;
                    RESET_ARMOR_COST_MULT = 961;
                    break;
                }
            default:
                {
                    RESET_POINTS_DPC = 180;
                    RESET_POINTS_DPS = 180;
                    RESET_POINTS_HP = 1;
                    RESET_POINTS_GOLD = 50;
                    RESET_ARMOR_COST_MULT = 1081;
                    break;
                }
        }
    }
    public void setResetsDone(int s)
    {
        resetsDone = s;
    }

    public void afterBossKilled()
    {
        int lvl = getEnemyLevel();
        int boss = 0;
        while(lvl >0)
        {
            lvl -= 30;
            boss += 1;
        }

        if(boss > maxBossesKilled)
        {
            maxBossesKilled = boss;
            specialPerks.POINTS++;
        }

    }

    void calculateLevelBar()
    {

        if (CURRENT_LEVEL == 30 || CURRENT_LEVEL == 60 || CURRENT_LEVEL == 90 || CURRENT_LEVEL == 120)
        {
            LEVEL_PROGRESS_BAR.current = LEVEL_PROGRESS_BAR.max;
            player.enemy.isBoss = true;
        }
        else
        {
            LEVEL_PROGRESS_BAR.current = CURRENT_LEVEL % 30;
            player.enemy.isBoss = false;
        }
    }
    public void LoadData(GameData data)
    {
        this.GOLD = data.GOLD;
        this.CURRENT_LEVEL = data.CURRENT_LEVEL;
        this.MAX_LEVEL = data.MAX_LEVEL;
        this.MAX_ZONE = data.MAX_ZONE;
        this.RESURRECT_LEVEL = data.RESURRECT_LEVEL;
        this.STAGE = data.STAGE;
        this.MAX_STAGE_REACHED = data.MAX_STAGE_REACHED;
        this.STAGE_COMPLETED = data.STAGE_COMPLETED;
        this.ZONE_NAME = data.ZONE_NAME;

        this.DPC = data.DPC;
        this.FLAT_DPC = data.FLAT_DPC;
        this.COMP1_DPC = data.COMP1_DPC;
        this.COMP2_DPC = data.COMP2_DPC;
        this.RESET_PERKS_DPC = data.RESET_PERKS_DPC;

        this.DPS = data.DPS;
        this.FLAT_DPS = data.FLAT_DPS;
        this.PERK_DPS = data.PERK_DPS;
        this.COMP1_DPS = data.COMP1_DPS;
        this.COMP2_DPS = data.COMP2_DPS;
        this.RESET_PERKS_DPS = data.RESET_PERKS_DPS;

        this.HP = data.HP;
        this.CURRENT_HP = data.CURRENT_HP;
        this.FLAT_HP = data.FLAT_HP;
        this.PERK_HP = data.PERK_HP;
        this.COMP1_HP = data.COMP1_HP;
        this.COMP2_HP = data.COMP2_HP;
        this.RESET_PERKS_HP = data.RESET_PERKS_HP;

        this.ARMOR = data.ARMOR;
        this.FLAT_ARMOR = data.FLAT_ARMOR;
        this.PERK_ARMOR = data.PERK_ARMOR;
        this.COMP1_ARMOR = data.COMP1_ARMOR;
        this.COMP2_ARMOR = data.COMP2_ARMOR;
        this.RESET_POINTS_ARMOR = data.RESET_POINTS_ARMOR;
        this.RESET_PERKS_ARMOR = data.RESET_PERKS_ARMOR;

        this.ARMOR_PEN = data.ARMOR_PEN;

        this.resetsDone = data.RESETS_DONE;
        this.MAX_LEVEL_REACHED = data.MAX_LEVEL_REACHED;

        //prestige
        this.RESET_POINTS_DPC = data.RESET_POINTS_DPC;
        this.RESET_POINTS_DPS = data.RESET_POINTS_DPS;
        this.RESET_POINTS_HP = data.RESET_POINTS_HP;
        this.RESET_POINTS_GOLD = data.RESET_POINTS_GOLD;
        this.maxBossesKilled = data.maxBossesKilled;


        perks.calculateAll();
        setStats();
        fullHeal();
        HP_BAR.max = HP;
        HP_BAR.current = CURRENT_HP;
        calculateLevelBar();

        if (CURRENT_LEVEL <= 30)
        {
            landColor.changeColor(1);
            backgroundRenderer.sprite = zone1;
        }

        if (CURRENT_LEVEL > 30 && CURRENT_LEVEL <= 60)
        {
            landColor.changeColor(2);
            backgroundRenderer.sprite = zone2;
        }

        if (CURRENT_LEVEL > 60 && CURRENT_LEVEL <= 90)
        {
            landColor.changeColor(3);
            backgroundRenderer.sprite = zone3;
        }

        if (CURRENT_LEVEL > 90 && CURRENT_LEVEL <= 120)
        {
            landColor.changeColor(4);
            backgroundRenderer.sprite = zone4;
        }


    }

   

    public void SaveData(GameData data)
    {
        data.GOLD = this.GOLD;
        data.CURRENT_LEVEL = this.CURRENT_LEVEL;
        data.MAX_LEVEL = this.MAX_LEVEL;
        data.MAX_ZONE = this.MAX_ZONE;
        data.RESURRECT_LEVEL =this.RESURRECT_LEVEL;
        data.STAGE = this.STAGE;
        data.MAX_STAGE_REACHED = this.MAX_STAGE_REACHED;
        data.STAGE_COMPLETED = this.STAGE_COMPLETED;
        data.ZONE_NAME = this.ZONE_NAME;

        data.DPC = this.DPC;
        data.FLAT_DPC = this.FLAT_DPC;
        data.COMP1_DPC = this.COMP1_DPC;
        data.COMP2_DPC = this.COMP2_DPC;
        data.RESET_PERKS_DPC = this.RESET_PERKS_DPC;

        data.DPS = this.DPS;
        data.FLAT_DPS = this.FLAT_DPS;
        data.PERK_DPS = this.PERK_DPS;
        data.COMP1_DPS = this.COMP1_DPS;
        data.COMP2_DPS = this.COMP2_DPS;
        data.RESET_PERKS_DPS = this.RESET_PERKS_DPS;

        data.HP = this.HP;
        data.CURRENT_HP = this.CURRENT_HP;
        data.FLAT_HP = this.FLAT_HP;
        data.PERK_HP = this.PERK_HP;
        data.COMP1_HP = this.COMP1_HP;
        data.COMP2_HP = this.COMP2_HP;
        data.RESET_PERKS_HP = this.RESET_PERKS_HP;

        data.ARMOR = this.ARMOR;
        data.FLAT_ARMOR = this.FLAT_ARMOR;
        data.PERK_ARMOR = this.PERK_ARMOR;
        data.COMP1_ARMOR = this.COMP1_ARMOR;
        data.COMP2_ARMOR = this.COMP2_ARMOR;
        data.RESET_POINTS_ARMOR = this.RESET_POINTS_ARMOR;
        data.RESET_PERKS_ARMOR = this.RESET_PERKS_ARMOR;

        data.ARMOR_PEN = this.ARMOR_PEN;

        data.MAX_LEVEL_REACHED = this.MAX_LEVEL_REACHED;
        data.RESETS_DONE = resetsDone;


        //prestige
        data.RESET_POINTS_DPC = this.RESET_POINTS_DPC;
        data.RESET_POINTS_DPS = this.RESET_POINTS_DPS;
        data.RESET_POINTS_GOLD = this.RESET_POINTS_GOLD;
        data.maxBossesKilled = this.maxBossesKilled;
    }

    public void afterLoadData()
    {
        companion.hireAfterLoad();
        setStats();
    }


}
