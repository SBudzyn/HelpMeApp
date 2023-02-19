import React from "react";
import AppRoutes from "./routes/AppRoutes";
import Header from "./components/Header/Header";
import "./styles/pages.css";
import "./styles/App.css";
import Footer from "./components/Footer/Footer";

function App () {
    return (
        <div className="common-background app">
            <Header />
            <AppRoutes />
            <Footer />
        </div>
    );
}

export default App;
