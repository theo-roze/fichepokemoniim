using UnityEngine;

public class PokemonData : MonoBehaviour
{
    public enum PokemonType
    {
        Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel, Fairy
    }

    [SerializeField] private string PokemonName = "Pikachu";
    [SerializeField] private int StartingHealth = 35;
    [SerializeField] private int Attack = 55;
    [SerializeField] private int Defense = 40;
    [SerializeField] private float weight = 5.9f;
    private int stats;
    private int currentHealth;
    [SerializeField] private PokemonType pokemonType = PokemonType.Electric;
    [SerializeField] private PokemonType[] WeaknessesList = new PokemonType[2];
    [SerializeField] private PokemonType[] ResistancesList = new PokemonType[2];


    void Awake()
    {
        
        InitCurrentLife();
        InitStatsPoints();
        Display();
        
    }

    void Start()
    {

        GetAttackDamage();
   
    }

    void Update()
    {

        CheckIfPokemonAlive();

    }

    //display 
    private void Display()
    {
        Debug.Log("Pokemon name is " + PokemonName);
        Debug.Log("Pokemon type is " + pokemonType);
        Debug.Log("Pokemon current life is " + StartingHealth + " points");
        Debug.Log("Pokemon attack is " + Attack + " points");
        Debug.Log("Pokemon defense is " + Defense + " points");
        Debug.Log("Pokemon weight is " + weight + " kg");
        Debug.Log("Pokemon stats is " + stats + " points");
        Debug.Log("Pokemon is weak against types :");
        for(int i=0 ; i<WeaknessesList.Length ; i++) {
            Debug.Log("      - " + WeaknessesList[i]);
        }

        Debug.Log("Pokemon is resistant against types :");
        for(int i=0 ; i<ResistancesList.Length ; i++) {
            Debug.Log("      - " + ResistancesList[i]);
        }
        
    }
    //end display

    //InitCurrentLife
    private void InitCurrentLife()
    {
        currentHealth = StartingHealth;
    }
    //end InitCurrentLifre

    //InitStatsPoints
    private void InitStatsPoints()
    {
        stats = StartingHealth + Attack + Defense;
    }
    //end InitStatesPoints

    //GetAttackDamage
    public int GetAttackDamage()
    {
        Debug.Log("Pokemon have " + Attack + " attack points");
        return Attack;
    }
    //end GetAttackDamage

    //CheckIfPokemonAlive
    public void CheckIfPokemonAlive()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Pokemon is fainted.");
        }
        else
        {
            Debug.Log("Pokemon is still alive.");
        }
    }
    //end CheckIfPokemonAlive

    //TakeDamage
    public void TakeDamage(int damage, PokemonType enemyType)
    {
        if (damage <= 0) {
            return;
        }
        float damageMultiplier = 1.0f;

        foreach (PokemonType weakness in WeaknessesList)
        {
            if (weakness == enemyType)
            {
                damageMultiplier *= 2.0f;
                break;
            }
        }

        foreach (PokemonType resistance in ResistancesList)
        {
            if (resistance == enemyType)
            {
                damageMultiplier *= 0.5f;
                break;
            }
        }

        currentHealth -= (int)actualDamage(damage, damageMultiplier);

        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Pokemon's current health after attack: " + currentHealth);
    }

    private float actualDamage(int damage, float damageMultiplier)
    {
        return damage * damageMultiplier;
    }
    //end TakeDamage
}