const express = require('express');

const app = express();
const port = 8080;

//Ajoutez une route qui renvoie "Hello World!" à la racine de votre serveur




app.listen(port, () => {
    console.log(`Server listening at http://localhost:${port}`);
});