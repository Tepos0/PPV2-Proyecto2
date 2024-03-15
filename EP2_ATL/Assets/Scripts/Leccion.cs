using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Este script esta creado para poder almacenar toda la información que necesitamos por cada lección. Aunque necesitemos varias lecciones.
/// </summary>

[System.Serializable]
public class Leccion 
{
    //aqui se guarda el id
    public int ID;
    //Aquí se almacenan las preguntas
    public string lessons;
    //esta es la lista de las opciones de las respuestas
    public List<string> options;
    //aquí se almacena la respuesta correcta 
    public int correctAnswer;

}
