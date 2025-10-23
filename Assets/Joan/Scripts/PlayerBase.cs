using UnityEngine;

public class PlayerBase2D : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si lo que entró es un enemigo
        Enemy2D enemy = other.GetComponent<Enemy2D>();
        if (enemy != null)
        {
            TakeDamage(enemy.damage);
            Destroy(enemy.gameObject); // Destruye al enemigo al chocar
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"La base recibió daño ({amount}). Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log("¡La base ha sido destruida!");
        }
    }
}