using TMPro;
using UnityEngine;

public class CrewList : MonoBehaviour
{
    [SerializeField]
    public TMP_Text CrewListText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CrewList(string crew)
    {
        CrewListText.text = crew;
    }
}
