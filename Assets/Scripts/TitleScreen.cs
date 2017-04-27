using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ArcadePUCCampinas;

public class TitleScreen : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

        if (InputArcade.Apertou(0, EControle.VERDE))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        if (InputArcade.Apertou(1, EControle.VERDE))
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        if (InputArcade.Apertou(0, EControle.VERMELHO))
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        if (InputArcade.Apertou(1, EControle.VERMELHO))
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }
}
