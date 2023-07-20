using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrewMate : MonoBehaviour
{
    string[] ViableHobbies = new[] { "Soccer", "Rugby", "Swimming", "Rock Climbing", "Tennis", "Volleyball", "Video Games", "Sky Diving" };
    string[] ParasiteHobbies = new[] { "Kickball", "Aggressive Group Hug Zone Control", "Water Traversal", "Scaling of Rock Faces", "Hitting Ball With Hand Held Object", "Hitting Ball With Hands", "Computational Visual Entrertainment", "Falling Out Of Flying Vehicle" };
    string[] Names = new[] { "Andrew", "Brian", "Carmen", "Derrick", "Elisa", "Fred", "George", "Hailey", "Ilya", "Karren", "Liam", "Noelene", "Oscar", "Peter", "Quinton", "Raphael", "Stephen", "Timothy", "Ursula", "Viktor", "Wilfred", "Xavier", "Yukio", "Zimba'qwer!Tulu" };

    [SerializeField]
    public bool isParasite;

    [SerializeField]
    public TMP_Text crewMateName;
    [SerializeField]
    public TMP_Text crewMateHobby;
    public Button accept;
    public Button reject;
    public Image picture;


    // Start is called before the first frame update
    void Start()
    {
        // i'm aware of the spelling mistake, i'm just too lazy to fixe it for every item now.
        var path = $"Assets/portaits/portait ({Random.Range(1,8)}).jpg";
        var bytes = File.ReadAllBytes(path);
        var profile = new Texture2D(1,1);

        profile.LoadImage(bytes);
        picture.sprite = Sprite.Create(profile, new Rect(0, 0, profile.width, profile.height), new Vector2(0.5f, 0.5f));

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
