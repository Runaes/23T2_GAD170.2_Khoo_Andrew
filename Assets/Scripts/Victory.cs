using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Button Quit;
    public TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Quit.onClick.AddListener(() => Application.Quit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
