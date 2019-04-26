using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public static Swipe Instance { set;get; }
    private Vector3 fp;   
    private Vector3 lp;
    private bool tap,swipeLeft,swipeRight,swipeUp,swipeDown;
    private float dragDistance;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100;
    }
    void Update()
    {
        //reset bool
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        // check inputs
      /*  #region Stanalone inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            fp = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion*/
        #region Moblie inputs
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
                tap = true;
              
            }
            else if (touch.phase == TouchPhase.Moved) 
            {
                lp = touch.position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended) 
            {
                lp = touch.position;
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            swipeRight = true;
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
                            swipeLeft = true;
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            swipeUp = true;
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            swipeDown = true;
                            Debug.Log("Down Swipe");
                        }
                        Reset();
                    }
                }
            }
        }
        #endregion

       /* //calcalate distance
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            if (Input.touches.Length != 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        if(swipeDelta.magnitude > 100)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;

            }
            Reset();

        }*/

    }
    private void Awake()
    {
        Instance = this;
    }

    private void Reset()
    {
        fp = lp = Vector3.zero;
    }
    public bool Tap { get { return tap; } }
   // public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

}
