using UnityEngine;
//using UnityEngine.UI;

// TODO: Script should require a Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // TODO: Reference to Rigidbody2D component should have class scope.
    Rigidbody2D rigidbody2D;


    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float jumpForce = 5.0f;
    public bool isFalling = true;
   

    //TESTING AREA
    //public Text noMoreHealth;

    // Start is called before the first frame update
    void Start()
    {        
        // Use GetComponent to get a reference to attached Rigidbody2D
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jumpThisFrame = false;
        // Keyboard (already 1-frame)
        if (Input.GetKeyDown(KeyCode.Space)) jumpThisFrame = true;

        // Mobile (may be held, but we only care about this frame)
        if (MobileInput.I != null && MobileInput.I.jumpPressed) jumpThisFrame = true;
        
        // only jump when grounded
        if (jumpThisFrame && !isFalling)
        {
            Jump();
        }
        //noMoreHealth.text = $"jumpThisFrame:{jumpThisFrame} isFalling:{isFalling}";
    }
        private void Jump()
    {
        rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //print("on collision enter");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        //print("on collision exit");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }


}