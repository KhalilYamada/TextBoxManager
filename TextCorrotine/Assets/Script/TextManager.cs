using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject textBox;

    bool ativou = true;
    bool textBoxLigada = false;

    [HideInInspector]
    public int currentLine = 0;
    [HideInInspector]
    public int endAtLine;

    public Text theText;   

    public TextAsset textFile;
    public string[] textLines;

    private void Start()
    {
        textBox.SetActive(false);
        AssimilaTexto();
        endAtLine = textLines.Length;
    }


    void AssimilaTexto()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ativou == true)
        {
            Debug.Log("asd");
            ativou = false;
            StartCoroutine(Teste());
        }
    }


    IEnumerator Teste()
    {
        for (int i = 0; i < endAtLine; i++)
        {
            theText.text = textLines[currentLine];
            if (textBoxLigada == false)
            {
                textBox.SetActive(true);
                textBoxLigada = true;
            }
            yield return new WaitForSeconds(3);
            currentLine++;
        }
        textBox.SetActive(false);
        Destroy(gameObject);
    }
}
