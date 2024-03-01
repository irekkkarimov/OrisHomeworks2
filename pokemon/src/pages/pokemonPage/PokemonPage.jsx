import PokemonMain from "../../components/PokemonMain";
import "./PokemonPage.css"
import {useEffect, useState} from "react";
import PokemonBreeding from "../../components/PokemonBreeding";
import PokemonMoves from "../../components/PokemonMoves";
import PokemonAbilities from "../../components/PokemonAbilities";


const PokemonPage = () => {
    const [pokemon, setPokemon] = useState({
        name: '',
        sprites:
            {
                other:
                    {
                        home:
                            {front_default: ''}
                    }
            }
    })
    const [types, setTypes] = useState([])

    useEffect(() => {
        fetch('https://pokeapi.co/api/v2/pokemon/1/')
            .then(response => response.json())
            .then(json => {
                console.log(json)
                setPokemon(json)
                setTypes(json.types.map(i => i.type))
            })
    }, []);

    return (
        <div className="pokemon-page">
            <div className="pokemon-page__header">

            </div>
            <div className="pokemon-page__body">
                <PokemonMain
                    name={pokemon.name}
                    types={types}
                    image={pokemon.sprites.other.home.front_default}/>
                <PokemonBreeding/>
                <PokemonMoves/>
                <PokemonAbilities/>
            </div>
        </div>
    )
}

export default PokemonPage