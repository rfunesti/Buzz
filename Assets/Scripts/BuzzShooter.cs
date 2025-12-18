using UnityEngine;

public class BuzzShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint;          // The point where the projectile spawns
    public float projectileSpeed = 10f;  // Speed of the projectile
    public GameObject explosionPrefab;
    public int enemyPoint = 5;
    public int sawPoint = 1;
    public bool fire;

    [Header("Direction")]
    public bool facingRight = true;      // Used to track facing direction

    [Header("Scoring")]
    public Score scoreManager; // drag your Score object into this in the Inspector

    void Awake()
    {
        //fire = Input.GetKeyDown(KeyCode.F);
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
            Fire();
        }
        if (MobileInput.I != null)
        {
            fire |= MobileInput.I.firePressed;
        }
        if (fire) Fire();
        
        // Example of flipping direction (optional)
        //if (Input.GetKeyDown(KeyCode.LeftArrow)) facingRight = false;
        //if (Input.GetKeyDown(KeyCode.RightArrow)) facingRight = true;
    }

    void Fire()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning("ProjectileShooter is missing a prefab or firePoint reference!");
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (scoreManager != null)
            {                
                scoreManager.AddPoints(enemyPoint);  // give points for an enemy
            }            
        }
        if (other.gameObject.CompareTag("Saw"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            if (scoreManager != null)
            {                
                scoreManager.AddPoints(sawPoint);   // give points for an enemy projectile
            }    
        }
    }
}