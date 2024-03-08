import {useCallback, useEffect, useState} from "react";
import Card from "../components/Card";
import PokemonNotFound from "../components/PokemonNotFound";
import pokeball from "../assets/Pokeball.png";
import searchIcon from "../assets/pngegg.png";
import loadPokemonsByFilter from "../utils/loadPokemonsByFilter";


const SearchPage = () => {
    const [filter, setFilter] = useState('')
    const [pokemonList, setPokemonList] = useState([])
    const [isSearching, setIsSearching] = useState(false)
    const [isFound, setIsFound] = useState(false)
    const [currentLimit, setCurrentLimit] = useState(70)
    const [pokemonsLoaded, setPokemonsLoaded] = useState(0)
    const [fetching, setFetching] = useState(true)

    let handleSearch = () => {
        document.removeEventListener('scroll', scrollHandler)
        setIsSearching(true)
    }

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)
        return function () {
            document.removeEventListener('scroll', scrollHandler)
        }
    }, []);

    useEffect(() => {
        if (pokemonList.length > 0) {
            setPokemonList([])
            setFetching(true)
        }
    }, [isSearching]);

    useEffect(() => {
        console.log(fetching)
        if (fetching) {
            if (isSearching) {
                loadPokemonsByFilter(0, 0, filter)
                    .then(data => {
                        if (data.length > 0)
                            setIsFound(true)
                        setPokemonList(prev => [...prev, ...data])
                        setCurrentLimit(70)
                        setPokemonsLoaded(0)
                        setFetching(false)
                    })
            } else {
                loadPokemonsByFilter(currentLimit, pokemonsLoaded)
                    .then(data => {
                        setPokemonList(prev => [...prev, ...data])
                        setCurrentLimit(20)
                        console.log(pokemonsLoaded + data.length)
                        setPokemonsLoaded(prev => prev + data.length)
                        setFetching(false)
                        document.addEventListener('scroll', scrollHandler)
                        console.log('added')
                    })
            }
        }

    }, [fetching]);

    const scrollHandler = useCallback((e) => {
        console.log(1)
        if ((e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 200) && !isSearching && pokemonList.length < 1302) {
            document.removeEventListener('scroll', scrollHandler)
            setFetching(true)
        }
    }, [])

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
                                setIsFound(false)
                                document.addEventListener('scroll', scrollHandler)
                            }}/>
                        <button
                            className="search-page__header__sb__submit"
                            onClick={handleSearch}>
                            GO
                        </button>
                    </div>
                </div>
            </div>
            {isSearching && !isFound
                ? <PokemonNotFound/>
                : <div className="search-page__body">
                    {pokemonList.map(i => <Card
                        id={i.id}
                        name={i.name}
                        types={i.types}
                        img={i.sprites.other.home.front_Default}/>)}
                </div>}
        </searchpage>
    )
}

export default SearchPage