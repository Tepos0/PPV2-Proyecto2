using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LessonContainer : MonoBehaviour
{
    /// <summary>
    /// Este script est� creado para alamacenar los scriptable objects que usaremos para selecccionar cada leccion dependiendo del bot�n que apretemos.
    /// (los scriptable objects son recursos wue nos ayudan a almacenar informaci�n)
    /// </summary>

    //Est�s variables se utilizan para alamacenar la informacion tanto de la Secci�n actual, la lecci�n actual y el total de lecciones

    [Header("Gameobject Configuration")]
    public int Lection = 0;
    public int CurrentLesson = 0;
    public int Totallessons = 0;
    public bool AreAllLessonsComplete = false;

    //Est�s variables se utilizan para tener la referencia de la configuraci�n y de la UI, agregando las librerias de UnityEngine.UI y TMPro
    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header ("External GameObjects Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject lessonData;
    public string LessonName;

    void Start()
    {
        if (lessonContainer != null)
        {
         OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo GameObject LessonContainer");
        }
    }

    //Crearemos un metodo en el cual estar� toda la informacion que necesitemos obtener a la hora de actualizar los textos, tambien agregamos un if que nos enviara
    //una alerta en vez de marcarnos error, esto para advertirnos que falta informaci�n o esta incorrecta 
    public void  OnUpdateUI()
    {
        if (StageTitle != null || LessonStage !=null)
        {
            StageTitle.text = "Leccion" + Lection;
            LessonStage.text = " Leccion " + CurrentLesson + " de " + Totallessons;
        }
        else
        {
            Debug.LogWarning("GameObject nulo, revisa las variables de tipo TMP_Text");
        }

    }
    //Este metodo nos sirve para activar y desactivar el LessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            //Desactiva el objeto si est� activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activa el objeto si est� desactivado
            lessonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
        
    }

}
