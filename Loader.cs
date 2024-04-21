using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    //This is the index of the scene the LoaderZone will load
    [SerializeField]
    private int thisLoad;

    //Loads a scene based on the index
    private void loader(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    //When the player enters a LoaderZone the new scene is loaded
    public void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.tag == "SharedPlayer")
        {
            loader(thisLoad);
        }
    }

    //Loads the first scene, for testing
    public void menuLoad()
    {
        loader(1);
    }
}

