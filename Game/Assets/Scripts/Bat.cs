
using UnityEngine;

class Bat : MonoBehaviour
{

    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    bool canMoveLeft = true;
    bool canMoveRight = true;

    public float speed = 0.2f;
    float direction = 0.0f;


    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }

    //Checks for buttons pressed and moves the bat

    void Update()
    {
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);

        if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }
        else if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f;
        }
    }

    //Checks for collisions

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name) //If the bat hits a wall, stop it from moving in that direction
        {
            case "Left Wall":
                canMoveLeft = false; 
                break;

            case "Right Wall":
                canMoveRight = false;
                break;
        }
    }

    //Checks for collisions

    void OnCollisionExit2D(Collision2D other) 
    {
        switch (other.gameObject.name) //If the bat hits a wall, stop it from moving in that direction
        {
            case "Left Wall":
                canMoveLeft = true;
                break;

            case "Right Wall":
                canMoveRight = true;
                break;
        }
    }
}