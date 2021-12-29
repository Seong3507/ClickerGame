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


    // ����
    public int m_gold = 0;              // ���� ���� m_gold �ʱ갪 = 0
    public int m_goldPerClick = 0;     // Ŭ���� �������� ����� �� �ִ� ���� m_goldPerClick �ʱ갪 = 0
    public int m_goldPerSec = 0;





    // Awake�� ���� ���� ������Ʈ���� Gold��� ���ǵǾ��ִ� m_gold�� ���� ����
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        // PlayerPrefs = ������Ʈ���� �����͸� ����
        m_gold = PlayerPrefs.GetInt("Gold");                    //PlayerPrefs �� Gold��� ���ǵǾ� �ִ� �����͸� �ε�  
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);    //PlayerPrefs �� GoldPerClick��� ���ǵǾ� �ִ� �����͸� �ε�  

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    // ��差�� ������Ʈ���� �����ϴ� �޼ҵ�
    public void SetGold(int newGold)                            //PlayerPrefs �� ���� ��差�� �����ϰ� ���� �� ȣ���� �޼���
    {
        // m_gold�� 1�� ���� ���� m_gold��� ġȯ����
        
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold);
        Debug.Log(m_gold);
        // ������ �Ű������� ���� m_gold�� ������ ġȯ �� ������Ʈ���� Gold��� ���ǵǾ� �ִ� �Ϳ� m_gold������ ����
    }

    // ��差 ���� ���Ҹ� ó���ϴ� �޼ҵ�

    public void AddGold(int newGold) // AddGold(goldPerClick) == AddGold(1)  == AddGold(x) == AddGold(newGold)           // GetGoldPerClick = newgold = 1
    {
        // m_gold�� 1�� �����ش�.
        // m_gold = 0;
        // newGold = 1;
        // m_gold = m_gold + newGold;
        m_gold += newGold;      // ������ �Ű������� ���� m_gold�� ����         m_gold = m_gold + newGold;
        SetGold(m_gold);        // �Ű������� m_gold ������ ����              m_gold = 1
        Debug.Log(m_gold);      // set���� m_gold�� ���� ���
    }
    public void SubGlod(int newGold)
    {
        m_gold -= newGold;      // ������ �Ű������� ���� m_gold�� ��
        SetGold(m_gold);        // �Ű������� m_gold ������ ����
    }

    public int GetGold()
    {

        return m_gold;          // m_gold�� ���� ��ȯ
    }

    public void SetGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick = newGoldPerClick;                           // m_goldPerClick�� ���� newGoldPerClick���� ġȯ
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);         // GoldPerClick�̶�� ���ǵǾ��ִ� ���� m_goldPerClick�� ���� ����.
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;      // m_goldPerClick�� ���� ��ȯ
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

    public void AddGoldPerClick(int newGoldPerClick)            // AddGoldPerClick�Լ�(�Ű����� = newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;                      // m_goldPerClick �� �Ű����� �� goldByUpgrade�� ���Ѵ�.
        SetGoldPerClick(m_goldPerClick);                        // SetGoldPerClick�Լ��� ȣ���Ͽ� m_goldPerClick�Ű������� �Ͽ� m_goldPerClick�� �ֽ�ȭ�Ѵ�.
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)      // LoadUpgradeButton �Ű������� ������ Ŭ������ �Ѵ�.
    {
        string key = upgradeButton.upgradeName;                     // UpgradeButton�� upgradeName�� Head�� �����ߴ�.
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);// UpgradeButton�� level�� �̸��� key_level�� 1�� ����
                                                                    // Key = Head�� ���� �� Head_level�� 1�� ������Ʈ���� ���´�.
        // UpgradeButton�� goldByUpgrade�� Head_goldByUpgrade�� ���ǵ� ���� ������Ʈ�� ��򰡿� upgradeButton.startGoldByUpgrade�� ���� ���´�.
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        // UpgradeButton�� currentCost�� Head_cost�� ���ǵ� ���� ������Ʈ�� ��򰡿� upgradeButton.startCurrentCost�� ���� ���´�.
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)      // SaveUpgradeButton �Ű������� ������ Ŭ������ �Ѵ�.
    {
        string key = upgradeButton.upgradeName;                     // UpgradeButton�� upgradeName�� Head�� �����ߴ�.
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);    // �̸��� key_level�̶�� ������ ������ ���� upgradeButton.level�� ������ ����
        // �̸��� key_goldByUpgrade��� ������ ������ ���� upgradeButton.goldByUpgrade�� ������ ����
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        // �̸��� key_cost��� ������ ������ ���� upgradeButton.currentCost�� ������ ����
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);
    }

    public void LoadItemButton(ItemButton itemButton)      // LoadUpgradeButton �Ű������� ������ Ŭ������ �Ѵ�.
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
