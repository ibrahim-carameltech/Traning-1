using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    float speed = 50f;
    float movePercentage = 20f;

    Vector2 startPosition;
    Vector2 endPosition;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endPosition = touch.position;
                float xMoved = endPosition.x - startPosition.x;
                float yMoved = endPosition.y - startPosition.y;
                bool swipedHorizontal = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));

                bool percentageHorizontal = (distance > ((Screen.width / 100) * movePercentage));
                bool percentageVertical = (distance > ((Screen.height / 100) * movePercentage));

                if(swipedHorizontal && xMoved > 0 && percentageHorizontal)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                else if(swipedHorizontal && xMoved < 0 && percentageHorizontal)
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if(!swipedHorizontal && yMoved > 0 && percentageVertical)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else if(!swipedHorizontal && yMoved < 0 && percentageVertical)
                {
                    transform.Translate(Vector3.back * speed * Time.deltaTime);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

}
