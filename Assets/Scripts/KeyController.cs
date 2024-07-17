using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class KeyController : MonoBehaviour
{
    float originalY;
    private float floatStrength = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.PickUpKey();

            StartCoroutine(KeyCollectedAnimationTimer());
        }
    }

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
                                         originalY + ((float)Math.Sin(Time.time) * floatStrength),
                                         transform.position.z);
    }

    IEnumerator KeyCollectedAnimationTimer()
    {
        yield return new WaitForSeconds(0.2f);

        Destroy(this.gameObject);
    }
}
