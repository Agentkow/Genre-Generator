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
    private string settingString = "Assets/Resources/Setting.txt";
    private string descriptString = "Assets/Resources/Descript.txt";
    private string baseString = "Assets/Resources/Base.txt";

    private string settingStringDefault = "Assets/Resources/SettingReset.txt";
    private string descriptStringDefault = "Assets/Resources/DescriptReset.txt";
    private string baseStringDefault = "Assets/Resources/BaseReset.txt";

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
    
    private bool setFirst = false;
    private bool setSecond = false;
    private bool setThird = false;
    private bool resetCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        holdSetting = ReadTextFile(settingString);
        holdDescript = ReadTextFile(settingString);
        holdBase = ReadTextFile(settingString);

        holdSettingReset = ReadTextFile(settingStringDefault);
        holdDescriptReset = ReadTextFile(descriptStringDefault);
        holdBaseReset = ReadTextFile(baseStringDefault);

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
            AddNew(settingString, line);
            holdSetting = ReadTextFile(settingString);
            firstList = holdSetting.Split('\n');
        }
        else if (checkString == "Input New Descript")
        {
            AddNew(descriptString, line);
            holdDescript = ReadTextFile(settingString);
            secondList = holdDescript.Split('\n');
        }
        else if (true)
        {
            AddNew(baseString, line);
            holdBase = ReadTextFile(settingString);
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
            StreamWriter firstSet = new StreamWriter(settingString, false);
            firstSet.Write(holdSettingReset);
            firstSet.Close();
            StreamWriter secondSet = new StreamWriter(descriptString, false);
            secondSet.Write(holdDescriptReset);
            secondSet.Close();
            StreamWriter thirdSet = new StreamWriter(baseString, false);
            thirdSet.Write(holdBaseReset);
            thirdSet.Close();
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
