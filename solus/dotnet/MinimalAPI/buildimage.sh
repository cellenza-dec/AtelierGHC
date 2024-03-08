#!/bin/bash

# Construire l'image Docker
docker build -t minimumapi .

# Démarrer un conteneur à partir de l'image
docker run -d -p 8080:8080 minimumapi