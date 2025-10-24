using UnityEngine;
using System.Collections;

public class AJBoy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;
    public Transform cameraTransform;
    private CharacterController controller;
    private Animator animator;
    private float verticalVelocity = 0f;
    private float verticalRotation = 0f;
    private bool isEat = false;
    private bool isPaused = false;
    private bool isDead = false;

    // Reference to HUDManager
    public HUDManager hudManager;

    // Health system
    public int maxHealth = 100;
    private int currentHealth;
      private AudioSource audioSource;
    public AudioClip ItemSound;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        hudManager.UpdateHealthBar(currentHealth); 
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ตรวจสอบการกด ESC เพื่อ Pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        // ถ้าไม่ได้ pause และไม่ตาย จึงจะควบคุมตัวละครได้
        if (!isPaused && !isDead)
        {
            MoveCharacter();
            RotateCamera();
            ApplyGravity();
            CheckEatInput();
        }
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = transform.TransformDirection(direction) * moveSpeed;
        float movementMagnitude = new Vector3(horizontal, 0f, vertical).magnitude;
        direction.y = verticalVelocity;
        controller.Move(direction * Time.deltaTime);
        animator.SetFloat("Speed", direction.magnitude);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            animator.SetBool("IsOnAir", false);
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
                animator.SetBool("IsOnAir", true);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
    }

    void CheckEatInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            isEat = true;
            animator.SetBool("IsEat", true);
            StartCoroutine(ResetEatAnimation());
        }
    }

    IEnumerator ResetEatAnimation()
    {
        yield return new WaitForSeconds(1f);
        isEat = false;
        animator.SetBool("IsEat", false);
    }

    public void CheckCoinCollection(int coinValue)
    {
        if (coinValue == 1)
        {
            hudManager.AddCoinType1();
            audioSource.PlayOneShot(ItemSound);
        }
        else if (coinValue == 2)
        {
            hudManager.AddCoinType2();
            audioSource.PlayOneShot(ItemSound);
        }
        else if (coinValue == 3)
        {
            hudManager.AddCoinType3();
            audioSource.PlayOneShot(ItemSound);
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += (int)amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if (hudManager != null)
        {
            hudManager.UpdateHealthBar(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (hudManager != null)
        {
            hudManager.UpdateHealthBar(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        if (hudManager != null)
        {
            hudManager.PlayerDied();
        }
    }

    public bool Death()
    {
        return isDead;
    }
}