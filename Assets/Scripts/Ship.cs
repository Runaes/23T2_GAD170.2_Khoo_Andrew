using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<CrewMate> Crew = new List<CrewMate>();

    public void AddCrewMate(CrewMate crewMate)
    {
        if (crewMate.IsParasite)
        {
            var hobbyToKill = Crew.ToArray()[Random.Range(0, Crew.Count - 1)].Hobby;
            Crew = Crew.Where(c => c.Hobby != hobbyToKill).ToList();
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
{Crew.Select(c => $"\tName: {c.Name}, Hobby: {c.Hobby}\r\n")}";
            // play victory fanfare
        }
    }
}
