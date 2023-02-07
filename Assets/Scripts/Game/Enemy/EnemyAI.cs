using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    private float enemyHealth = 5f;
    public float followDistance = 30f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < followDistance)
        {
            if (enemyHealth > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                transform.position = Vector3.MoveTowards(
                    transform.position, 
                    transform.position - (player.position - transform.position), 
                    speed * 2 * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            GetComponentInParent<EnemyController>().DecrementEnemyCounter();
            Destroy(gameObject);
        }
    }
}