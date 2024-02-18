import {useEffect, useState} from "react";
import Card from "../components/Card";


const SearchPage = () => {
    const [search, setSearch] = useState('')
    const [pokemonArray, setPokemonArray] = useState([])
    const [isSearching, setIsSearching] = useState(false)
    let pokemonArrayMapped = []
    if (pokemonArray.length > 0)
        pokemonArrayMapped = pokemonArray.map(i =>
            <Card pokemon={i} show={isSearching ? i.name === search : true}/>)

    let handleSearch = () => {
        setIsSearching(true)
    }

    useEffect(() => {
        fetch("https://pokeapi.co/api/v2/pokemon")
            .then(response => response.json())
            .then(json => setPokemonArray(json.results))
    }, []);


    return (
        <searchpage className="search-page">
            <div className="search-page__header">
                <div className="search-page__header__text">
                    <h2 className="search-page__header__text_h2">Who are you looking for?</h2>
                </div>
                <div className="search-page__header__sb">
                    <img src="src" className="search-page__header__sb__img"/>
                    <input
                        type="text"
                        value={search}
                        className="search-page__header__sb__input"
                        onChange={(e) => {
                            setSearch(e.target.value)
                            setIsSearching(false)
                        }}/>
                    <button
                        className="search_page__header__sb__submit"
                        onClick={handleSearch}>
                        GO
                    </button>
                </div>
            </div>
            <div className="search-page__body">
                {pokemonArrayMapped}
            </div>
        </searchpage>
    )
}

export default SearchPage