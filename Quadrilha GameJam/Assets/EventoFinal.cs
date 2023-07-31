using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoFinal : MonoBehaviour
{
    public void acabarOJogo(){
        SceneManager.LoadScene(0);
    }
}
