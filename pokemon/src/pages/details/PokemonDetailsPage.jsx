import typeColors from "../../utils/typeColors";
import {useEffect, useState} from "react";
import {useParams} from "react-router-dom";


const PokemonDetailsPage = () => {
    const [pokemon, setPokemon] = useState({})
    const [isLoaded, setIsLoaded] = useState(false)
    const pokemonData = useParams()
    let typesJustifyContent = "start"
    let placeHolder = "https://www.picclickimg.com/gTsAAOSwoUBfoJx6/Pokemon-placeholder-special-listing-to-be-updated.webp"
    let requestUrl = `https://pokeapi.co/api/v2/pokemon/${pokemonData.name}`
    if (isLoaded)
        typesJustifyContent = pokemon.types.length > 1 ? "space-between" : "start"

    useEffect(() => {
        fetch(requestUrl)
            .then(i => i.json())
            .then(json => {
                let pokemonIdParsed = json.id.toString()
                if (json.id < 100)
                    pokemonIdParsed = `0${json.id}`
                if (json.id < 10)
                    pokemonIdParsed = `00${json.id}`


                let newPokemon = {
                    id: pokemonIdParsed,
                    name: json.forms[0].name,
                    types: json.types.map(i => i.type)
                }

                if (json.sprites.other.home.front_default)
                    newPokemon.img = json.sprites.other.home.front_default
                else
                    newPokemon.img = json.sprites.other.home.front_default

                setPokemon(newPokemon)
                setIsLoaded(true)
            })
    }, []);

    return (
        isLoaded && <div className='card' onClick={() => alert("Hello")}>
            <div className="card__upper">
                <div className="card__upper__wrapper">
                    <p className='card__upper__name'>
                        {pokemon.name}
                    </p>
                    <p className="card__upper__id">
                        #{pokemon.id}
                    </p>
                </div>
            </div>
            <div className="card__pic"><img
                src={pokemon.img ? pokemon.img : placeHolder}
                alt={pokemon.name}
                className="card__pic"/>
            </div>
            <div className="card__lower" style={{justifyContent: typesJustifyContent}}>
                {pokemon.types.map(i => {
                    return (
                        <div className="card__lower__option"
                             style={{backgroundColor: typeColors[i.name]}}>
                            <p>{i.name}</p>
                        </div>
                    )
                })}
            </div>
        </div>
    )
}

export default PokemonDetailsPage