// ���ӽ����̽��� ȣ�� (��������Ŭ���� �� ����ü ���� ���� ���ӽ����̽��� �ҷ��´� = ���̺귯�� ȣ��)
using System.Collections;           // �ڷᱸ��
using System.Collections.Generic;   // �ڷᱸ��
using UnityEngine;                  // ����Ƽ API ȣ��

// ����Ƽ ��ü ���� �ִ� �⺻ Ŭ����
public class ClickButton : MonoBehaviour            // ClickButton Ŭ������ MonoBehaviour�� ��ӹ޾� Unity�� �޼��带 ��밡���ϰ� ����.           
{

    public DataController dataController;           // DataController�� Ŭ������ ����� ����ϱ� ���� ����
    //public int gold = 0;
    //public int goldPerClick = 1;

    public void OnClick()                           // Ŭ�� ��
    {
        Debug.Log("Ŭ��");
        int goldPerClick = dataController.GetGoldPerClick();        // goldPerClick�̶�� ������ DataController ���� GetGoldPerClick()��� �޼����� ���� ġȯ
        dataController.AddGold(goldPerClick);   //AddGold (1);                    // DataController ���� �����ϴ� AddGold(newGold)�� �ҷ���
                                                                    // newGold�� ���� = goldPerClick���� ó�� DataController�� m_goldPerClick�� ���� �޾ƿ�.
        //gold = gold + goldPerClick;                               // �� ���Ŀ� SetGold()�Լ��� ȣ���� m_gold�� ���� ������Ʈ���� ����.
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
