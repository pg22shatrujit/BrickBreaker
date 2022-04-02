using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundsHandler : MonoBehaviour
{
    const string BRICK_BREAKER_NAME = "Breaker";

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Reset the scene if the ball falls out of the level
        if(collision.gameObject.name == BRICK_BREAKER_NAME)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
