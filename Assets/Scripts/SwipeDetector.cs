using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float swipeDistanceThreshold = 50f;
    public Pacman pac;

    private void Start()
    {
        pac = GetComponent<Pacman>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            DetectSwipe();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipe();
                    break;
            }
        }
    }

    private void DetectSwipe()
    {
        float swipeDistance = Vector2.Distance(startTouchPosition, endTouchPosition);

        if (swipeDistance >= swipeDistanceThreshold)
        {
            Vector2 swipeDirection = endTouchPosition - startTouchPosition;

            swipeDirection.Normalize();

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                    pac.movement.SetDirection(Vector2.right);

                else
                    pac.movement.SetDirection(Vector2.left);
            }
            else
            {
                if (swipeDirection.y > 0)
                    pac.movement.SetDirection(Vector2.up);
                else
                    pac.movement.SetDirection(Vector2.down);
            }
        }
    }
}
