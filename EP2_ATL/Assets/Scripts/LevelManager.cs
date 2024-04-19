using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Este script esta creado para administrar toda la inforacion de la lección, la sección y las preguntas 
/// </summary>
public class LevelManager : MonoBehaviour
{
    //
    public static LevelManager Instance;
    [Header("Level Data")]
    
    public SubjectContainer subject;

    //estas son las variables que almacenan los datos que se utilizan para cambiara de pregunta, opcion y respuesta
    [Header("User Interface")]
    public TMP_Text QuestionTxt;
    public TMP_Text livesTxt;
    public List<OptionButton> Options;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    //Estas variables configuran las preguntas
    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer;
    public int lives = 5;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    //Patron Singleton: Es un patrón de diseño, encargado, de crear una instancia de la clase para ser referenciada en otra clase sin la necesidad de declarar una variables.
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    // este metodo esta creado para inicializar las preguntas y configurar el numero de preguntas 
    void Start()
    {
        subject = SaveSystem.instance.subject;
        //Establecemos la cantidad de preguntas en la leccion
        questionAmount = subject.leccionList.Count;
        //Cargar la primera pergunta
        LoadQuestion();
        //check player input
        CheckPlayerState();
    }

    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual esta dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la leccíon actual
            currentLesson = subject.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lessons;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en UI
            QuestionTxt.text = question;
            //Establecemos las Opciones
            Options[0].GetComponent<OptionButton>().OptionName = currentLesson.options[0];
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<OptionButton>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<OptionButton>().OptionID = i;
                Options[i].GetComponent<OptionButton>().UpdateText();
            }
        }
        else
        {
            //Si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }

    //Este metodo esta creado para configurar las preguntas siguientes 
    public void NextCuestion()
    {
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la respuesta es correcta o no
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                AnswerContainer.SetActive(true);

                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    Debug.Log("Respuesta correcta. " + question + ": " + correctAnswer);
                }
                else
                {
                    lives--;
                    AnswerContainer.GetComponent<Image>().color = Red;
                    Debug.Log("Respuesta incorrecta. " + question + ": " + correctAnswer);

                }
                //Actualizamos el contador de vida
                livesTxt.text = lives.ToString();

                //Incrementamos el indice de la pregunta actual
                currentQuestion++;

                //Mostrar el resultado durante un tiempo (puedes usar una corotine o Invoke)
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                //Reset answer from player
                answerFromPlayer = 9;
            }
            else
            {
                //Cambio de escena
            }
        }
    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(2.5f); //Ajusta el tiempo que deseas mostrar el resultado

        //Ocultar el contenedor de respuestas
        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Activar el botón después de mostrar el resultado
        //Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructura
        //por ejemplo, si el botón está en el mismo GameObject que el script:
        //GetComponent<Buttton>().intercatable = true;
        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }
    //Este metodo hace que el boton de respuesta sea interactuable, siempre y cuando contenga información 
    public bool CheckPlayerState()
    {
        if (answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;

        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
