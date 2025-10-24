using UnityEngine;

public class HealthD : MonoBehaviour
{
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
    
