using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTMP : MonoBehaviour
{
    
    //public string a;

    [SerializeField] TextMeshProUGUI MainText;
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

    //public void NullTextChange(string TextMeshProUGUI)
    //{
    //    MainText.text = null;
    //}

    //[SerializeField] TextMeshProUGUI ChangeText;
    //public void EnterChangeText(string TextMeshProUGUI)
    //{
    //    TextMeshProUGUI = a;
    //}

}
