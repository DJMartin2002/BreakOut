using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


class Ball : MonoBehaviour

{
    public Text scoreLabel = null;
    public Text livesLabel = null;
    public GameObject GameOverScreen = null;
    public GameObject GameWonScreen = null;
    public Transform bat = null;
    int score = 0;
    int lives = 3;
    int bricksLeft = 28;
    float directionX = -1.0f;
    float directionY = -0.5f;
    float speed = 0.2f;


    //Adding score and checking for win conditions

    public void IncreaseScore(int points)
    {
        score = points + 1;
        scoreLabel.text = "Score: " + score;
        bricksLeft = bricksLeft -1;

        if (bricksLeft <= 0)
        {
            GameWon();
        }    
    }

    //Removing lives and checking for loss conditions

    public void DecreaseLives(int life)
    {
        lives = life - 1;
        livesLabel.text = "Lifes: " + lives;

        if (lives <= 0)
        {
            GameOver(); 
        }  
    }

    //Executing a game over#

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        speed = 0;
    }

    //Executing a game won

    public void GameWon()
    {
        GameWonScreen.SetActive(true);
        speed = 0;
    }

    //Resetting the scene 

    public void PlayAgain(string Game)
    {
        SceneManager.LoadScene(Game);
    }

   
    // Set the direction of the ball in degrees

    void FixedUpdate()
    {

        Vector3 position = transform.localPosition;
        position.x += speed * directionX;
        position.y += speed * directionY;
        transform.localPosition = position;
    }

    // Checks for collisions 

    void OnCollisionEnter2D(Collision2D other)
    {
        // Find whats the ball is coliding with and what to do

     
        switch (other.gameObject.name)
        {
            case "Bat":
                directionY = -directionY; // Invert the direction horizontally
                break;

            case "Brick":
                directionY = -directionY; // Invert the direction horizontally
                Destroy(other.gameObject);
                IncreaseScore(score);
                break;

            case "Top Wall":
                directionY = -directionY; // Invert the direction vertically
                break;

            case "Bottom Wall":

                transform.position = bat.position; // Change the balls position to bat.position
                DecreaseLives(lives);
                break;
               

            case "Right Wall":
            case "Left Wall":
                directionX = -directionX; // Invert the direction vertically
                break;


            default:
                print(name + " has collided with " + other.gameObject.name); // If the ball colides with an object which isnt in the code above
                                                                             // Print a  message telling the object
                break;
        }
    }
}