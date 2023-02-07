using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 40f;
    public Transform gun;
    public Camera mainCamera;
    public float bulletLifetime = 2f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 bulletSpawnPoint = gun.position + gun.forward * 1f;
        Quaternion bulletSpawnRotation = gun.rotation;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint, bulletSpawnRotation);
        Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(mainCamera.transform.forward * bulletForce, ForceMode.Impulse);

        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifetime));

    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(bullet);
    }
}