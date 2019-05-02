using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    [SerializeField]
    private Sprite unlock;
    [SerializeField]
    private Sprite locked;

    private Image lockImage;
    private  bool unlocked = true;

    private void Start()
    {
        lockImage = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            lockImage.sprite = unlock;
        }
        else
        {
            lockImage.sprite = locked;
        }
    }

    public void ChangeLock()
    {
        if (unlocked)
        {
            unlocked = false;
        }
        else
        {
            unlocked = true;
        }
    }
}
