using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    public void SelectionOption()
    {
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        LevelManager.Instance.CheckPlayerState();
    }

}
