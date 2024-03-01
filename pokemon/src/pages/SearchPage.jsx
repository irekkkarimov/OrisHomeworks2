import {useEffect, useState} from "react";
import Card from "../components/Card";
import PokemonNotFound from "../components/PokemonNotFound";


const SearchPage = () => {
    // TODO limit fix
    const searchUrl = "https://pokeapi.co/api/v2/pokemon?limit=20"
    const [search, setSearch] = useState('')
    const [pokemonFirstArray, setPokemonFirstArray] = useState([])
    const [pokemonDetailedArray, setPokemonDetailedArray] = useState([])
    const [nextPokemonUrl, setNextPokemonUrl] = useState('')
    const [isSearching, setIsSearching] = useState(false)
    const [isFound, setIsFound] = useState(false)

    let handleSearch = () => {
        setIsSearching(true)
        setIsFound(pokemonDetailedArray.map(i => i.name.toLowerCase()).includes(search.toLowerCase()));
    }

    useEffect(() => {
        fetch(searchUrl)
            .then(response => response.json())
            .then(json => {
                setPokemonFirstArray(json.results)
                setNextPokemonUrl(json.results[0].url)
                return json.next
            })
    }, []);

    useEffect(() => {
        if (nextPokemonUrl && nextPokemonUrl !== '')
            fetch(nextPokemonUrl)
                .then(i => i.json())
                .then(json => {
                    let currentIndex = pokemonDetailedArray.length
                    let pokemonUrlSplit = nextPokemonUrl.split('/')
                    let pokemonId = pokemonUrlSplit[pokemonUrlSplit.length - 2]
                    let pokemonIdParsed = pokemonId.toString()

                    if (pokemonId < 100)
                        pokemonIdParsed = `0${pokemonId}`
                    if (pokemonId < 10)
                        pokemonIdParsed = `00${pokemonId}`

                    let newPokemonDetailed = {
                        id: pokemonIdParsed,
                        name: pokemonFirstArray[currentIndex].name,
                        types: json.types.map(i => i.type),
                    }

                    if (json.sprites.other.home.front_default)
                        newPokemonDetailed.img = json.sprites.other.home.front_default
                    else
                        newPokemonDetailed.img = json.sprites.other.home.front_default

                    let newPokemonDetailedArray = pokemonDetailedArray
                    newPokemonDetailedArray.push(newPokemonDetailed)
                    setPokemonDetailedArray(newPokemonDetailedArray)

                    let nextPokemon = pokemonFirstArray[currentIndex + 1]
                    if (nextPokemon)
                        setNextPokemonUrl(pokemonFirstArray[currentIndex + 1].url)
                    else setNextPokemonUrl('')
                })

    }, [nextPokemonUrl]);

    return (
        <searchpage className="search-page">
            <div className="search-page__header">
                <img src="/Pokeball.png" className="search-page__header__pokeball"/>
                <div className="search-page__header__wrapper">
                    <div className="search-page__header__text">
                        <h2 className="search-page__header__text">Who are you looking for?</h2>
                    </div>
                    <div className="search-page__header__sb">
                        <img src="/pngegg.png" className="search-page__header__sb__img"/>
                        <input
                            type="text"
                            value={search}
                            className="search-page__header__sb__input"
                            onChange={(e) => {
                                setSearch(e.target.value)
                                setIsSearching(false)
                            }}/>
                        <button
                            className="search-page__header__sb__submit"
                            onClick={handleSearch}>
                            GO
                        </button>
                    </div>
                </div>
            </div>
            {isSearching && !isFound ? <PokemonNotFound/> :
                <div className="search-page__body">
                    {pokemonDetailedArray.map(i => <Card
                        id={i.id}
                        name={i.name}
                        types={i.types}
                        img={i.img}
                        show={isSearching ? i.name.toLowerCase() === search.toLowerCase() : true}/>)}
                </div>}
        </searchpage>
    )
}

export default SearchPage