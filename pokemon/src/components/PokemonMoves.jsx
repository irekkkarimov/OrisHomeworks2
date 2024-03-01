const PokemonMoves = () => {
    let names = [
        'Seed Bomb',
        'Sludge Bomb',
        'Power Whip',
        'Frustration',
        'Return',
        'Vine Whip'
    ]

    return (
        <div className="pokemon-page__moves">
            <div className="pp__moves__header">
                <p>Moves</p>
            </div>
            <div className="pp__moves__lower">
                {names.map(i => <PokemonMoveCard name={i}/>)}
            </div>
        </div>
    )
}

export default PokemonMoves

const PokemonMoveCard = ({name}) => {

    return (
        <div className="pokemon-move-card">
            <div className="pokemon-move-card__icon"></div>
            <p>{name}</p>
        </div>
    )
}