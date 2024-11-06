using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        // if either player collides with pit, gameOver is true, which disables movement in PlayerMovement.cs
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
