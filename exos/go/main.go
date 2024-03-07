// Comment créer une API web en Go avec le framework Gin
// https://www.thepolyglotdeveloper.com/2017/07/create-api-web-go-framework-gin/

package main

import (
	"github.com/gin-gonic/gin"
)

func main() {
	router := gin.Default()
	// Ajoutez un endpoint Hello World à votre API web

	router.Run(":8080")
}
