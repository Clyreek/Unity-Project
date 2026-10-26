using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // GameObjects
    public Transform CamTransform;
    public GameObject DirectionalLight;
    public Transform LightTransform;
    // Ints
    private int CurrentAge = 30;
    public int AddedAge = 1;
    public int CurrentGold = 32;
    int PlayerLives = 3;

    // Bools
    public bool PureOfHeart = true;
    public bool HasSecretSpell = false;
    public string RareItem = "Relic Stone";
    public bool IsAuthor = true;
    public bool HasDungeonKey = true;
    
    public float Pi = 3.14f;
    
    //Strings
    public string FirstName = "Clyric";
    string CharacterAction = "Attack";
   

    // Start is called before the first frame update
    void Start()
    {
        // Finds directional light component
        // DirectionalLight = GameObject.Find("Directional Light");

        LightTransform = DirectionalLight.GetComponent<Transform>();

        //From Character Class
        Character hero = new Character();
        Character hero2 = hero; //Reference Types
        hero2.name = "Sir Krane the Brave"; // Reference Types
        
        //Camera
        CamTransform = this.GetComponent<Transform>();
        Debug.Log(CamTransform.localPosition);

        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();
        //hero2.Reset();

        


        Character Heroine = new Character("Agatha");
        Heroine.PrintStatsInfo();

        


        //Weapon
        Weapon HuntingBow = new Weapon("Hunting Bow", 105);
        Weapon warBow = HuntingBow; //Value Types
        
        HuntingBow.PrintWeaponStats();
        warBow.PrintWeaponStats();

        Paladin knight = new Paladin("Sir Arthur", HuntingBow);
        knight.PrintStatsInfo();

        // Attack decider
        PrintCharacterAction();
        
        OpenTreasureChamber();

        HealthStatus();

        

        

       if (HasDungeonKey)
        {
            Debug.Log("You Possess the key - enter.");
        }
        else
        {
            Debug.Log("It's Locked");
        }
        Thievery(); // Line 62

        FindPartyMember();
        // Inventory Count
        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
        {
            {"Potion", 5 }, {"Antidote", 7}, {"Aspirin", 1}
        };

        foreach (KeyValuePair<string, int> kvp in ItemInventory)
        {
            Debug.LogFormat("Item: {0} - {1}g", kvp.Key, kvp.Value);
        }

        Debug.LogFormat("Items: {0}", ItemInventory.Count);
        

        ComputeAge();

        Debug.Log($"A string can have variables like{FirstName} inserted directly!");

        int CharacterLevel = 32;
        GenerateCharacter("Ted", CharacterLevel);

        int NextLevel = GenerateCharacter("Ted", CharacterLevel);
        Debug.Log(NextLevel);
        Debug.Log(GenerateCharacter("Fey", CharacterLevel));

        //Dice Roll Switch
        int DiceRoll = 7;

        switch(DiceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediocre damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, creature goes down");
                break;
            default:
                Debug.Log("You suck");
                break;

        }

       
    }

    public int GenerateCharacter( string name, int level)
    {
        Debug.Log("Movie: Ted");
        // Debug.LogFormat("Character: {0} - level: {1}", name, level);

        return level += 5;
    }

    /// <summary>
    /// Time for action- adding comments
    /// Computesa modified age integer
    /// </summary>
    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }

    // How much coin is in pocket
    public void Thievery()
        {

            if (CurrentGold > 50)
            {
                Debug.Log("You're rich!!");
            }
            else if (CurrentGold < 15)
            {
                Debug.Log("Not much there to steal");
            }
            else
            {
                Debug.Log("You're in the sweet spot.");
            }
        }

    // Attack Switch Program
    

    // Update is called once per frame
    void Update()
    {
    
        
    }
    
    
    public void OpenTreasureChamber()
    {
        if (PureOfHeart && RareItem == "Relic Stone")
        {
            if (!HasSecretSpell)
            {
                Debug.Log("You have the spirit, but not the knowledge");
            }
            else
            {
                Debug.Log("You are Worthy!");
            }
        }
        else
        {
            Debug.Log("Come back when you are worthy");
        }
    }

    public void PrintCharacterAction()
    {
        switch(CharacterAction)
        {
            case "Heal":
                Debug.Log("Potion Sent.");
                break;
            case "Attack":
                Debug.Log("To Arms");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }

    public void FindPartyMember()
    {
        //List example
        List<string> QuestPartyMembers = new List<string>()
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling Knight"
        };

        Debug.LogFormat("Party Members: {0}", QuestPartyMembers.Count);

        

        // For list Team members
        for (int i = 0; i < QuestPartyMembers.Count; i++)
        {
            Debug.LogFormat("Index: {0} - {1}", i, QuestPartyMembers[i]);

            if (QuestPartyMembers[i] =="Merlin the Wise")
            {
                Debug.Log("Glad you're here Merlin");
            }
            // ForEach find Party member
            foreach ( string partyMember in QuestPartyMembers)
            {
                Debug.LogFormat("{0} - Here!", partyMember);
            }
        }
    }

    // Health Status
    public void HealthStatus()
        {
            while(PlayerLives>0)
            {
                Debug.Log("Still alive!");
                PlayerLives--;
            }
            Debug.Log("Player K.O'd...");
        }
    
        
}

