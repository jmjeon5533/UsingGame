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
    [SerializeField] TextMeshProUGUI userTime;
    [SerializeField] TextMeshProUGUI allTime;
    //public Hide answer;
    int Bnewtime;
    int Anewtime;
    long ShowingNumber = 0;
    long EnterNumber;
    public float ShowTime = 1.5f;
    public float taypingtime = 10.0f;
    public float alltime = 60.0f;
    bool isPaused = true;


    void StartTime()
    {        
        if (isPaused == false)
        {
            if (alltime > 0f)
            {
                taypingtime -= Time.deltaTime;
                alltime -= Time.deltaTime;
                //Debug.Log(Mathf.Round(alltime));
            }
            if (taypingtime <= 0)
            {
                NullEnter();
                HpMinusManager();
            }
        }
    }
    void TimeManager()
    {
        if (alltime <= 10.0f)
        {
            taypingtime = alltime;
        }
        else
        {
            taypingtime = 10.0f;
        }
        
        
    }
    
    void Start()
    { 
        Startset();
    }
    
    // Update is called once per frame
    void Update()
    {
        Timer();
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
        TimeManager();
        Number();        
        Inputvalue.interactable = false;
        StartCoroutine(InputSelect(1.5f));
        Invoke("InputUnlock", ShowTime);
        StartCoroutine(Starsettime(1.5f));
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
            
            HpMinusManager();
            //answer.wronganswer(2.0f);
            
            //Debug.Log(EnterNumber);
            
            
        }
    }

    void LevelSystem()
    {   
        if(Level <= 10)
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

    

    void HpMinusManager()
    {
        isPaused = true;
        if (alltime <= 0f || PlayerHp == 0)
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
    private IEnumerator InputSelect(float ShowTime)
    {
        yield return new WaitForSeconds(ShowTime);
        InputfieldSelect();
    }
    
    private IEnumerator Starsettime(float ShowTime)
    {
        yield return new WaitForSeconds(ShowTime);
        isPaused = false;
        
    }

    void Timer()
    {
        AllTime(Bnewtime.ToString());
        UserTime(Anewtime.ToString());
        
    }
    public void AllTime(string TextMeshProUGUI)
    {
        Bnewtime = (int)alltime;
        allTime.text = TextMeshProUGUI;
    }

    public void UserTime(string TextMeshProUGUI)
    {
        Anewtime = (int)taypingtime;
        userTime.text = TextMeshProUGUI;
    }
}
