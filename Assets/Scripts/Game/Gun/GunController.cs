using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject player;
    public float distanceFromPlayer = 0.5f;

    void Update()
    {
        Vector3 gunPosition = player.transform.position + player.transform.forward * distanceFromPlayer;
        gameObject.transform.position = gunPosition;
        gameObject.transform.rotation = player.transform.rotation;
    }
}