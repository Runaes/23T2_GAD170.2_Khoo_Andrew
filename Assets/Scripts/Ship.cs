using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Button HireNew;
    public Button CrewList;
    public GameObject CrewMatePrefab;
    public GameObject CrewListPrefab;
    public GameObject Victory;
    public TMP_Text CrewCount;
    public AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        HireNew.onClick.AddListener(CreateCrewPrefab);
        CrewList.onClick.AddListener(CreateListPrefab);
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
            //play amongus wav.
            if (Crew.Count > 0)
            {
                death.Play();
            }
            if (Crew.Count > 0)
            {
                var hobbyToKill = Crew.ToArray()[Random.Range(0, Crew.Count - 1)].crewMateHobby.text;
                Crew = Crew.Where(c => c.crewMateHobby.text != hobbyToKill).ToList();
                // play murder sound
            }
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

            var prefab = Instantiate(Victory);
            var victory = prefab.GetComponent<Victory>();
            victory.Text.text = victoryList;
            Destroy(this.transform.parent);
        }

        CrewCount.text = Crew.Count.ToString();
    }

    void CreateCrewPrefab()
    {
        // we don't want them spamming this if there's one made
        HireNew.enabled = false;
        var prefab = Instantiate(CrewMatePrefab);
        var crewMate = prefab.GetComponent<CrewMate>();
        crewMate.isParasite = Random.Range(0, 100) > 70;
        crewMate.accept.onClick.AddListener(() =>
        {
            // instantiate a clone so we don't null ref on destroyed prefabs
            AddCrewMate(crewMate.CloneViaFakeSerialization());
            HireNew.enabled = true;

        });
        crewMate.accept.onClick.AddListener(() => DestroyCrew(prefab));
        crewMate.reject.onClick.AddListener(() => DestroyCrew(prefab));
    }
    
    void DestroyCrew(GameObject prefab)
    {
        Destroy(prefab);
        KillCrewList();
        HireNew.enabled = true;
    }

    void KillCrewList()
    {
        if (CrewPrefab != null)
        {
            Destroy(CrewPrefab);
            CrewPrefab = null;
        }
    }

    void CreateListPrefab()
    {
        if (CrewPrefab == null)
        {
            CrewPrefab = Instantiate(CrewListPrefab);
            CrewPrefab.GetComponent<CrewList>().CrewListText.text = GetCrewList;
        }
        else
        {
            Destroy(CrewPrefab);
            CrewPrefab = null;
        }
    }
    GameObject CrewPrefab;

    public string GetCrewList => string.Join("\r\n", Crew.Select(c => $"\tName: {c.crewMateName.text}, Hobby: {c.crewMateHobby.text}"));
}
