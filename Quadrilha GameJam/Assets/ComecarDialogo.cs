using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComecarDialogo : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<DialogoAoColidir>().comecaDialogo();
    }
}
