using UnityEngine;

public class hero : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float moveSmoothing = .05f;
    public float speed = 10f;
    [SerializeField] private float jumpForce = 400f;
    private bool onGround;
    private Rigidbody2D _rigidbody;
    bool goRight = true;

    private bool _isJumping = false;
    private float moveX;
    private Vector3 zeroVelocity = Vector3.zero;

    public int score;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 2.8f);
        onGround = false;
        if (hit.collider != null)
        {
            onGround = true;
            Debug.Log(hit.collider.ToString());
        }

        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    void FixedUpdate()
    {
        float move = moveX * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref zeroVelocity, moveSmoothing);
        _rigidbody.MovePosition(_rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (_isJumping && onGround)
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce));
            _isJumping = false;
        }

        if (moveX > 0 && !goRight)
            Flip();
        else if (moveX < 0 && goRight)
            Flip();
    }
    void Flip()
    {
        goRight = !goRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D bonus)
    {
        if (bonus.gameObject.tag == "bonus")
        {
            Destroy(bonus.gameObject);
            score++;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Score:" + score);
    }
}