using UnityEngine;

public class Turret2D : MonoBehaviour
{
    [Header("Configuración de ataque")]
    public string enemyTag = "Enemy";      // Tag del enemigo
    public float range = 8f;               // Radio de detección
    public float fireRate = 1f;            // Disparos por segundo
    public float damage = 10f;             // Daño de cada bala

    [Header("Referencias")]
    public Transform firePoint;            // Punto de disparo
    public GameObject bulletPrefab;        // Prefab de la bala

    private float fireCountdown = 0f;
    private Transform target;

    void Update()
    {
        UpdateTarget();

        if (target == null) return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet2D bullet = bulletGO.GetComponent<Bullet2D>();

        if (bullet != null)
        {
            bullet.Seek(target);
            bullet.damage = damage;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}