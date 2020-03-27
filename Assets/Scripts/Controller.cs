using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    float _speed = 50f;

    void Awake()
    {
        TouchController.onMove += Move;
    }

    void Move(TouchController.Direction x)
    {
        if(x == TouchController.Direction.Left)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Right)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Forward)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Backward)
        {
            transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
    }

    void OnDestroy()
	{
        TouchController.onMove -= Move;
    }
}
