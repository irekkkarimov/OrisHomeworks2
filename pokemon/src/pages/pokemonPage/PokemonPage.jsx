

const PokemonPage = () => {
    let types = ["Grass", "Poison"]

    return (
        <div className="pokemon-page">
            <div className="pokemon-page__header">

            </div>
            <div className="pokemon-page__body">
                <div className="pokemon-page__hero">
                    <div className="pp__hero__upper">
                        <div className="pp__hero__upper__left">
                            <p className="pp__hero__upper__left__id">
                                #001
                            </p>
                            <div className="pp__hero__upper__left__name__wrapper">
                                <p className="pp__hero__upper__left__name">
                                    Bulbasaur
                                </p>
                            </div>
                        </div>
                        <div className="pp__hero__upper__right">
                            {types.map(i =>
                                <div className="pp__hero__upper__right__option">{i}</div>)}
                        </div>
                    </div>
                </div>
                <div className="pokemon-page__stats">

                </div>
                <div className="pokemon-page__moves">

                </div>
                <div className="pokemon-page__abilities">

                </div>
            </div>
        </div>
    )
}

export default PokemonPage