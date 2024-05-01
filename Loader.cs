using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    //This is the index of the scene the LoaderZone will load
    [SerializeField]
    private int thisLoad;
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;

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
            moveToEntrance(collision);

        }
    }

    private void moveToEntrance(Collider2D player)
    {
        player.transform.position = new Vector3(x, y, 0);

    }

    //Loads the first scene, for testing
    public void menuLoad()
    {
        loader(1);
      
    }
}

