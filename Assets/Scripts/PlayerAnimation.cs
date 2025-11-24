using UnityEngine;
// This script requires the use of three components:
// Animator, Player, and Rigidbody2D
// Use the RequireComponent attribute to make sure the GameObject
// this script is attached to has these components.

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimation : MonoBehaviour
{
    // ToDo: This script needs a reference variable for each component:

    // Start is called before the first frame update
    Animator animator;
    Player player;
    Rigidbody2D rigidbody2D;
    //public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // ToDo: Get a reference to each component using GetComponent
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ToDo: Set the animator bool parameter "Falling" to the value of player.isFalling.
        animator.SetBool("Falling", player.isFalling);
        // ToDo: Set the animator float parameter "YVelocity" to the value of rigidbody2D.velocity.y
        animator.SetFloat("YVelocity", rigidbody2D.linearVelocity.y);
    }
}