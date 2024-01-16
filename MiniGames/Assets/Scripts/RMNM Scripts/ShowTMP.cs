using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTMP : MonoBehaviour
{
    
    //public string a;

    [SerializeField] TextMeshProUGUI MainText;
    [SerializeField] TextMeshProUGUI userTime;
    [SerializeField] TextMeshProUGUI allTime;
    public void TextChange(string TextMeshProUGUI, float showTime)
    {
        MainText.text = TextMeshProUGUI;
        StartCoroutine(ShowTextTime(showTime));
    }

    private IEnumerator ShowTextTime(float showTime)
    {
        yield return new WaitForSeconds(showTime);
        MainText.text = string.Empty;
    }

    public void UserTime(string TextMeshProUGUI)
    {
        userTime.text = TextMeshProUGUI;
        userTime.text = string.Empty;
        
    }
    public void AllTime(string TextMeshProUGUI)
    {
        allTime.text = TextMeshProUGUI;
        userTime.text = string.Empty;
    }

}
