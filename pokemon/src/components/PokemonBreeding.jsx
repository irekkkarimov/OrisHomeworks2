const PokemonBreeding = () => {


    return (
        <div className="pokemon-page__breeding">
            <div className="pp__breeding__header">
                <p>Breeding</p>
            </div>
            <div className="pp__breeding__lower">
                <div className="pp__breeding__lower__stat">
                    <p>Height</p>
                    <StatCard/>
                </div>
                <div className="pp__breeding__lower__stat">
                    <p>Weight</p>
                    <StatCard/>
                </div>
            </div>
        </div>
    )
}

export default PokemonBreeding


const StatCard = () => {

    return (
        <div className="stat-card">
            <p className="stat-card__first">2'04</p>
            <p className="stat-card__second">0.7m</p>
        </div>
    )
}