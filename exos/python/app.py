# je voudrais démarrer ave une api en python que dois-je faire ?

from fastapi import FastAPI


app = FastAPI()

@app.get("/hello")
def read_root():
    return {"Bonjour": "le monde (en python)"}

# pip install fastapi ou
# pip install -r requirement.txt
# uvicorn app:app --reload
