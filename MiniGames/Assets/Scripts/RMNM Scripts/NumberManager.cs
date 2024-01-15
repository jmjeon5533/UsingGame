using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NumberManager : MonoBehaviour//Minigame
{
    
    public short Level = 1;
    public short digit = 1;
    public int Clear = 0;
    public int PlayerHp = 2; //실제 플레이어 체력은 3
    public ShowTMP showTMP;
    public TMP_InputField Inputvalue;
    public TMP_InputField inputField;
    //public Hide answer;
    long ShowingNumber = 0;
    long EnterNumber;
    public float ShowTime = 1.5f;
    public float imgTime = 2.0f;
    public float taypingtime = 10.0f;
    public float alltime = 100.0f;
    bool isPaused = false;
    void StartTime()
    {
        //startTime = Time.time;
        //timeManager.StartTimer(10.0f);
        //isPaused = false;
        if (!isPaused)
        {
            if (alltime > 0)
            {
                taypingtime -= Time.deltaTime;
                alltime = alltime - (10 - taypingtime);
                alltime = Mathf.Max(0, alltime);
            }

            if (alltime == 0)
            {
                GameOver();
            
            }

        }
    }
    void TimeManager()
    {

        alltime = alltime - taypingtime;

    }



    // Start is called before the first frame update
    void Start()
    {
        
        Startset();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        StartTime();
        //Debug.Log(alltime);
        LevelSystem();
        if (Inputvalue.interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Enter();
            }
        }
         

    }

    void Startset()
    {
        Number();
        //InputfieldSelect();
        Inputvalue.interactable = false;
        StartCoroutine(inputSelect(1.5f));
        Invoke("InputUnlock", ShowTime);
        //StartTime();

        //Invoke("TaypingTime", taypingtime);
    }

    void Enter()
    {
        
        InputNumber();
        NullEnter();
        if (ShowingNumber == EnterNumber)
        {

            //answer.Correct(2.0f);
            isPaused = true;
            Clear++;
            
            //Debug.Log(EnterNumber);
            Debug.Log("정답");
            Startset();
        }
        else
        {
            isPaused = true;
            HpMinusManager();
            //answer.wronganswer(2.0f);
            
            //Debug.Log(EnterNumber);
            
            
        }
    }

    void LevelSystem()
    {   
        if (Clear == 4)
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

    void NullEnter()
    {
        Inputvalue.text = null;
    }
        

    void InputUnlock()
    {
        Inputvalue.interactable = true;
    }

    void EndingTime()
    {
        SceneManager.instance.NextGame();
    }

    void TaypingTime()
    {
        HpMinusManager();

    }

    void HpMinusManager()
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
    }
    
    void InputfieldSelect()
    {        
        inputField.Select();
        inputField.ActivateInputField();
    }
    private IEnumerator inputSelect(float ShowTime)
    {
        yield return new WaitForSeconds(ShowTime);
        InputfieldSelect();
    }
    
}
