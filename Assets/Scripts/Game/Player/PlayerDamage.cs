using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float playerHealth = 100f;
    public float healthBarLength;
    private float maxPlayerHealth = 100f;

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
                StartCoroutine(PlayerDied());
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, Screen.height - 40, healthBarLength, 20), "Player Health: " + playerHealth + "/" + maxPlayerHealth);
    }

    IEnumerator PlayerDied()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Player Died");
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
