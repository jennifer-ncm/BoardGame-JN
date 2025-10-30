using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // detect collision with the target
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Ball Hit the target!");

            Invoke("LoadNextScene", 0.5f);
        }

        if (collision.gameObject.CompareTag("BallLost"))
        {
            Debug.Log("Ball is lost");

            // Reload current scene in 2 seconds (so that the sound can play)
            Invoke("ReloadScene", 2f);
        }
    }

    private void ReloadScene()
    {
        // Load next scene or the first scene if we are at the last scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
    private void LoadNextScene()
    {
        // Load next scene or the first scene if we are at the last scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}


