using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20; // จำนวนความเสียหายที่ศัตรูจะทำกับผู้เล่น

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าศัตรูชนกับ Player
        if (other.CompareTag("Player"))
        {
            AJBoy player = other.GetComponent<AJBoy>();
            if (player != null)
            {
                // ทำความเสียหายให้กับ Player
                player.TakeDamage(damage);
            }
        }
    }
}