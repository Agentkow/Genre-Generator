using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private TextAsset list_1;
    [SerializeField]
    private TextAsset list_2;
    [SerializeField]
    private TextAsset list_3;

    [SerializeField]
    private TextMeshProUGUI firstRoll;
    [SerializeField]
    private TextMeshProUGUI secondRoll;
    [SerializeField]
    private TextMeshProUGUI thirdRoll;

    private string[] firstList;
    private string[] secondList;
    private string[] thirdList;

    // Start is called before the first frame update
    void Start()
    {
        string nd = "";
        string rd = "";
        string st = "";

        firstList = list_1.text.Split('\n');
        secondList = list_2.text.Split('\n');
        thirdList = list_3.text.Split('\n');

        st = list_1.ToString();
        nd = list_2.ToString();
        rd = list_3.ToString();

        

    }

    public void Roulette()
    {
        firstRoll.text = firstList[Random.Range(0, firstList.Length)].ToString();
        secondRoll.text = secondList[Random.Range(0, secondList.Length)].ToString();
        thirdRoll.text = thirdList[Random.Range(0, thirdList.Length)].ToString();

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
