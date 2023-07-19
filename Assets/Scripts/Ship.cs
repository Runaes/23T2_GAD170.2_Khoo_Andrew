using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Button HireNew;
    public Button CrewList;
    public GameObject CrewMatePrefab;
    public GameObject CrewListPrefab;
    public TMP_Text CrewCount;
    // Start is called before the first frame update
    void Start()
    {
        HireNew.onClick.AddListener(CreateCrewPrefab);
        CrewCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<CrewMate> Crew = new List<CrewMate>();

    public void AddCrewMate(CrewMate crewMate)
    {
        if (crewMate.isParasite)
        {
            var hobbyToKill = Crew.ToArray()[Random.Range(0, Crew.Count - 1)].crewMateHobby.text;
            Crew = Crew.Where(c => c.crewMateHobby.text != hobbyToKill).ToList();
            // play murder sound
        }
        else
        {
            Crew.Add(crewMate);
        }

        if (Crew.Count == 10)
        {
            var victoryList = 
$@"You have won!
Your winning crew is:
{GetCrewList}";
            // play victory fanfare
        }
        CrewCount.text = Crew.Count.ToString();
    }

    void CreateCrewPrefab()
    {
        var prefab = Instantiate(CrewMatePrefab);
        var crewMate = prefab.GetComponent<CrewMate>();
        crewMate.isParasite = Random.Range(0, 100) > 70;
        crewMate.Accept.onClick.AddListener(() => AddCrewMate(crewMate));
        crewMate.Accept.onClick.AddListener(() => Destroy(prefab));
        crewMate.Reject.onClick.AddListener(() => Destroy(prefab));
    }


    public string GetCrewList => string.Join("\r\n", Crew.Select(c => $"\tName: {c.crewMateName.text}, Hobby: {c.crewMateHobby.text}"));
}
