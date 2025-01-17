Projet Medilabo qui permet la gestion des patients:
L'organisateur peut mettre à jour la partie administrative des fiches des patients (base de données SQL).
Le praticien peut également, rajouter des notes médicales (base de donnée Mongo DB) et a une estimation du risque diabète selon les mots clés présents dans les notes
Ce projet est en micro services conteneurisés.


Pour le Green Code:
- L'un des facteurs importants à prendre en compte est de bien développer des fonctionnalités qui seront utiles et utilisées par les clients. Dans les projets informatiques, il y a de trop nombreuses fonctionnalités très peu ou pas utilisées et elles peuvent consommer de la mémoire avec des processus en arrière plan ou en stockage même si elles ne sont pas utilisées.
- Utilisation de la norme 3NF, permet d'éviter la redondance des données et limite donc l'usage du stockage et de ses impacts environnementaux.
- Une bonne conception peut permettre de limiter la redondance des calculs: exemple dans le projet lorsque j'ai fait:
   foreach (var regex in facteursDeclencheur)
   {
       bool isFacteurPresent = notesDuPatient.Any(note => regex.IsMatch(note.note));
       if (isFacteurPresent)
       {
           nombreDeclencheurs++;
       }
   }
j'essaie de limiter les calculs en arrêtant la recherche par regex dès qu'une occurrence est trouvée plutôt que d'imbriquer 2 foreach
