using UnityEngine;

public class HealthPackMove : MonoBehaviour    

    {
        // TODO: A public float variable to control how fast the obstacle moves across the screen
        public Parallax.Layer layer;

        // TODO: A public float variable to control how far the object should go before being destroyed offscreen.
        public float endRange = 10.0f;
        public float speed = 20.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            // Make sure this calculation is frame rate independent (hint: use Time.deltaTime)
            transform.position += Vector3.left * speed * Time.deltaTime;

            // TODO: If the obstacle is off screen to the left, destroy this GameObject (hint: Destroy(gameObject))
            if (transform.position.x <= -endRange)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Health.TryHealTarget(other.gameObject, 1);
        }
    }
