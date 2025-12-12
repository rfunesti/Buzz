using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Health : MonoBehaviour
{
    public int healthAmount = 3;

    public static void TryHealTarget(GameObject target, int amount)
    {
        Health targetHealth = target.GetComponent<Health>();
        
        if (targetHealth)
        {            
            targetHealth.HealDamage(amount);
        }
        if (!targetHealth)
        {
            Debug.Log("no targetHealth component");
        }
    }

    public static void TryDamageTarget(GameObject target, int damageAmount)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth)        
        {
            
            targetHealth.TakeDamage(damageAmount);
        }
        if (!targetHealth)
        {
            Debug.Log("no targetHealth component");
        }
    }

    public void TakeDamage(int amount)
    {
        healthAmount -= amount;
        GameFeel.AddCameraShake(0.1f);
        if (healthAmount <= 0)
        {
            GameManager.instance.Restart();
        }
    }

    public void HealDamage(int amount)
    {
        if (healthAmount < 3 && healthAmount > 0)
        {
            healthAmount += amount;
        }
    }
}
