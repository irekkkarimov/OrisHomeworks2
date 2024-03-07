import {useEffect, useState} from "react";
import Card from "../components/Card";
import PokemonNotFound from "../components/PokemonNotFound";
import pokeball from "../assets/Pokeball.png";
import searchIcon from "../assets/pngegg.png";
import load from "../utils/loadPokemonsDetailed";


const SearchPage = () => {
    const searchUrl = "https://pokeapi.co/api/v2/pokemon?"
    const [filter, setFilter] = useState('')
    const [pokemonFirstArray, setPokemonFirstArray] = useState([])
    const [pokemonDetailedArray, setPokemonDetailedArray] = useState([])
    const [nextPokemonUrl, setNextPokemonUrl] = useState('')
    const [isSearching, setIsSearching] = useState(false)
    const [isFound, setIsFound] = useState(false)
    const [currentLimit, setCurrentLimit] = useState(50)
    const [currentOffset, setCurrentOffset] = useState(0)
    const [fetching, setFetching] = useState(true)

    let handleSearch = () => {
        setIsSearching(true)
        setIsFound(pokemonDetailedArray.map(i => i.name.toLowerCase()).includes(filter.toLowerCase()));
    }

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)
        return function () {
            document.removeEventListener('scroll', scrollHandler)
        }
    }, []);

    useEffect(() => {
        if (fetching) {
            fetch(searchUrl + `limit=${currentLimit}` + `&offset=${currentOffset}`)
                .then(response => response.json())
                .then(json => {
                    setPokemonFirstArray([...pokemonFirstArray, ...json.results])
                    setNextPokemonUrl(json.results[0].url)
                    setCurrentOffset(prev => prev + currentLimit)
                    setCurrentLimit(20)
                    return json.next
                })
                .finally(() => setFetching(false))
        }
    }, [fetching]);

    useEffect(() => {
            let newPokemons = pokemonFirstArray.slice(pokemonDetailedArray.length)
            let newPokemonsLoaded = load(newPokemons.map(i => i.url))
                .then(response => {
                    setPokemonDetailedArray(prev => [...prev, ...response])
                    document.addEventListener('scroll', scrollHandler)
                })

        }, [pokemonFirstArray.length]
    )
    ;

    const scrollHandler = (e) => {
        console.log(1)
        if ((e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 100) && pokemonFirstArray.length < 1302) {
            setFetching(true)
            console.log(2)
            document.removeEventListener('scroll', scrollHandler)
        }
    }

    return (
        <searchpage className="search-page">
            <div className="search-page__header">
                <img src={pokeball} alt="Pokeball" className="search-page__header__pokeball"/>
                <div className="search-page__header__wrapper">
                    <div className="search-page__header__text">
                        <h2 className="search-page__header__text">Who are you looking for?</h2>
                    </div>
                    <div className="search-page__header__sb">
                        <img src={searchIcon} alt="Search Icon" className="search-page__header__sb__img"/>
                        <input
                            type="text"
                            value={filter}
                            className="search-page__header__sb__input"
                            onChange={(e) => {
                                setFilter(e.target.value)
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
                        show={isSearching ? i.name.toLowerCase() === filter.toLowerCase() : true}/>)}
                </div>}
        </searchpage>
    )
}

export default SearchPage