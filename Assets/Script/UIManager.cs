using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSecDisplayer;
    //public DataController dataController;
    //public ItemButton itemButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldDisplayer.text = DataController.GetInstance().GetGold().ToString();
        goldDisplayer.text= "°ñµå : " + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "Å¬¸¯´ç °ñµå : " + DataController.GetInstance().GetGoldPerClick();
        goldPerSecDisplayer.text = "Gold Per Sec : " + DataController.GetInstance().GetGoldPerSec();
    }
}
