using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buttons : MonoBehaviour
{
#pragma warning disable 0649
    private Manager manage;
    [SerializeField]
    private TMP_InputField setField;

    [SerializeField]
    private string setString;
    [SerializeField]
    private TMP_Text saveText;
    [SerializeField]
    private TMP_Text placeholder;

    private string enteredString;
    private bool check = false;

    private void Awake()
    {
        manage = GameObject.Find("Main Panel").GetComponent<Manager>();
    }

    public void TextSet()
    {
        enteredString = setField.text;
    }

    public void SaveCheck()
    {
        if (check && setField.text != "")
        {
            manage.SettingAdd(setString, enteredString);
            setField.text = "";
            saveText.text = "";
            this.gameObject.SetActive(false);
            setField.gameObject.SetActive(false);

        }
        else if(!check && setField.text == "")
        {
            saveText.text = "Empty";
        }
        else
        {
            saveText.text = "Save?";
            check = true;
        }
    }



}
