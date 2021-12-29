// 네임스페이스를 호출 (여러가지클래스 및 구조체 등을 묶은 네임스페이스를 불러온다 = 라이브러리 호출)
using System.Collections;           // 자료구조
using System.Collections.Generic;   // 자료구조
using UnityEngine;                  // 유니티 API 호출

// 유니티 자체 내에 있는 기본 클래스
public class ClickButton : MonoBehaviour            // ClickButton 클래스는 MonoBehaviour를 상속받아 Unity의 메서드를 사용가능하게 해줌.           
{

    public DataController dataController;           // DataController의 클래스의 멤버를 사용하기 위해 지정
    //public int gold = 0;
    //public int goldPerClick = 1;

    public void OnClick()                           // 클릭 후
    {
        Debug.Log("클릭");
        int goldPerClick = dataController.GetGoldPerClick();        // goldPerClick이라는 변수에 DataController 내에 GetGoldPerClick()라는 메서드의 값을 치환
        dataController.AddGold(goldPerClick);   //AddGold (1);                    // DataController 내에 존재하는 AddGold(newGold)를 불러옴
                                                                    // newGold의 값은 = goldPerClick으로 처음 DataController에 m_goldPerClick의 값을 받아옴.
        //gold = gold + goldPerClick;                               // 그 이후에 SetGold()함수를 호출해 m_gold의 값을 레지스트리에 저장.
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
