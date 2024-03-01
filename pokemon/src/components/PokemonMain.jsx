import typeColors from "../utils/typeColors";
import {useEffect, useState} from "react";
import statColors from "../utils/statColors";


const PokemonMain = ({name, types, image}) => {

    return (
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
                        <div
                            style={{backgroundColor: typeColors[i.name]}}
                            className="pp__hero__upper__right__option">{i.name}</div>)}
                </div>
            </div>
            <div className="pp__hero__lower">
                <div className="pp__hero__lower__left">
                    <div className="pp__hero__lower__left__stat">
                        <p>HP</p>
                        <StatBar fore={statColors['hp'].foreground} back={statColors['hp'].background}/>
                    </div>
                    <div className="pp__hero__lower__left__stat">
                        <p>Attack</p>
                        <StatBar fore={statColors['attack'].foreground} back={statColors['attack'].background}/>
                    </div>
                    <div className="pp__hero__lower__left__stat">
                        <p>Defense</p>
                        <StatBar fore={statColors['defense'].foreground} back={statColors['defense'].background}/>
                    </div>
                    <div className="pp__hero__lower__left__stat">
                        <p>Speed</p>
                        <StatBar fore={statColors['speed'].foreground} back={statColors['speed'].background}/>
                    </div>
                </div>
                <div className="pp__hero__lower__right">
                    <img src={image} alt=""/>
                </div>
            </div>
        </div>
    )
}

export default PokemonMain

const StatBar = ({fore, back}) => {

    return (
        <div
            style={{backgroundColor: back}}
            className="bar">
            <div
                style={{backgroundColor: fore}}
                className="bar-filled">
            </div>
        </div>
    )
}