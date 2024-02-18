import {useEffect, useState} from "react";


const Card = ({pokemon, show}) => {
    const [types, setTypes] = useState([])
    let pokemonUrlSplit = pokemon.url.split('/')
    let pokemonId = pokemonUrlSplit[pokemonUrlSplit.length - 2]

    useEffect(() => {
        fetch(pokemon.url)
            .then(response => response.json())
            .then(json => setTypes(json.types.map(i => i.type)))
    }, []);

    // test
    let catImg = "https://hips.hearstapps.com/hmg-prod/images/cute-cat-photos-1593441022.jpg"

    return (
        show && <div className='card' style={{width: "100px"}}>
            <div className="card__upper">
                <p className='card__upper__name'>
                    {pokemon.name}
                </p>
                <p className="card__upper__id">
                    #{pokemonId}
                </p>
            </div>
            <div className="card__pic">
                <img
                    src={catImg}
                    alt={pokemon.name}
                    className="card__pic__"
                    style={{width: "100px"}}/>
            </div>
            <div className="card__lower">
                {types.map(i => {
                    return (
                        <div className="card__lower__option"
                             style={{backgroundColor: "#FFF"}}
                        >
                            <p>{i.name}</p>
                        </div>
                    )
                })}
            </div>
        </div>
    )
}

export default Card