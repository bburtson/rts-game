using RTS_TEST;
using RTS_TEST.Assets.Shared.Enumerations;
using UnityEngine;


public class RTSCamera : MonoBehaviour, IPropPhysics
{
    private UserPreferences preferences;

    private float ViewWidth { get { return Screen.width; } }

    private float ViewHeight { get { return Screen.height; } }

    private bool CursorOutOfBounds
    {
        get
        {
            return Input.mousePosition.y < preferences.ScrollBoundary * -2 ||
                   Input.mousePosition.x < preferences.ScrollBoundary * -2 ||
                   Input.mousePosition.y > ViewHeight + (preferences.ScrollBoundary * 2) ||
                   Input.mousePosition.x > ViewWidth + (preferences.ScrollBoundary * 2);
        }
    }

    void Start()
    {
        preferences = FindObjectOfType<MainNode>().UserPreferences;
    }


    void FixedUpdate()
    {
        DoMovement();
    }

    public void Move(DirectionOptions direction, float speed)
    {
        var destination = transform.position;

        speed *= Time.deltaTime;

        if (direction == DirectionOptions.Left) destination.x -= speed;

        else if (direction == DirectionOptions.Right) destination.x += speed;

        else if (direction == DirectionOptions.Up) destination.z += speed;

        else if (direction == DirectionOptions.Down) destination.z -= speed;

        transform.position = destination;
    }


    private void DoMovement()
    {
        if (CursorOutOfBounds) return;

        if (Input.mousePosition.x < preferences.ScrollBoundary)
        {
            Move(DirectionOptions.Left, preferences.ScrollSpeed);
        }

        if (Input.mousePosition.x > ViewWidth - preferences.ScrollBoundary)
        {
            Move(DirectionOptions.Right, preferences.ScrollSpeed);
        }

        if (Input.mousePosition.y > ViewHeight - preferences.ScrollBoundary)
        {
            Move(DirectionOptions.Up, preferences.ScrollSpeed);
        }

        if (Input.mousePosition.y < preferences.ScrollBoundary)
        {
            Move(DirectionOptions.Down, preferences.ScrollSpeed);
        }
    }
}
