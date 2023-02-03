import React from "react";
import AppRoutes from "./routes/AppRoutes";
import Header from "./components/Header/Header";

function App () {
    return (
        <div>
            <Header />
            <AppRoutes />
        </div>
    );
}

export default App;
