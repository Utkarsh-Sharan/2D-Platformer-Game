using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _playerTransform.position + new Vector3(0, 0, -10);
    }
}
