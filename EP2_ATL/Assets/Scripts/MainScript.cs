using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Este script se utiliza para administrar todos los scripts
/// </summary>
public class MainScript : MonoBehaviour
{
   public static MainScript instance;
    public string SelectedLesson = "Dummy";

    private void Awake()
    {
       if ( instance != null )
        {
            return;
        }
       else
        {
            instance = this;
        }
    }

    //Este metodo se encarga sellecionar la lección y poder empezarla
    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }
}
