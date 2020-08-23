using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    private void update()
    {
        //if r key is pressed start the current scene
        if(Input.GetKeyDown(KeyCode.R) && (_isGameOver == true))
        {
            SceneManager.LoadScene(1);// current gamescene
        }


    }

    public void GameOver()
    {
        _isGameOver = true;
        Debug.Log("GameManager::GameOver() Called");

    }

}
