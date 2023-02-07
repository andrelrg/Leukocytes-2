using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    private Transform player;
    public Transform gun;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform;
        gun.SetParent(player);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aimDirection = mainCamera.transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(aimDirection);
        gun.rotation = targetRotation;
    }
}
