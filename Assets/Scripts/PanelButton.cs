using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelButton : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject setField;
    [SerializeField]
    private GameObject setButton;
    [SerializeField]
    private TMP_Text setText;
    public bool addCheck = true;

    public void SetCheck()
    {
        if (addCheck)
        {
            setButton.SetActive(true);
            setField.SetActive(true);
            addCheck = false;
        }
        else
        {
            setButton.SetActive(false);
            setField.SetActive(false);
            setText.text = "";
            addCheck = true;
        }
    }
}
