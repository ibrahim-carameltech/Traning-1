using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;

    void Awake()
    {
        TouchController.onMove += move;
    }

    void move(TouchController.Direction x)
    {
        if(x == TouchController.Direction.Left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Forward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(x == TouchController.Direction.Backward)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        Debug.Log("Test " + x);
    }

    void OnDestroy()
	{
        TouchController.onMove -= move;
    }
}
