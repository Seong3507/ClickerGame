using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI의 메소드를 사용하기 위한 네임스페이스

public class UpgradeButton : MonoBehaviour
{
    // DataController 형변환
    public DataController dataController;

    
    public Text upgradeDisplayer;           // 버튼 컴포넌트에 있는 Text룰 사용하기 위한 변수
    public string upgradeName;              // 부위이름 변수

    public int goldByUpgrade;               // 업그레이드 골드량
    public int startGoldByUpgrade = 1;      // 처음 업그레이드 골드량

    public int currentCost;                 // 현재 업그레이드 비용
    public int startCurrentCost = 1;        // 처음 업그레이드 비용

    public int level = 1;                   // 업그레이드 레벨

    public float upgradePow = 1.14f;        // 클릭당 골드 곱하는 양
    public float costPow = 1.14f;           // 업그레이드 후 비용 곱하는 양

    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadUpgradeButton(this);         // 데이터 컨트롤러 안에 로드 업그레이드 버튼
        UpdateUI();                                     // 업데이트UI함수 호출
    }

    public void PurchaseUpgrade()                               // OnClick 이벤트로 작동한 후
    {
        Debug.Log("업데이트 클릭");
        if (dataController.GetGold() >= currentCost)            // 데이터컨트롤러의 골드값을 현재 업그레이드 비용보다 클 때
        {
            dataController.SubGlod(currentCost);                // 업그레이드 클릭시 골드량 감소
            level += 1;                                         // 업그레이드 레벨 + 1          
            dataController.AddGoldPerClick(goldByUpgrade);      // 데이터 컨트롤러에 AddGoldPerClick의 함수를 호출하여 버튼당 골드 획득량을 goldByUpgrade만큼 증가

            // 클릭당 골드 변경된 부분을 저장하는 부분
            UpdateUpgrade();                                    // UpdateUpgrade()함수 호출
            UpdateUI();                                         // UpdateUI()함수 호출
            dataController.SaveUpgradeButton(this);             // DataController에 SaveUpgradeButton을 this 즉 UpgradeButton클래스에 호출
        }
    }

    public void UpdateUpgrade()                                 // UpdateUpgrade 업그레이드함수
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);     // goldByUpgrade를 1 * 1.14^level로 업데이트
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);            // currentCost를 1 * 1.14^level로 업데이트
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = "부위이름 : " + upgradeName + "\n" + "필요한 골드 : " + currentCost + "\n" +
                                "레벨 : " + level + "\n" + "획득 가능 골드 : " + goldByUpgrade;         // 버튼의 텍스트를 출력한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
