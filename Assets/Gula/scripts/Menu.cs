using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    Button play;
    void Start()
    {
        play = GameObject.Find("botao").GetComponent<Button>();
    }

    private void Update()
    {
        play.onClick.AddListener(Iniciodejogo);
    }
    // Update is called once per frame
    void Iniciodejogo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
