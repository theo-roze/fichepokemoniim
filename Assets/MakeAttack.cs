using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAttack : MonoBehaviour
{
    [SerializeField] private PokemonData pokemonData;
    // Start is called before the first frame update
    void Start()
    {
        pokemonData.TakeDamage(5,PokemonData.PokemonType.Ice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
