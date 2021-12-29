using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButton : MonoBehaviour
{

    public UpgradeButton upgradeButton;
    public DataController dataController;
    public ItemButton itemButton;
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();
        dataController.SetGold(0);
        dataController.SetGoldPerClick(1);
        dataController.LoadUpgradeButton(upgradeButton);
        dataController.SaveUpgradeButton(upgradeButton);
        upgradeButton.UpdateUI();
        dataController.LoadItemButton(itemButton);
        dataController.SaveItemButton(itemButton);
        itemButton.updateItem();
        itemButton.UpdateUI();
        //itemButton.isPurchased = false;
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
