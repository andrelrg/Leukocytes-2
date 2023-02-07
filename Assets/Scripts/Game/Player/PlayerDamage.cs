using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float playerHealth = 100f;
    public float healthBarLength;
    private float maxPlayerHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            playerHealth -= 10;

            if (playerHealth <= 0)
            {
                Debug.Log("Morreu");
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, Screen.height - 40, healthBarLength, 20), "Player Health: " + playerHealth + "/" + maxPlayerHealth);
    }
}
