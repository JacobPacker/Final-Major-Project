using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public float health = 50f;
    public GameObject DestroyedVersion;
    public float yDistance = 1f;
    public void TakeDamage(float amount)
    {
        //health -= amount;
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
