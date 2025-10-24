using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // กำหนดค่าของคอยน์ เช่น 1, 2, หรือ 3
    public float rotationSpeedX = 50f; // ความเร็วในการหมุนแกน X (องศาต่อวินาที)
    public float rotationSpeedY = 50f; // ความเร็วในการหมุนแกน Y (องศาต่อวินาที)
    
    
    private void Update()
    {
        // หมุนเหรียญรอบแกน X และ Y
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AJBoy player = other.GetComponent<AJBoy>();
            if (player != null)
            {
                player.CheckCoinCollection(coinValue); // เรียกใช้เมธอด CollectCoin ที่ปรับปรุงใหม่
                Destroy(gameObject); // ทำลายคอยน์เมื่อเก็บแล้ว
                
            }
        }
    }
}