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

    // Start is called before the first frame update
    void Start()
    {

        if (File.Exists(Path.Combine(Application.streamingAssetsPath + "/Settings.txt")))
        {
            testText.text = "file exist";
        }
        else
        {
            testText.text = "false";
        }

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

            holdSetting = ReadTextFile(Application.persistentDataPath + "/Setting.txt");
            holdDescript = ReadTextFile(Application.persistentDataPath + "/Descript.txt");
            holdBase = ReadTextFile(Application.persistentDataPath + "/Base.txt");

            holdSettingReset = ReadTextFile(Application.persistentDataPath + "/SettingReset.txt");
            holdDescriptReset = ReadTextFile(Application.persistentDataPath + "/DescriptReset.txt");
            holdBaseReset = ReadTextFile(Application.persistentDataPath + "/BaseReset.txt");


        }
        else
        {
            holdSetting = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Settings.txt"));
            holdDescript = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Descript.txt"));
            holdBase = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/Base.txt"));

            holdSettingReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/SettingReset.txt"));
            holdDescriptReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/DescriptReset.txt"));
            holdBaseReset = ReadTextFile(Path.Combine(Application.streamingAssetsPath + "/BaseReset.txt"));

            if (File.Exists(Path.Combine(Application.streamingAssetsPath + "/Settings.txt")))
            {
                testText.text = "ham";
            }
            else
            {
                testText.text = "false";
            }
        }

        

        firstList = holdSetting.Split('\n');
        secondList = holdDescript.Split('\n');
        thirdList = holdBase.Split('\n');
        
    }
    
    private string ReadTextFile(string path)
    {
        string text;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        text = reader.ReadToEnd();
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
}

 

public class GenreList
{

    public List<string> stuff = new List<string>();
    public string choice;
    static Random random = new Random();


    public void makeList(string input)
    {
        stuff.Add(input);
    }
    public string roulette()
    {
        int rnd = Random.Range(0,stuff.Count);
        choice = stuff[rnd];
        return choice;
    }
}
