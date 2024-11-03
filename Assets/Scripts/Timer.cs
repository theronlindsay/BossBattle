using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //After 5 seconds, load next scene
        Invoke("LoadNextScene", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
