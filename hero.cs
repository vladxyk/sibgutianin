using UnityEngine;

public class hero : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rigidbody;

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
    }
}
