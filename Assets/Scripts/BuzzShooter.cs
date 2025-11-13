using UnityEngine;

public class BuzzShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint;          // The point where the projectile spawns
    public float projectileSpeed = 10f;  // Speed of the projectile

    [Header("Direction")]
    public bool facingRight = true;      // Used to track facing direction

    [Header("Scoring")]
    public Score scoreManager; // drag your Score object into this in the Inspector

    void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = FindFirstObjectByType<Score>();
            if (scoreManager == null)
            {
                Debug.LogError("No Score component found in the scene!");
            }
        }
    }
    void Update()
    {
        // Example: press space to shoot
        if (Input.GetKeyDown(KeyCode.F))
        {
            FireProjectile();
        }

        // Example of flipping direction (optional)
        if (Input.GetKeyDown(KeyCode.LeftArrow)) facingRight = false;
        if (Input.GetKeyDown(KeyCode.RightArrow)) facingRight = true;
    }

    void FireProjectile()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            //Debug.LogWarning("ProjectileShooter is missing a prefab or firePoint reference!");
            return;
        }

        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Get Rigidbody2D
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Set velocity based on facing direction
            float direction = facingRight ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * projectileSpeed, 0f);
        }

        // Optional: Flip sprite if facing left
        if (!facingRight)
        {
            Vector3 scale = projectile.transform.localScale;
            scale.x *= -1;
            projectile.transform.localScale = scale;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Player"))
        {
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (scoreManager != null)
            {
                Debug.Log("Adding points for Enemy");
                scoreManager.AddPoints(5);  // give points for an enemy
            }            
        }
        if (other.gameObject.CompareTag("Saw") && !gameObject.CompareTag("Player"))
        {
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            if (scoreManager != null)
            {
                Debug.Log("Adding points for Saw Projectile");
                scoreManager.AddPoints(1);   // give points for an enemy projectile
            }    
        }
    }

}