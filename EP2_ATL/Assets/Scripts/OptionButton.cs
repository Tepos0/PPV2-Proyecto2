using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Este script esta creado para setear los botones de las respuestas 
/// </summary>
public class OptionButton : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    // En este metodo asignamos el nombre que llevara cada opción del boton
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Este metodo actualiza la información del boton
    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    //Este metodo es para el boton de comprobar que nos dira si a respuesta es correcta o incorrecta y poteriormente actualizara los demas botones 
    public void SelectionOption()
    {
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        LevelManager.Instance.CheckPlayerState();
    }

}
