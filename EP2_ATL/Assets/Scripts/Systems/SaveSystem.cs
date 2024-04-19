using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;

using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    /// <summary>
    /// Este script es de los mas importante ya que en este se econtraran los metodos de guardado de las lecciones
    /// </summary>
    public static SaveSystem instance;
    public Leccion data;
    public SubjectContainer subject;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }

    //Este metodo es el que se encarga de seleccionar la ubicación en donde se almacenara la información de guardado
    public void SaveToJson(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data, true);

            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/StreamingAssets/" + fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la dirección: " + filePath);
            }

            else
            {
                Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }

        else
        {
            Debug.LogWarning("ERROR - FileSystmen: _data is null, check for param [obect _data");
        }
    }

    //Este metodo se encarga de cargar la información de la lección en el JSON 
    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T Dato = new T();
        string path = Application.dataPath + "/StreamingAssets/" + _fileName + ".json";
        string JSONData = "";
        if (File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON STRING : " + JSONData);
        }
        if (JSONData.Length  !=0 )
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }
        else
        {
            Debug.LogWarning("ERROR - FileSystem: JSON Data is empty, check for local variable [String JSONData");
        }
        return Dato;

    }
    
    //esta función esta creada para crear el lugar donde guaradaremos los datos
    public void CreateFile(string _name , string _extension)
    {
        //1.-Definir el path del archivo
        string path = Application.dataPath + "/" + _name + _extension;
        //2.-Revisamos si el archivo en el path NO existe
        if(!File.Exists(path))
        {
            //3.-Creamos el contenido
            string content = "Login Date:" + System.DateTime.Now + "/";
            string position = "X:" + transform.position.x + "Y:" + transform.position.y;
            //4.-Almacenamos la información
            File.AppendAllText(path, position);
        }
        else
        {
            Debug.LogWarning("Atención, estas tratando de crear un archivo con el mismo nombre[" + _name + _extension + "], verifica tu informacion.");
        }

        
    }
        string ReadFile(string _filename, string _extension)
        {
            //1.-Acceder al path del archivo
            string path = Application.dataPath + "/StreamingAssets/" + _filename + _extension;
            //2.-Si existe el archivo, nos dara su informacion
            string data = "";
            if (File.Exists(path))
            {
                data = File.ReadAllText(path);
            }
            return data;  
        }
}
