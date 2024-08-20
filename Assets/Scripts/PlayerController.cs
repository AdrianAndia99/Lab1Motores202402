using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public LayerMask collisionMask;
    private SpriteRenderer _playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed;
        rb.velocity = movement;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 1f, collisionMask);


        if (hit.collider != null)
        {
            Debug.Log("Raycast colisionó con " + hit.transform.gameObject.name + ", con el tag " + hit.transform.tag);
            Debug.Log("Coordenadas del objeto: " + hit.transform.position);
        }

        Debug.DrawRay(transform.position, movement * 1f, Color.red);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Color")
        {
            _playerSprite.color = other.transform.gameObject.GetComponent<SpriteRenderer>().color;
        }
        else if (other.gameObject.tag == "Shape")
        {
            _playerSprite.sprite = other.transform.gameObject.GetComponent<SpriteRenderer>().sprite;

        }
    }
}