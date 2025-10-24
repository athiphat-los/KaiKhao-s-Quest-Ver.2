using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    // อ้างอิง HealthBar
    public HealthBar healthBar;

    // ตัวนับเหรียญ
    public TextMeshProUGUI coinType1Text;
    public TextMeshProUGUI coinType2Text;
    public TextMeshProUGUI coinType3Text;

    private int coinType1Count = 0;
    private int coinType2Count = 0;
    private int coinType3Count = 0;
    

    // ฟังก์ชันเพิ่มเหรียญประเภทที่ 1
    public void AddCoinType1()
    {
        coinType1Count++;
        coinType1Text.text = coinType1Count.ToString()+ " / 50";
        CheckCoinGoal();
    }

    // ฟังก์ชันเพิ่มเหรียญประเภทที่ 2
    public void AddCoinType2()
    {
        coinType2Count++;
        coinType2Text.text =coinType2Count.ToString()+ " / 15";
        CheckCoinGoal();
    }

    // ฟังก์ชันเพิ่มเหรียญประเภทที่ 3
    public void AddCoinType3()
    {
        coinType3Count++;
        coinType3Text.text = coinType3Count.ToString()+ " / 3";
        CheckCoinGoal();
    }

    // ฟังก์ชันตรวจสอบเงื่อนไขเมื่อเก็บเหรียญครบ
    private void CheckCoinGoal()
    {
        if (coinType1Count >= 50 && coinType2Count >= 15 && coinType3Count >= 3)
        {
            // กลับไปยัง scene 0 หรือทำสิ่งที่คุณต้องการเมื่อเก็บเหรียญครบ
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
    }

    // ฟังก์ชันอัปเดต HealthBar
    public void UpdateHealthBar(int currentHealth)
    {
        healthBar.SetHealth(currentHealth); // เรียกฟังก์ชันใน HealthBar
    }

    // ฟังก์ชันเรียกเมื่อผู้เล่นตาย
    public void PlayerDied()
    {
        // แสดง UI หรือปุ่ม retry ตามที่คุณต้องการ
        Debug.Log("Player Died! Show retry button or restart scene.");
        // ตัวอย่างการรีสตาร์ท scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    
}
