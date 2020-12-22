using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/**
*   This class handles scene changes
*/
public class ChangeScene : MonoBehaviour
{
    /**
    *   Load scene by given id
    */
    public void ChangeToScene(int changeTheScene){
        SceneManager.LoadScene(changeTheScene);
    }
}
