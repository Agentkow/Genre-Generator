using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEditor;
using System;

public class Manager : MonoBehaviour
{
#pragma warning disable 0649
#pragma warning disable 0414
    #region Variables
    private string settingStringPC = "Assets/Resources/Setting.txt";
    private string descriptStringPC = "Assets/Resources/Descript.txt";
    private string baseStringPC = "Assets/Resources/Base.txt";

    private string settingStringDefaultPC = "Assets/Resources/SettingReset.txt";
    private string descriptStringDefaultPC = "Assets/Resources/DescriptReset.txt";
    private string baseStringDefaultPC = "Assets/Resources/BaseReset.txt";

    private string setting = "Setting";
    private string descript ="Descript";
    private string bases = "Base";
    
    private string holdSetting;
    private string holdDescript;
    private string holdBase;

    private string holdSettingReset;
    private string holdDescriptReset;
    private string holdBaseReset;

    private TextAsset list_1;
    private TextAsset list_2;
    private TextAsset list_3;

    [SerializeField]
    private TextMeshProUGUI firstRoll;
    [SerializeField]
    private TextMeshProUGUI secondRoll;
    [SerializeField]
    private TextMeshProUGUI thirdRoll;

    [SerializeField]
    private TMP_Text resetText;

    private string[] firstList;
    private string[] secondList;
    private string[] thirdList;

    [SerializeField]
    private bool setFirst = false;
    [SerializeField]
    private bool setSecond = false;
    [SerializeField]
    private bool setThird = false;

    private bool resetCheck = false;
    
    private bool firstLock = true;
    private bool secondLock = true;
    private bool thirdLock = true;

    
    #endregion
    public void StartUp()
    {
        
#if UNITY_EDITOR
        holdSetting = ReadTextFile(settingStringPC);
        holdDescript = ReadTextFile(descriptStringPC);
        holdBase = ReadTextFile(baseStringPC);

        holdSettingReset = ReadTextFile(settingStringDefaultPC);
        holdDescriptReset = ReadTextFile(descriptStringDefaultPC);
        holdBaseReset = ReadTextFile(baseStringDefaultPC);
#else
        if (File.Exists(Application.persistentDataPath + "/Setting.txt"))
        {

            holdSetting = ReadTextFile(Application.persistentDataPath + "/Setting.txt");
            holdSettingReset = ReadTextFile(Application.persistentDataPath + "/SettingReset.txt");

        }
        else
        {
            MakeSettingsFile("/Setting.txt");
            holdSetting = ReadTextFile(Application.persistentDataPath + "/Setting.txt");
            holdSettingReset = ReadTextFile(Application.persistentDataPath + "/SettingReset.txt");

        }

        if (File.Exists(Application.persistentDataPath + "/Descript.txt"))
        {
            holdDescript = ReadTextFile(Application.persistentDataPath + "/Descript.txt");
            holdDescriptReset = ReadTextFile(Application.persistentDataPath + "/DescriptReset.txt");
        }
        else
        {
            MakeDescriptFile("/Descript.txt");
            holdDescript = ReadTextFile(Application.persistentDataPath + "/Descript.txt");
            holdDescriptReset = ReadTextFile(Application.persistentDataPath + "/DescriptReset.txt");
        }

        if (File.Exists(Application.persistentDataPath + "/Base.txt"))
        {
            holdBase = ReadTextFile(Application.persistentDataPath + "/Base.txt");
            holdBaseReset = ReadTextFile(Application.persistentDataPath + "/BaseReset.txt");
        }
        else
        {
            MakeBaseFile("/Base.txt");
            holdBase = ReadTextFile(Application.persistentDataPath + "/Base.txt");
            holdBaseReset = ReadTextFile(Application.persistentDataPath + "/BaseReset.txt");
        }

#endif



        firstList = holdSetting.Split('\n');
        secondList = holdDescript.Split('\n');
        thirdList = holdBase.Split('\n');
    }

#region setting files
    public void MakeSettingsFile(string pathEnd)
    {
        string path = Application.persistentDataPath + pathEnd;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write("Retro" +
            "\nSubnautical" +
            "\nWild West" +
            "\nGrim-dark" +
            "\nZombie" +
            "\nSci-Fi" +
            "\nMedieval" +
            "\nPost-apocaliptic" +
            "\nSteampunk" +
            "\nCyberpunk" +
            "\nFantasy" +
            "\nMilitary" +
            "\nPrehistoric" +
            "\nPirate" +
            "\nDetective" +
            "\nSupernatural" +
            "\nGothic" +
            "\nAbstract" +
            "\nModern" +
            "\nSub-Terranean" +
            "\nPolitical" +
            "\nLovecraftian" +
            "\nDystopian" +
            "\nNordic" +
            "\nSuper Hero" +
            "\nMythological" +
            "\nDisco" +
            "\nAtmospheric" +
            "\nMedical" +
            "\nTime-Traveling" +
            "\nPhilisophical" +
            "\nCartoony" +
            "\nScientific" +
            "\nNaval" +
            "\nAerial" +
            "\nHand-drawn" +
            "\nAlien" +
            "\nFuturistic" +
            "\nMinimalistic" +
            "\nTribal" +
            "\nRobotic" +
            "\nNinja" +
            "\nPsychedelic" +
            "\nCulinary" +
            "\nOriental " +
            "\nGrotesque" +
            "\nEgyptian" +
            "\nRoman" +
            "\nArctic" +
            "\nTechnological" +
            "\nMagical" +
            "\nEducational" +
            "\nMonster" +
            "\nRealistic" +
            "\nKung-fu" +
            "\nAnime" +
            "\nEnvironmental" +
            "\nCute" +
            "\nRelaxing" +
            "\nParkour" +
            "\nDemonic" +
            "\nVoxel" +
            "\nCyberspace" +
            "\nSpiritual" +
            "\nMechanical" +
            "\nRussian" +
            "\n2.5D" +
            "\n3D" +
            "\n2D" +
            "\nRealistic" +
            "\nStylized" +
            "\nReligious" +
            "\nBiological" +
            "\nNSFW" +
            "\nFashionistic" +
            "\nComedic" +
            "\nAthletic" +
            "\nJanitorial" +
            "\nBrutal" +
            "\nBusiness" +
            "\nExperimental" +
            "\nRenaissance" +
            "\nLow Poly" +
            "\nHigh Poly" +
            "\nPixel" +
            "\n16-bit" +
            "\n64-bit" +
            "\nMental" +
            "\nVaporwave" +
            "\nSynthwave" +
            "\nCold War" +
            "\nWorld War 2" +
            "\nWorld War 1" +
            "\nTranshumanistic" +
            "\n1990's" +
            "\n1980's" +
            "\nHistorical" +
            "\n1-bit" +
            "\n8-bit" +
            "\nCriminal" +
            "\nLofi" +
            "\nAquatic" +
            "\nDifficult" +
            "\nFamily Friendly" +
            "\nBritish" +
            "\nBreakfast" +
            "\nSuburban" +
            "\nOrigami" +
            "\nGreek" +
            "\nGladitorial" +
            "\nFestive" +
            "\nSpooky" +
            "\nChinese" +
            "\nVHS");
        writer.Close();
    }

#endregion

#region description files
    private void MakeDescriptFile(string pathEnd)
    {
        string path = Application.persistentDataPath + pathEnd;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write("Psychological" +
            "\nCrafting" +
            "\nThird Person" +
            "\nReal-Time" +
            "\nRogue-like" +
            "\nRogue-lite" +
            "\nPvP" +
            "\nFirst Person" +
            "\nCo-op" +
            "\nOpen World" +
            "\nDungeon-Crawling" +
            "\nMetroidvania" +
            "\nTactical" +
            "\nNoir" +
            "\nText-based" +
            "\nAgricultural" +
            "\nEconomic" +
            "\nSandbox" +
            "\nSide Scroller" +
            "\nTurn-based" +
            "\nInvestigative" +
            "\nDiplomatic" +
            "\nMusical" +
            "\nIsometric" +
            "\nBase-Building" +
            "\nMatching 3" +
            "\nGrid - based" +
            "\nTrading" +
            "\nPvE" +
            "\nTop-Down" +
            "\nFlying" +
            "\nParty-based" +
            "\nArchitectural" +
            "\nClass-based" +
            "\nViolent" +
            "\nArtistic" +
            "\nPuzzling" +
            "\nCreature-Catching" +
            "\nCompetitive" +
            "\nVR" +
            "\nConstruction" +
            "\nDrawing" +
            "\nSpy" +
            "\nHacking" +
            "\nProgramming" +
            "\nFashion" +
            "\nDesigning" +
            "\nSpace" +
            "\n2.5D" +
            "\n3D" +
            "\n2D" +
            "\nWeather-based" +
            "\nTraveling" +
            "\nCleaning" +
            "\nInventory-Managing" +
            "\nAlchemy" +
            "\nBrewing" +
            "\nShopping" +
            "\nDriving" +
            "\nLoot-based" +
            "\nSailing" +
            "\nMystery" +
            "\nMeme-based" +
            "\nSingleplayer" +
            "\nMultiplayer" +
            "\nAR" +
            "\nSniping" +
            "\nAssassin" +
            "\nSpelling" +
            "\nNonlinear" +
            "\nItem-based" +
            "\nGangster" +
            "\nMassive Multiplayer" +
            "\n3 Vs 3" +
            "\nBoss Rush" +
            "\nBlacksmithing" +
            "\nShopkeeping" +
            "\nDice-based" +
            "\nCard-based" +
            "\nLumberjacking" +
            "\nMech Driving" +
            "\nMoney-based" +
            "\nResearching" +
            "\nClimbing" +
            "\nClue-based" +
            "\nDemolition" +
            "\nChemical-based" +
            "\nChristmas" +
            "\nPaper-folding" +
            "\nTeam-based" +
            "\nMineral-based" +
            "\nSize-based" +
            "\nGardening" +
            "\nScavenging" +
            "\nMotion-controlled" +
            "\nHalloween");
        writer.Close();
    }
#endregion

#region Base files
    private void MakeBaseFile(string pathEnd)
    {
        string path = Application.persistentDataPath + pathEnd;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write("RPG" +
            "\nFighting" +
            "\nPuzzle" +
            "\nBeat'em Up" +
            "\nDating Sim" +
            "\nSimulator" +
            "\nRhythm" +
            "\nPlatformer" +
            "\nRacing" +
            "\nSports" +
            "\nShooter" +
            "\nSurvival" +
            "\nShoot'em Up" +
            "\nCard Game" +
            "\nArena" +
            "\nStrategy" +
            "\nManagement" +
            "\nBoard" +
            "\nBuilder" +
            "\nStealth" +
            "\nTower Defense" +
            "\nFishing" +
            "\nHunting" +
            "\nHack and Slash" +
            "\nHorror" +
            "\nIdle" +
            "\nFarming" +
            "\nArcade" +
            "\nExploration" +
            "\nRunner" +
            "\nPinball" +
            "\nMining" +
            "\nMMO" +
            "\nAction" +
            "\nAdventure" +
            "\nBullet Hell" +
            "\nCooking" +
            "\nTyping" +
            "\nPinball" +
            "\nPhysics" +
            "\nHidden Objects" +
            "\nMOBA" +
            "\nBattle Royal" +
            "\nRTS" +
            "\nDungeon Crawler" +
            "\nTable Top" +
            "\nSimulation" +
            "\nParty" +
            "\nWalking Sim" +
            "\nVisual Novel" +
            "\nPoint & Click" +
            "\nAction RPG" +
            "\nAction Adventure" +
            "\nJRPG" +
            "\nCRPG" +
            "\nChess" +
            "\nGolf" +
            "\nEscape" +
            "\nPet Sim" +
            "\nBaseball" +
            "\nBasketball" +
            "\nSnowboarding" +
            "\nMini Golf" +
            "\nTennis" +
            "\nSkateboarding" +
            "\nHockey" +
            "\nBowling" +
            "\nGod" +
            "\nBrawler" +
            "\nPing Pong" +
            "\nDress-up" +
            "\nMaker");
        writer.Close();
        
    }
#endregion

#region Base program
    private string ReadTextFile(string path)
    {
        string text;
            StreamReader reader = new StreamReader(path, true);
            text = reader.ReadToEnd();
            //testText.text = "all files read";
            reader.Close();
            return text;
       
    }
    
    private void FixedUpdate()
    {
        if(setFirst && firstLock)
        {
            firstRoll.text = firstList[UnityEngine.Random.Range(0, firstList.Length)].ToString();
        }
        if (setSecond && secondLock)
        {
            secondRoll.text = secondList[UnityEngine.Random.Range(0, secondList.Length)].ToString();
        }
        if (setThird && thirdLock)
        {
            thirdRoll.text = thirdList[UnityEngine.Random.Range(0, thirdList.Length)].ToString();
        }
    }


    public void Roulette()
    {
        setFirst = true;
        StartCoroutine(FirstTimer());

        setSecond = true;
        StartCoroutine(SecondTimer());

        setThird = true;
        StartCoroutine(ThirdTimer());

    }
    
    public void FirstLock()
    {
        if (firstLock)
        {
            firstLock = false;
        }
        else
        {
            firstLock = true;
        }
    }
    public void SecondLock()
    {
        if (secondLock)
        {
            secondLock = false;
        }
        else
        {
            secondLock = true;
        }
    }
    public void ThirdLock()
    {
        if (thirdLock)
        {
            thirdLock = false;
        }
        else
        {
            thirdLock = true;
        }
    }

    IEnumerator FirstTimer()
    {
        yield return new WaitForSeconds(0.4f);
        setFirst = false;
    }
    IEnumerator SecondTimer()
    {
        yield return new WaitForSeconds(0.7f);
        setSecond= false;
    }
    IEnumerator ThirdTimer()
    {
        yield return new WaitForSeconds(1f);
        setThird = false;
    }

    public void SettingAdd(string checkString, string line)
    {
        if (checkString == "Input New Setting")
        {
#if UNITY_EDITOR
            AddNew(settingStringPC, line);
            holdSetting = ReadTextFile(settingStringPC);
#else
            AddNew(Application.persistentDataPath + "/Settings.txt", line);
            holdSetting = ReadTextFile(Application.persistentDataPath + "/Settings.txt");
#endif
            

            firstList = holdSetting.Split('\n');
        }
        else if (checkString == "Input New Descript")
        {

#if UNITY_EDITOR
            AddNew(descriptStringPC, line);
            holdDescript = ReadTextFile(descriptStringPC);
#else
            AddNew(Application.persistentDataPath + "/Descript.txt", line);
                holdDescript = ReadTextFile(Application.persistentDataPath + "/Descript.txt");
#endif
            
            secondList = holdDescript.Split('\n');
        }
        else if (checkString == "Input New Base")
        {
#if UNITY_EDITOR
            AddNew(baseStringPC, line);
            holdBase = ReadTextFile(baseStringPC);
#else
            AddNew(Application.persistentDataPath + "/Base.txt", line);
            holdBase = ReadTextFile(Application.persistentDataPath + "/Base.txt");
#endif
            
            thirdList = holdBase.Split('\n');
        }
        
    }

    private void AddNew(string path, string addLine)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write('\n'+addLine);
        writer.Close();
        
    }

    public void Reset()
    {
        if (resetCheck)
        {
#if UNITY_EDITOR
            StreamWriter firstSet = new StreamWriter(settingStringPC, false);
            firstSet.Write(holdSettingReset);
            firstSet.Close();
            StreamWriter secondSet = new StreamWriter(descriptStringPC, false);
            secondSet.Write(holdDescriptReset);
            secondSet.Close();
            StreamWriter thirdSet = new StreamWriter(baseStringPC, false);
            thirdSet.Write(holdBaseReset);
            thirdSet.Close();
#else
            StreamWriter firstSet = new StreamWriter(Application.persistentDataPath + "/Settings.txt", false);
            firstSet.Write(holdSettingReset);
            firstSet.Close();
            StreamWriter secondSet = new StreamWriter(Application.persistentDataPath + "/Descript.txt", false);
            secondSet.Write(holdDescriptReset);
            secondSet.Close();
            StreamWriter thirdSet = new StreamWriter(Application.persistentDataPath + "/Base.txt", false);
            thirdSet.Write(holdBaseReset);
            thirdSet.Close();
#endif
            
            
            resetText.text = "All lists reset to default";
            resetCheck = false;
        }
        else
        {
            resetText.text = "Are you sure?";
            resetCheck = true;
        }
        
    }

    public void resetTextDefault()
    {
        resetText.text = "Reset all list to default";
    }


    public void Quit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
               Application.Quit ();
#endif
    }
#endregion
}


