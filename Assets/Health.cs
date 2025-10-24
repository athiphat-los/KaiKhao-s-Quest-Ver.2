using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float healthIncrease = 15f; // จำนวนการเพิ่มค่าชีวิต

    private void OnTriggerEnter(Collider other) // เปลี่ยนจาก OnTriggerEnter2D เป็น OnTriggerEnter หากเป็น 3D
    {
        if (other.CompareTag("Player"))
        {
            AJBoy player = other.GetComponent<AJBoy>();

            if (player != null)
            {
                player.IncreaseHealth(healthIncrease); // เรียกฟังก์ชันเพิ่มค่าชีวิตใน AJBoy
                Destroy(gameObject); // ทำลาย Power-up หลังจากเก็บแล้ว
            }
        }
    }
}