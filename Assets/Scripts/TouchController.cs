using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public enum Direction {Left, Right, Forward, Backward};

    public delegate void OnMovement(Direction x);
    public static event OnMovement onMove;


    Vector2 startPosition;
    Vector2 endPosition;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    float movePercentage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
