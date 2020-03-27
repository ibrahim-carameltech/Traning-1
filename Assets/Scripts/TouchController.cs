using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public enum Direction {Left, Right, Forward, Backward};

    public delegate void OnMovement(Direction x);
    public static event OnMovement onMove;


    Vector2 _startPosition;
    Vector2 _endPosition;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    float _movePercentage = 20f;

      void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                _endPosition = touch.position;
                float xMoved = _endPosition.x - _startPosition.x;
                float yMoved = _endPosition.y - _startPosition.y;
                bool swipedHorizontal = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));

                bool percentageHorizontal = (distance > ((Screen.width / 100) * _movePercentage));
                bool percentageVertical = (distance > ((Screen.height / 100) * _movePercentage));

                if(swipedHorizontal && xMoved > 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Right);
                }
                else if(swipedHorizontal && xMoved < 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Left);
                }
                else if(!swipedHorizontal && yMoved > 0 && percentageVertical && onMove != null)
                {
                    onMove(Direction.Forward);
                }
                else if(!swipedHorizontal && yMoved < 0 && percentageVertical && onMove != null)
                {
                    onMove(Direction.Backward);
                }
            }
        }
    }

}
