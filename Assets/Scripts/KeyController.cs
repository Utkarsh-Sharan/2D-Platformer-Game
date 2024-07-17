using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator _keyAnimator;

    private void Awake()
    {
        _keyAnimator = GetComponent<Animator>(); 
        if(_keyAnimator == null)
        {
            Debug.LogError("Key animator null!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.PickUpKey();

            StartCoroutine(KeyCollectedAnimationTimer());
            Destroy(this.gameObject);
        }
    }

    IEnumerator KeyCollectedAnimationTimer()
    {
        _keyAnimator.SetBool("Collected", true);
        yield return new WaitForSeconds(2f);
    }
}
