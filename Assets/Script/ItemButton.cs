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
            isPurchased = true;             // 대단히 주의 해야 할 코드
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
        itemDisplayer.text = "아이템이름 : " + itemName + "\n" + "레벨 : " + level + "\n" + "구매비용 : " + currentCost + "\n" + "초당골드획득 : " + goldPerSec + "\n" + "구매여부 : " + isPurchased;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
