using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.SetHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
