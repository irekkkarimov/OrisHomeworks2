const PokemonAbilities = () => {
    let abilities = [
        'Overgrow',
        'Chlorophill'
    ]

    return (
        <div className="pokemon-page__abilities">
            <div className="pp__abilities__header">
                <p>Abilities</p>
            </div>
            <div className="pp__abilities__lower">
                {abilities.map(i => <AbilityCard name={i}/>)}
            </div>
        </div>
    )
}

export default PokemonAbilities

const AbilityCard = ({name}) => {

    return (
        <div className="ability-card">
            <div className="ability-card__icon"></div>
            <p>{name}</p>
        </div>
    )
}