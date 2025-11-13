using UnityEngine;


public class Health : MonoBehaviour
{
    public int healthAmount = 3;

    public void TakeDamage(int amount)
    {
        //Debug.Log($"in TakeDamage function");
        healthAmount -= amount;
        GameFeel.AddCameraShake(0.1f);
        if (healthAmount <= 0)
        {
            GameManager.instance.Restart();
        }
    }

    public static void TryDamageTarget(GameObject target, int damageAmount)
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth)
        {
            //Debug.Log("targetHealth");
            targetHealth.TakeDamage(damageAmount);
        }
        if (!targetHealth)
        {
            //Debug.Log("no targetHealth component");
        }
    }

}
