using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            StartCoroutine(DeathAnimationWait());
        }
    }

    IEnumerator DeathAnimationWait()
    {
        yield return new WaitForSeconds(0.31f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
