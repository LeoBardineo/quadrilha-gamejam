using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EventosDoDia : MonoBehaviour
{
    public PlayableDirector timeline;
    public AudioListener audioListener;
    
    public void terminarDia(){
        esperaSegundos(System.Convert.ToInt32(timeline.duration));
    }

    void esperaSegundos(int segundos){
        StartCoroutine(esperaCoroutine(segundos));
    }

    IEnumerator esperaCoroutine(int segundos){
        timeline.Play();
        audioListener.enabled = false;
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
