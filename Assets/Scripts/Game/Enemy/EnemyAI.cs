using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    private float enemyHealth = 5f;
    private Animator anim;
    public AudioClip HitSound;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        audio.PlayOneShot(HitSound);
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("AnimationTrigger");
        enemyHealth -= damage;

        if (enemyHealth == 2){
            speed = 5f;
        }

        if (enemyHealth <= 0)
        {
            GetComponentInParent<EnemyController>().DecrementEnemyCounter();
            Destroy(gameObject);
        }
    }
}