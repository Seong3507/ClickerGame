using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public DataController dataController;


    public Text itemDisplayer;
    public string itemName;
    public int level;
    public int currentCost;
    public int startCurrentCost = 1;
    public int goldPerSec;
    public int startGoldPerSec = 1;
    public float costPow = 1.14f;
    public float upgradePow = 2.14f;
    public bool isPurchased = false;




    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }

    public void PurchaseItem()
    {
        if(dataController.GetGold() >= currentCost)
        {
            isPurchased = true;             // ����� ���� �ؾ� �� �ڵ�
            dataController.SubGlod(currentCost);
            level += 1;

            updateItem();
            UpdateUI();
            dataController.SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()
    {
        while(true)
        {
            
            if (isPurchased)
            {
                dataController.AddGold(goldPerSec);
            }
            yield return new WaitForSeconds(1f);
        }
    }


    public void updateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = currentCost + startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = "�������̸� : " + itemName + "\n" + "���� : " + level + "\n" + "���ź�� : " + currentCost + "\n" + "�ʴ���ȹ�� : " + goldPerSec + "\n" + "���ſ��� : " + isPurchased;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
