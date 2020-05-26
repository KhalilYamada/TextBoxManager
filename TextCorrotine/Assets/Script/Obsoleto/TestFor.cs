using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFor : MonoBehaviour
{
    bool ativou = true;
    bool textBoxLigada = false;
    public GameObject textBox;


    private void Start()
    {
        textBox.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ativou == true)
        {
            ativou = false;
            StartCoroutine(Teste());
        }
    }


    IEnumerator Teste()
    {
        for(int i = 0; i < 5; i++)
        {
            Debug.Log("reescreve texto");
            if(textBoxLigada == false)
            {
                textBox.SetActive(true);
                textBoxLigada = true;
            }
            yield return new WaitForSeconds(1);
        }
        Debug.Log("acabou");
        textBox.SetActive(false);
        Destroy(gameObject);
    }


}
