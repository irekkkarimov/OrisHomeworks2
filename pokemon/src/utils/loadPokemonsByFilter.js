const loadPokemonsByFilter = async (limit, offset, filter = '') => {
    console.log(3)
    console.log(process.env.REACT_APP_API_URL)
    console.log(limit)
    console.log(offset)
    if (filter === '')
        return await fetch(process.env.REACT_APP_API_URL + 'Pokemon/GetAll?' + new URLSearchParams({
            limit, offset
        }))
            .then(response => response.json())
            .then(json => json.results)

    return await fetch(process.env.REACT_APP_API_URL + `Pokemon/GetByFilter/${filter}`)
        .then(response => response.json())
        .then(json => json.results)
}

export default loadPokemonsByFilter