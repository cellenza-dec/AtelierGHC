const express = require('express');

const app = express();
const port = 8080;

// Add an Endpoint Hello wich return Hello World ! 




app.listen(port, () => {
    console.log(`Server listening at http://localhost:${port}`);
});