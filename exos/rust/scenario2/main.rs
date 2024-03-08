use actix_web::{get, App, HttpResponse, HttpServer, Responder};

// Add an Endpoint Hello wich return Hello World ! 


#[actix_web::main]
async fn main() -> std::io::Result<()> {
    HttpServer::new(|| {
        App::new().service(hello)
    })
    .bind("127.0.0.1:8080")?
    .run()
    .await
}


