using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        // If instance is not null then an instance already exists.
        // If instance is null, then no instance exists and this becomes the singleton instance.
        if (instance) Destroy(this);
        else instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}