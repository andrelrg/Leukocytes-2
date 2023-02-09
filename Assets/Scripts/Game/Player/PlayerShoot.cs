using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 40f;
    public Transform gun;
    public Camera mainCamera;
    public float bulletLifetime = 2f;
    public Texture2D crosshairTexture;
    public AudioClip bulletSound;
    AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audio.PlayOneShot(bulletSound);
        Vector3 bulletSpawnPoint = gun.position + gun.up * 0.5f + gun.forward * -0.5f;
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

    private void OnGUI()
    {
        float crossHairSize = 20;
        float crossHairThickness = 2;

        Rect verticalLine = new Rect(Screen.width / 2 - crossHairThickness / 2, Screen.height / 2 - crossHairSize / 2, crossHairThickness, crossHairSize);
        Rect horizontalLine = new Rect(Screen.width / 2 - crossHairSize / 2, Screen.height / 2 - crossHairThickness / 2, crossHairSize, crossHairThickness);

        GUI.DrawTexture(verticalLine, crosshairTexture);
        GUI.DrawTexture(horizontalLine, crosshairTexture);
    }
}