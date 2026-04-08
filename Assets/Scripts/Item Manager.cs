using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    private bool winGame;

    void Update()
    {
        if (winGame == true) return;

        if(AllItemsDestroyed())
        {
            Win();
        }
    }

    private bool AllItemsDestroyed()
    {
        foreach(GameObject item in items)
        {
            if(item != null)
            {
                return false;
            }
        }

        return true;
    }

    private void Win()
    {
        winGame = true;
        SceneManager.LoadScene("WinScene");
    }


}
