using UnityEngine;

public class hero : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidbody;
    bool goRight = true;       

    void Start()
    {
        rigidbody = GetComponent <Rigidbody2D>();
    }

    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rigidbody.MovePosition(rigidbody.position + Vector2.right * moveX * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody.AddForce(Vector2.up * 15000);

        if (moveX > 0 && !goRight)
            flip();
        else if (moveX < 0 && goRight)
            flip();
    }

    void flip()
    {
        goRight = !goRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
