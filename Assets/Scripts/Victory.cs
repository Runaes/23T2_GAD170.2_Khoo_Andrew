using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Button Quit;
    public TMP_Text Text;
    public AudioSource winWav;
    // Start is called before the first frame update
    void Start()
    {
        Quit.onClick.AddListener(() => Application.Quit());
        winWav.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
