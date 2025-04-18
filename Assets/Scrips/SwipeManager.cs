using UnityEngine;

namespace Scrips
{
    public class SwipeManager : MonoBehaviour
    {
        public static bool swipeLeft, swipeRight, swipeUp, swipeDown;
        private Vector2 startTouch, swipeDelta;
        private bool isDragging;

        void Update()
        {
            swipeLeft = swipeRight = swipeUp = swipeDown = false;

            #region PC TESTING
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Reset();
            }
            #endregion

            if (isDragging)
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

                if (swipeDelta.magnitude > 100)
                {
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x < 0) swipeLeft = true;
                        else swipeRight = true;
                    }
                    else
                    {
                        if (y > 0) swipeUp = true;
                        else swipeDown = true; // ✅ Thêm vuốt xuống
                    }

                    Reset();
                }
            }
        }

        void Reset()
        {
            isDragging = false;
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}