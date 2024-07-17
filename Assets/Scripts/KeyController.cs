using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(this.gameObject);
        }
    }
}
