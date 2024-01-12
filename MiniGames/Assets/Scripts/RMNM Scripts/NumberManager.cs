using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberManager : MonoBehaviour//Minigame
{
    public int Clear = 0;
    public int Level = 1;
    public int digit = 1;
    int ShowingNumber = 0;
    int EnterNumber = 1;
    public int PlayerHp = 3;
    

    [TextArea]
    public string Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        LevelSystem();
        GameOver();
    }

    void Enter()
    {
        if(ShowingNumber == EnterNumber)
        {
            Clear++;
            Debug.Log("정답");
        }
        else
        {
            PlayerHp--;
            Debug.Log("오답");
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
        if(PlayerHp == 0)
        {
            Debug.Log("게임 끝");
        }
    }
    //void Number()
    //{
    //    if(Clear < 7)
    //    {
    //        Level++;
    //    }
    //}
}
