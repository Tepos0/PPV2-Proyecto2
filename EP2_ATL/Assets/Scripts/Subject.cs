using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Este script esta creado para alamacenar los recursos de tipo personalizable que necesitamos para consultar los datos de cada lección
/// </summary>

[CreateAssetMenu(fileName = "New subject" , menuName = "ScriptableObjects/New_lesson" , order =1)]


public class Subject : ScriptableObject
{
    [Header ("Gameobject Configuration")]
    public int lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Leccion> leccionList;

}
