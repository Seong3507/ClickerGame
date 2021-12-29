using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataController instance;

    public static DataController GetInstance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<DataController>();

            if(instance == null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }

        return instance;
    }

    private ItemButton[] itemButtons;


    // 변수
    public int m_gold = 0;              // 공용 변수 m_gold 초깃값 = 0
    public int m_goldPerClick = 0;     // 클래스 내에서만 사용할 수 있는 변수 m_goldPerClick 초깃값 = 0
    public int m_goldPerSec = 0;





    // Awake를 통해 먼저 레지스트리에 Gold라고 정의되어있는 m_gold의 값을 얻어옴
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        // PlayerPrefs = 레지스트리에 데이터를 저장
        m_gold = PlayerPrefs.GetInt("Gold");                    //PlayerPrefs 에 Gold라고 정의되어 있는 데이터를 로드  
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);    //PlayerPrefs 에 GoldPerClick라고 정의되어 있는 데이터를 로드  

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    // 골드량을 레지스트리에 저장하는 메소드
    public void SetGold(int newGold)                            //PlayerPrefs 에 현재 골드량을 저장하고 싶을 때 호출할 메서드
    {
        // m_gold에 1을 더한 값을 m_gold라고 치환하자
        
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
        Debug.Log(m_gold);
        // 들어오는 매개변수의 값을 m_gold의 값으로 치환 후 레지스트리에 Gold라고 정의되어 있는 것에 m_gold값으로 저장
    }

    // 골드량 증가 감소를 처리하는 메소드

    public void AddGold(int newGold) // AddGold(goldPerClick) == AddGold(1)  == AddGold(x) == AddGold(newGold)           // GetGoldPerClick = newgold = 1
    {
        // m_gold에 1을 더해준다.
        // m_gold = 0;
        // newGold = 1;
        // m_gold = m_gold + newGold;
        m_gold += newGold;      // 들어오는 매개변수의 값을 m_gold에 더함         m_gold = m_gold + newGold;
        SetGold(m_gold);        // 매개변수를 m_gold 값으로 지정              m_gold = 1
        Debug.Log(m_gold);      // set이후 m_gold의 값을 출력
    }
    public void SubGlod(int newGold)
    {
        m_gold -= newGold;      // 들어오는 매개변수의 값을 m_gold에 뺌
        SetGold(m_gold);        // 매개변수를 m_gold 값으로 지정
    }

    public int GetGold()
    {

        return m_gold;          // m_gold의 값을 반환
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;                           // m_goldPerClick의 값을 newGoldPerClick으로 치환
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);         // GoldPerClick이라고 정의되어있는 곳에 m_goldPerClick의 값을 저장.
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;      // m_goldPerClick의 값을 반환
    }

    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i = 0; i< itemButtons.Length; i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }

        // goldPerSec =  itemButtons[0].goldPerSec + itemButtons[1].goldPerSec + itemButtons[2].goldPerSec
        return goldPerSec;
    }

    public void AddGoldPerClick(int newGoldPerClick)            // AddGoldPerClick함수(매개변수 = newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;                      // m_goldPerClick 에 매개변수 즉 goldByUpgrade를 더한다.
        SetGoldPerClick(m_goldPerClick);                        // SetGoldPerClick함수를 호출하여 m_goldPerClick매개변수로 하여 m_goldPerClick를 최신화한다.
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)      // LoadUpgradeButton 매개변수의 형식은 클래스로 한다.
    {
        string key = upgradeButton.upgradeName;                     // UpgradeButton의 upgradeName을 Head로 설정했다.
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);// UpgradeButton의 level을 이름을 key_level을 1로 설정
                                                                    // Key = Head로 설정 즉 Head_level을 1로 레지스트리에 얻어온다.
        // UpgradeButton의 goldByUpgrade을 Head_goldByUpgrade로 정의된 곳에 레지스트리 어딘가에 upgradeButton.startGoldByUpgrade의 값을 얻어온다.
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        // UpgradeButton의 currentCost를 Head_cost로 정의된 곳에 레지스트리 어딘가에 upgradeButton.startCurrentCost의 값을 얻어온다.
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)      // SaveUpgradeButton 매개변수의 형식은 클래스로 한다.
    {
        string key = upgradeButton.upgradeName;                     // UpgradeButton의 upgradeName을 Head로 설정했다.
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);    // 이름이 key_level이라는 곳으로 정의한 곳에 upgradeButton.level의 값으로 설정
        // 이름이 key_goldByUpgrade라는 곳으로 정의한 곳에 upgradeButton.goldByUpgrade의 값으로 설정
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        // 이름이 key_cost라는 곳으로 정의한 곳에 upgradeButton.currentCost의 값으로 설정
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)      // LoadUpgradeButton 매개변수의 형식은 클래스로 한다.
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "_goldPerSec");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        if(PlayerPrefs.GetInt(key + "_isPurchased") == 1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);


        if(itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
