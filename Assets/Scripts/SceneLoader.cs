using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneType currentScene { get; private set; }
    public static void LoadScene(SceneType type)
    {
        
     

    }
    IEnumerator ILoadScene(SceneType type)
    {


        yield return SceneManager.LoadSceneAsync(type.ToString());

        yield return null;
    }
}