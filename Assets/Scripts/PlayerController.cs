using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;

    Animator playerAnimator;

    public GameObject gameOverImage;
    public GameObject gameOverUI;

    public TextMeshProUGUI timeText;

    public TextMeshProUGUI score;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public float jumpFrequency = 1f;
    public float nextJumpTime;

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();

        GroundCheck();

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

        WriteCurrentTime();
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);

        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));

        if (playerRB.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (playerRB.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpForce));
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            gameOverImage.SetActive(true);

            //Wait for 2 seconds
            StartCoroutine(WaitAndLoadNextScene(2f));


            SceneTransitionManager.instance.LoadNextScene();

        }
        if(collision.gameObject.CompareTag("GameOver"))
        {
            Time.timeScale = 0;
            score.text = "YOUR SCORE: " + timeText.text;
            gameOverUI.SetActive(true);
        }
    }

    IEnumerator WaitAndLoadNextScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneTransitionManager.instance.LoadNextScene();
    }

    void WriteCurrentTime()
    {
        float time = Time.timeSinceLevelLoad;
        int minutes = (int)(time / 60);
        float seconds = time % 60;
        timeText.text = $"{minutes}:{seconds:F2}";
    }
}
