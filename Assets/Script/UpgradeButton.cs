using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI�� �޼ҵ带 ����ϱ� ���� ���ӽ����̽�

public class UpgradeButton : MonoBehaviour
{
    // DataController ����ȯ
    public DataController dataController;

    
    public Text upgradeDisplayer;           // ��ư ������Ʈ�� �ִ� Text�� ����ϱ� ���� ����
    public string upgradeName;              // �����̸� ����

    public int goldByUpgrade;               // ���׷��̵� ��差
    public int startGoldByUpgrade = 1;      // ó�� ���׷��̵� ��差

    public int currentCost;                 // ���� ���׷��̵� ���
    public int startCurrentCost = 1;        // ó�� ���׷��̵� ���

    public int level = 1;                   // ���׷��̵� ����

    public float upgradePow = 1.14f;        // Ŭ���� ��� ���ϴ� ��
    public float costPow = 1.14f;           // ���׷��̵� �� ��� ���ϴ� ��

    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadUpgradeButton(this);         // ������ ��Ʈ�ѷ� �ȿ� �ε� ���׷��̵� ��ư
        UpdateUI();                                     // ������ƮUI�Լ� ȣ��
    }

    public void PurchaseUpgrade()                               // OnClick �̺�Ʈ�� �۵��� ��
    {
        Debug.Log("������Ʈ Ŭ��");
        if (dataController.GetGold() >= currentCost)            // ��������Ʈ�ѷ��� ��尪�� ���� ���׷��̵� ��뺸�� Ŭ ��
        {
            dataController.SubGlod(currentCost);                // ���׷��̵� Ŭ���� ��差 ����
            level += 1;                                         // ���׷��̵� ���� + 1          
            dataController.AddGoldPerClick(goldByUpgrade);      // ������ ��Ʈ�ѷ��� AddGoldPerClick�� �Լ��� ȣ���Ͽ� ��ư�� ��� ȹ�淮�� goldByUpgrade��ŭ ����

            // Ŭ���� ��� ����� �κ��� �����ϴ� �κ�
            UpdateUpgrade();                                    // UpdateUpgrade()�Լ� ȣ��
            UpdateUI();                                         // UpdateUI()�Լ� ȣ��
            dataController.SaveUpgradeButton(this);             // DataController�� SaveUpgradeButton�� this �� UpgradeButtonŬ������ ȣ��
        }
    }

    public void UpdateUpgrade()                                 // UpdateUpgrade ���׷��̵��Լ�
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);     // goldByUpgrade�� 1 * 1.14^level�� ������Ʈ
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);            // currentCost�� 1 * 1.14^level�� ������Ʈ
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = "�����̸� : " + upgradeName + "\n" + "�ʿ��� ��� : " + currentCost + "\n" +
                                "���� : " + level + "\n" + "ȹ�� ���� ��� : " + goldByUpgrade;         // ��ư�� �ؽ�Ʈ�� ����Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
