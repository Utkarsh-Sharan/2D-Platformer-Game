using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(speed));
        Vector2 _scale = transform.localScale;

        if(speed < 0)
        {
            _scale.x = -1.0f * Mathf.Abs(_scale.x);
        }
        else if(speed > 0)
        {
            _scale.x = Mathf.Abs(_scale.x);
        }

        transform.localScale = _scale;
    }
}
