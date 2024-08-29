#!/bin/bash

#permet de créer un certificat de développement SSL pour une application web ASP.NET Core
#Une fois créé, ce certificat pourra être utilisé pour configurer le serveur web intégré (Kestrel) 
#pour prendre en charge les connexions HTTPS lors de l'exécution de l'application web ASP.NET Core.
echo "Generating dev cert..."
dotnet dev-certs https -ep aspnetapp.pfx -p 12345678
echo "Done."
echo "Trusting dev cert..."
dotnet dev-certs https --trust
echo "Done."
