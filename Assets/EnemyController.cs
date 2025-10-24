using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject target; 
    private NavMeshAgent agent;

    // ความเร็วของศัตรู
    public float enemySpeed = 2f; // คุณสามารถปรับค่าความเร็วได้ตามต้องการ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // กำหนดความเร็วให้ศัตรู
        agent.speed = enemySpeed;

        // ค้นหา GameObject ที่มีแท็ก Player
        target = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }
    }
}