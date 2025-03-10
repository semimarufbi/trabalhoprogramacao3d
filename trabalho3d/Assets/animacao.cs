using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{
    Animator animacaos;

    // Start is called before the first frame update
    void Start()
    {
        animacaos = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Inicia a animação de dança
            animacaos.SetTrigger("danca");
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Para a animação de dança e retorna para o estado "parar" ou "idle"
            animacaos.SetTrigger("parar");
        }
    }
}
