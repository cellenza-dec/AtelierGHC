#uvicorn main:app --host 0.0.0.0 --port 8080

from fastapi import FastAPI
from datetime import date
import re

app = FastAPI()

# Add an Endpoint Hello wich return Hello World ! 
