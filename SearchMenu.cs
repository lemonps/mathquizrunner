using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SearchMenu: MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MathRun");
    }
}
