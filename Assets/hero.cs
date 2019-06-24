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

    private int score;
    private BoxCollider2D _boxCollider;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
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
    bool PlayerTouching(Collider2D other)
    {
        return _boxCollider.IsTouching(other);
    }

    bool triggered;
    bool triggered2;
    bool triggered3;
    bool triggered4;
    void OnTriggerEnter2D(Collider2D bonus)
    {
        if (bonus.gameObject.tag == "bonus")
        {
            if (PlayerTouching(bonus))
            {
                Destroy(bonus.gameObject);
                score++;
                //if (score == 6)
                //{
                //    Application.LoadLevel("level2");
                //}
            }
        }
        if (bonus.gameObject.tag == "npc")
        {
            if (PlayerTouching(bonus))
            {
                triggered = true;
            }
        }

        if (bonus.gameObject.tag == "npc")
        {
            if (PlayerTouching(bonus))
            {
                if ((score == 6) && (bonus.gameObject.tag == "npc"))
                {
                    Application.LoadLevel("level2");
                }
            }
        }

        if (bonus.gameObject.tag == "npc2")
        {
            if (PlayerTouching(bonus))
            {
                triggered2 = true;
            }
        }

        if (bonus.gameObject.tag == "npc2")
        {
            if (PlayerTouching(bonus))
            {
                if ((score == 6) && (bonus.gameObject.tag == "npc2"))
                {
                    Application.LoadLevel("level3");
                }
            }
        }

        if (bonus.gameObject.tag == "npc3")
        {
            if (PlayerTouching(bonus))
            {
                triggered3 = true;
            }
        }

        if (bonus.gameObject.tag == "npc3")
        {
            if (PlayerTouching(bonus))
            {
                Destroy(bonus.gameObject);
            }
        }

        if (bonus.gameObject.tag == "npc4")
        {
            if (PlayerTouching(bonus))
            {
                triggered4 = true;
            }
        }

        if (bonus.gameObject.tag == "npc4")
        {
            if (PlayerTouching(bonus))
            {
                if ((score == 6) && (bonus.gameObject.tag == "hole"))
                {
                    Application.LoadLevel("level1");
                }
            }
        }


    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Detail:" + score);
        if (triggered)
        {
            GUI.Box(new Rect(10, 440, 210, 22), "Hello, friend! My name is Captain.");
            GUI.Box(new Rect(10, 480, 317, 22), "You must find the six details of the ship to go further.");
            GUI.Box(new Rect(10, 460, 245, 22), "Help me collect all the parts for my ship.");
            GUI.Box(new Rect(10, 500, 240, 22), "As soon as you find, come back to me.");
        }
        if (triggered2)
        {
            GUI.Box(new Rect(10, 460, 90, 22), "You did great!");
            GUI.Box(new Rect(10, 480, 160, 22), "Now find six more details.");
            GUI.Box(new Rect(10, 500, 240, 22), "As soon as you find, come back to me.");
        }
        if (triggered3)
        {
            GUI.Box(new Rect(10, 460, 100, 22), "We're so close!");
            GUI.Box(new Rect(10, 480, 160, 22), "Now find six more details.");
            GUI.Box(new Rect(10, 500, 180, 22), "I will wait for you at the ship.");
        }
        if (triggered4)
        {
            GUI.Box(new Rect(10, 380, 165, 22), "Hooray! You fixed my ship!");
            GUI.Box(new Rect(10, 400, 100, 22), "Thanks for help!");
            GUI.Box(new Rect(10, 420, 270, 22), "if you want to start again, jumping in the hole.");
        }


    }
}