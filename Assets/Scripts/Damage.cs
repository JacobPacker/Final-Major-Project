using UnityEngine;

public class Damage : MonoBehaviour
{
    public float health = 50f;
    public GameObject DestroyedVersion;
    public float yDistance = 1f;
    public AudioSource death;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DestroyedVersion, new Vector3(transform.position.x, transform.position.y + yDistance, transform.position.z), transform.rotation);
        death.Play ();
        Destroy(gameObject);
    }
}
