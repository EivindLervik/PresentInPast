using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    public string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

	public void ChangeScene(string to)
    {
        SceneManager.LoadScene(to);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(to));
        //SceneManager.UnloadScene(currentScene);
        currentScene = to;
    }
}
