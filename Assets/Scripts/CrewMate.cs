using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrewMate : MonoBehaviour
{
    string[] ViableHobbies = new[] { "Soccer", "Rugby", "Swimming", "Rock Climbing", "Tennis", "Volleyball", "Video Games", "Sky Diving" };
    string[] ParasiteHobbies = new[] { "Kickball", "Aggressive Group Hug Zone Control", "Water Traversal", "Scaling of Rock Faces", "Hitting Balls with Sticks", "Slapping Balls", "Computational Games", "Falling Out of Flying Machines" };
    string[] Names = new[] { "Andrew", "Brian", "Carmen", "Derrick", "Elisa", "Fred", "George", "Hailey", "Ilya", "Karren", "Liam", "Noelene", "Oscar", "Peter", "Quinton", "Raphael", "Stephen", "Timothy", "Ursula", "Viktor", "Wilfred", "Xavier", "Yukio", "Zimba'qwer!Tulu" };

    [SerializeField]
    public bool isParasite;

    [SerializeField]
    public TMP_Text crewMateName;
    [SerializeField]
    public TMP_Text crewMateHobby;
    public Button Accept;
    public Button Reject;

    // Start is called before the first frame update
    void Start()
    {
        crewMateName.text = Names[Random.Range(0, Names.Length - 1)];
        if (isParasite)
        {
            crewMateHobby.text = ParasiteHobbies[Random.Range(0, ParasiteHobbies.Length - 1)];
        }
        else
        { 
            crewMateHobby.text = ViableHobbies[Random.Range(0, ViableHobbies.Length - 1)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
