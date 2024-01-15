using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NumberManager : MonoBehaviour//Minigame
{
    public int Clear = 0;
    public short Level = 1;
    public short digit = 1;
    public int PlayerHp = 2; //실제 플레이어 체력은 3
    public ShowTMP showTMP;
    public TMP_InputField Inputvalue;
    //public Hide answer;
    long ShowingNumber = 0;
    long EnterNumber;
    public float ShowTime = 1.5f;
    public float imgTime = 2.0f;

    


    
    


    // Start is called before the first frame update
    void Start()
    {

        Startset();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        LevelSystem();
        if (Inputvalue.interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Enter();
            }
        }
         

    }

    void Enter()
    {
        
        InputNumber();

        if(ShowingNumber == EnterNumber)
        {
            
            //answer.Correct(2.0f);
            
            Clear++;
            //Debug.Log(EnterNumber);
            Debug.Log("정답");
            Startset();
        }
        else
        {
            if (PlayerHp == 0)
            {
                Debug.Log("게임 끝");
                GameOver();
                
            }
            else
            {
                PlayerHp--;
                Debug.Log("오답");
                Startset();
            }
            //answer.wronganswer(2.0f);
            
            //Debug.Log(EnterNumber);
            
            
        }
    }

    void LevelSystem()
    {   
        if (Clear == 7)
        {
            Level++;
            Debug.Log("레벨 업");
            digit = Level;
            Debug.Log("자릿수 변경");
            Clear = 0;
        }
        
                  
    }

    void GameOver()
    {
        if (PlayerHp == 0)
        {
            Invoke("EndingTime", ShowTime);       
        }
    }
    void Number()
    {        
        ShowingNumber = Random.Range((int)Mathf.Pow(1, digit), (int)Mathf.Pow(10, digit));

        showTMP.TextChange(ShowingNumber.ToString(), ShowTime);
        Debug.Log(ShowingNumber);
        
    }

    void InputNumber()
    {
        EnterNumber = int.Parse(Inputvalue.text);        
    }

    void Startset()
    {
        Number();
        Inputvalue.interactable = false;
        Invoke("InputUnlock", ShowTime);
    }

    void InputUnlock()
    {
        Inputvalue.interactable = true;
    }

    void EndingTime()
    {
        SceneManager.instance.NextGame();
    }
}
