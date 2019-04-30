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

public class Manager : MonoBehaviour
{
#pragma warning disable 0649
#pragma warning disable 0414
    #region Info setup
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
    [SerializeField]
    private TMP_Text testText;

    private string[] firstList;
    private string[] secondList;
    private string[] thirdList;
    
    private bool setFirst = false;
    private bool setSecond = false;
    private bool setThird = false;
    private bool resetCheck = false;

    #endregion
    public void StartUp()
    {
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            holdSetting = ReadTextFile(settingStringPC);
            holdDescript = ReadTextFile(descriptStringPC);
            holdBase = ReadTextFile(baseStringPC);

            holdSettingReset = ReadTextFile(settingStringDefaultPC);
            holdDescriptReset = ReadTextFile(descriptStringDefaultPC);
            holdBaseReset = ReadTextFile(baseStringDefaultPC);

        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            testText.text = "android is on";
            //holdSettingReset = MakeSettingsFile("/SettingReset.txt");
            //holdDescriptReset = MakeDescriptFile("/Descript.txt");
            //holdBaseReset = MakeBaseFile("/Base.txt");

            if (File.Exists(Application.persistentDataPath + "/Setting.txt"))
            {
                testText.text = "files already here";
                holdSetting = MakeSettingsFile("/Setting.txt");
            }
            else
            {
                testText.text = "new files made";
                holdSetting = MakeSettingsFile("/Setting.txt");

            }

            if (File.Exists(Application.persistentDataPath + "/Descript.txt"))
            {
                holdDescript = MakeDescriptFile("/Descript.txt");
            }
            else
            {
                holdDescript = MakeDescriptFile("/Descript.txt");
                
                testText.text = "new files made";
            }
            
            if (File.Exists(Application.persistentDataPath + "/Base.txt"))
            {
                holdBase = MakeBaseFile("/Base.txt");
            }
            else
            {
                holdBase = MakeBaseFile("/Base.txt");
                testText.text = "new files made";

            }
        }
        else
        {
            holdSetting = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Settings.txt"));
            holdDescript = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Descript.txt"));
            holdBase = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Base.txt"));

            holdSettingReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/SettingReset.txt"));
            holdDescriptReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/DescriptReset.txt"));
            holdBaseReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/BaseReset.txt"));

        }



        firstList = holdSetting.Split('\n');
        secondList = holdDescript.Split('\n');
        thirdList = holdBase.Split('\n');
    }

    #region setting files
    private string MakeSettingsFile(string pathEnd)
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
            "\nSteampunk Cyberpunk" +
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
            "\nCute Relaxing" +
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
            "\nGreek");
        writer.Close();

        StreamReader read = new StreamReader(pathEnd, true);
        string entry = read.ReadToEnd();
        read.Close();
        return entry;
    }

    #endregion

    #region description files
    private string MakeDescriptFile(string pathEnd)
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
            "\nDungeon - Crawling" +
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
            "\nWeather - based" +
            "\nTraveling" +
            "\nCleaning" +
            "\nInventory" +
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
            "\nConsole-controlled" +
            "\nPaper-folding" +
            "\nTeam-based" +
            "\nMineral-based" +
            "\nSize-based" +
            "\nGardening");
        writer.Close();

        StreamReader read = new StreamReader(pathEnd, true);
        string entry = read.ReadToEnd();
        read.Close();
        return entry;
    }
    #endregion

    #region Base files
    private string MakeBaseFile(string pathEnd)
    {
        string path = Application.persistentDataPath + pathEnd;
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write("RPG" +
            "Fighting" +
            "Puzzle" +
            "Beat'em Up" +
            "Dating Sim" +
            "Simulator" +
            "Rhythm" +
            "Platformer" +
            "Racing" +
            "Sports" +
            "Shooter" +
            "Survival" +
            "Shoot'em Up" +
            "Card Game" +
            "Arena" +
            "Strategy" +
            "Management" +
            "Board" +
            "Builder" +
            "Stealth" +
            "Tower Defense" +
            "Fishing" +
            "Hunting" +
            "Hack and Slash" +
            "Horror" +
            "Idle" +
            "Farming" +
            "Arcade" +
            "Exploration" +
            "Runner" +
            "Pinball" +
            "Mining" +
            "MMO" +
            "Action" +
            "Adventure" +
            "Bullet Hell" +
            "Cooking" +
            "Typing" +
            "Pinball" +
            "Physics" +
            "Hidden Objects" +
            "MOBA" +
            "Battle Royal" +
            "RTS" +
            "Dungeon Crawler" +
            "Table Top" +
            "Simulation" +
            "Party" +
            "Walking Sim" +
            "Visual Novel" +
            "Point & Click" +
            "Action RPG" +
            "Action Adventure" +
            "JRPG" +
            "CRPG" +
            "Chess" +
            "Golf" +
            "Escape" +
            "Pet Sim" +
            "Baseball" +
            "Basketball" +
            "Snowboarding" +
            "Mini Golf" +
            "Tennis" +
            "Skateboarding" +
            "Hockey" +
            "Bowling" +
            "God" +
            "Brawler" +
            "Ping Pong" +
            "Dress-up");
        writer.Close();

        StreamReader read = new StreamReader(pathEnd, true);
        string entry = read.ReadToEnd();
        read.Close();
        return entry;
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
        if(setFirst)
        {
            firstRoll.text = firstList[Random.Range(0, firstList.Length)].ToString();
        }
        if (setSecond)
        {
            secondRoll.text = secondList[Random.Range(0, secondList.Length)].ToString();
        }
        if (setThird)
        {
            thirdRoll.text = thirdList[Random.Range(0, thirdList.Length)].ToString();
            testText.text = "Roulette activated";
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
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                AddNew(settingStringPC, line);
                holdSetting = ReadTextFile(settingStringPC);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                AddNew(Application.persistentDataPath + "/Settings.txt", line);
                holdSetting = ReadTextFile(Application.persistentDataPath + "/Settings.txt");
                testText.text = "Setting added";
            }
            else
            {
                AddNew(Path.Combine(Application.streamingAssetsPath + "/Settings.txt"), line);
                holdSetting = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Settings.txt"));
            }

            firstList = holdSetting.Split('\n');
        }
        else if (checkString == "Input New Descript")
        {
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                AddNew(descriptStringPC, line);
                holdDescript = ReadTextFile(descriptStringPC);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                AddNew(Application.persistentDataPath + "/Descript.txt", line);
                holdDescript = ReadTextFile(Application.persistentDataPath + "/Descript.txt");
                testText.text = "Description added";
            }
            else
            {
                AddNew(Path.Combine(Application.streamingAssetsPath + "/Descript.txt"), line);
                holdDescript = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Descript.txt"));
            }
            
            secondList = holdDescript.Split('\n');
        }
        else if (true)
        {
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                AddNew(baseStringPC, line);
                holdBase = ReadTextFile(baseStringPC);
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                AddNew(Application.persistentDataPath + "/Base.txt", line);
                holdBase = ReadTextFile(Application.persistentDataPath + "/Base.txt");
                testText.text = "Base added";
            }
            else
            {
                AddNew(Path.Combine(Application.streamingAssetsPath + "/Base.txt"), line);
                holdBase = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Base.txt"));
            }
            
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
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                StreamWriter firstSet = new StreamWriter(settingStringPC, false);
                firstSet.Write(holdSettingReset);
                firstSet.Close();
                StreamWriter secondSet = new StreamWriter(descriptStringPC, false);
                secondSet.Write(holdDescriptReset);
                secondSet.Close();
                StreamWriter thirdSet = new StreamWriter(baseStringPC, false);
                thirdSet.Write(holdBaseReset);
                thirdSet.Close();
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                StreamWriter firstSet = new StreamWriter(Application.persistentDataPath + "/Settings.txt", false);
                firstSet.Write(holdSettingReset);
                firstSet.Close();
                StreamWriter secondSet = new StreamWriter(Application.persistentDataPath + "/Descript.txt", false);
                secondSet.Write(holdDescriptReset);
                secondSet.Close();
                StreamWriter thirdSet = new StreamWriter(Application.persistentDataPath + "/Base.txt", false);
                thirdSet.Write(holdBaseReset);
                thirdSet.Close();
                testText.text = "Reset ";
            }
            else
            {
                StreamWriter firstSet = new StreamWriter(Path.Combine(Application.streamingAssetsPath + "/Settings.txt"), false);
                firstSet.Write(holdSettingReset);
                firstSet.Close();
                StreamWriter secondSet = new StreamWriter(Path.Combine(Application.streamingAssetsPath + "/Descript.txt"), false);
                secondSet.Write(holdDescriptReset);
                secondSet.Close();
                StreamWriter thirdSet = new StreamWriter(Path.Combine(Application.streamingAssetsPath + "/Base.txt"), false);
                thirdSet.Write(holdBaseReset);
                thirdSet.Close();
            }
            
            
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


