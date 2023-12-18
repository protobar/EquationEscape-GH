using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementEx : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0f, 100f)] public float jumpForce = 10f;
    [Range(0f, 50f)] public float moveSpeed = 15f;

    [Header("UI Elements")]
    public Text coinText;
    public Text heartsText;

    [Header("Gameplay Elements")]
    public int totalCoins;
    public int totalHearts = 3;

    [Header("Animation and UI")]
    public Animator anim;
    public GameObject youLose;
    public GameObject twoPanels;

    [Header("Audio")]
    public AudioSource coinSound;
    public AudioSource punchSound;
    public AudioSource hurtSound;

    private Rigidbody2D rb;
    private bool canJump = true;

    // Initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        totalCoins = 0;

        // Initialize UI
        coinText.text = totalCoins.ToString();
        heartsText.text = totalHearts.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Apply horizontal movement
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // Player jump function
    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
            anim.SetBool("isJumping", true);
        }
    }

    // Player sliding function
    public void Sliding()
    {
        anim.Play("Sliding");
    }
    // Collision detection
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            anim.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            punchSound.Play();
            Destroy(collision.gameObject);
            HandleEnemyCollision();
        }

        if(collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
            youLose.SetActive(true);
            twoPanels.SetActive(false);
        }
    }

    // Coin pickup logic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            HandleCoinPickup(collision.gameObject);
        }
    }

    // Handle coin pickup and update UI
    private void HandleCoinPickup(GameObject coin)
    {
        coinSound.Play();

        // Call GameManager to add coins
        GameManager.instance.AddCoins(1);

        UpdateCoinText();
        Destroy(coin);
    }

    // Update coin count on UI
    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            totalCoins = GameManager.instance.GetTotalCoins();
            coinText.text = totalCoins.ToString();
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
