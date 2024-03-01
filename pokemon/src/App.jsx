import logo from './logo.svg';
import './App.css';
import SearchPage from "./pages/SearchPage";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import routes from "./utils/routes";
import PokemonDetailsPage from "./pages/details/PokemonDetailsPage";
import PokemonPage from "./pages/pokemonPage/PokemonPage";

function App() {
    return (
        <div className="App">
            <Routes>
                {
                    routes.map(i =>
                        <Route path={i.path} element={i.component()}/>)
                }
                <Route path={"pokemon/:name"} element={<PokemonDetailsPage/>}/>
                <Route path="test" element={PokemonPage()}/>
            </Routes>
        </div>
    );
}

export default App;
