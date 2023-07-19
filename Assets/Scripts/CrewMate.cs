using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewMate
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] ViableHobbies = new [] { "Soccer", "Rugby", "Swimming", "Rock Climbing", "Tennis", "Volleyball", "Video Games", "Sky Diving"};
    string[] ParasiteHobbies = new [] { "Kickball", "Aggressive Group Hug Zone Control", "Water Traversal", "Scaling of Rock Faces", "Hitting Balls with Sticks", "Slapping Balls", "Computational Games", "Falling Out of Flying Machines"};
    string[] Names = new [] { "Andrew", "Brian", "Carmen", "Derrick", "Elisa", "Fred", "George", "Hailey", "Ilya", "Karren", "Liam", "Noelene", "Oscar", "Peter", "Quinton", "Raphael", "Stephen", "Timothy", "Ursula", "Viktor", "Wilfred", "Xavier", "Yukio", "Zimba'qwer!Tulu" }; 

    public string Name;
    public string Hobby;
    public bool IsParasite;
    public void UpdateCrewMate(bool isParasite)
    {
        
        Name = Names[ Random.Range(0,Names.Length - 1)];
        IsParasite = isParasite;
        if (isParasite)
        {
            Hobby = ParasiteHobbies[ Random.Range(0,ParasiteHobbies.Length - 1)];
        }
        else
        {
            Hobby = ViableHobbies[ Random.Range(0,ViableHobbies.Length - 1)];
        }
    }
}
