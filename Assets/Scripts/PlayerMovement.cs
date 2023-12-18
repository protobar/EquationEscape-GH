using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public Animator anim;
    public GameObject youLose;
    public GameObject twoPanels;
    public Button slideBtn;

    public Text heartsText;
    public int totalHearts = 3;


    public AudioSource punchSound;
    public AudioSource hurtSound;

    private Rigidbody2D rb;
    private bool canJump = true;
    private Vector3 targetPosition = new Vector3(-40, -18.0213642f, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slideBtn.onClick.AddListener(Sliding);
        heartsText.text = totalHearts.ToString();

    }

    void Update()
    {
        // Ensure the player stays at the target X-position
        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        anim.SetBool("isRunning", true);
    }

    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;

            if (jumpForce > 0)
            {
                anim.SetBool("isJumping", true);
            }
        }
    }

    public void Sliding()
    {
        anim.Play("Sliding");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            anim.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            HandleEnemyCollision();
        }
    }

    // Subtract one heart and check for game over
    private void HandleEnemyCollision()
    {
        SubtractHeart();
        if (totalHearts <= 0)
        {
            DestroyPlayer();
        }
    }

    // Subtract one heart and update UI
    private void SubtractHeart()
    {
        hurtSound.Play();
        totalHearts = Mathf.Max(0, totalHearts - 1);
        heartsText.text = totalHearts.ToString();
    }

    // Game over logic
    private void DestroyPlayer()
    {
        Destroy(gameObject);
        youLose.SetActive(true);
        twoPanels.SetActive(false);
    }
}
