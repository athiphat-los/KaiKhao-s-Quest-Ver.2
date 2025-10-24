using UnityEngine;

public class CoinEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveDistance = 5f;
    
    private Vector3 startPosition;
    private float movementFactor;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time / moveSpeed;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = Vector3.right * movementFactor * moveDistance;
        transform.position = startPosition + offset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("Death", true);      
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
}