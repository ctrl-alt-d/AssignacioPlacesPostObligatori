# Assignació Places Post Obligatori

Database Dockerized Sample Data

## Origen de les dades:

>[Estadística de l'assignació de places en el procés de la preinscripció en els ensenyaments post-obligatoris
Educació](https://analisi.transparenciacatalunya.cat/Educaci-/Estad-stica-de-l-assignaci-de-places-en-el-proc-s-/wjaf-jxmt/about_data)
>
>Estadística de l’assignació de places en el procés de la Preinscripció en els ensenyaments post-obligatoris: oferta inicial, oferta efectiva, assignacions total, en primera i resta de peticions, a nivell de centre educatiu.


## Actualitzar les dades

Les dades són a `./Data`, pot ser que estiguin desactualitzades, es poden actualitzar des del portal de [Transparencia Catalunya](https://analisi.transparenciacatalunya.cat/Educaci-/Estad-stica-de-l-assignaci-de-places-en-el-proc-s-/wjaf-jxmt/about_data)

## Descripció de les columnes / Column Descriptions

| Nom de columna (CAT) | Column Name (ENG) | Descripció (CAT) | Description (ENG) | Nom de camp API | Tipus de dades |
|----------------------|-------------------|------------------|-------------------|-----------------|----------------|
| Curs | Course | Curs de referència | Reference course | curs | Text |
| Any | Year | Any del curs inferior | Year of the lower course | any | Text |
| Codi centre | Center Code | Codi de centre educatiu. Identificació única de centre. Camp recomanat per al tractament de dades | Educational center code. Unique center identification. Recommended field for data processing | codi_centre | Text |
| Denominació completa | Full Name | Nom complet del centre educatiu | Full name of the educational center | denominaci_completa | Text |
| Codi naturalesa | Nature Code | Codi naturalesa Públic/Privat | Public/Private nature code | codi_naturalesa | Text |
| Nom naturalesa | Nature Name | Públic/privat | Public/private | nom_naturalesa | Text |
| Codi titularitat | Ownership Code | Codi de la titularitat de la propietat del centre educatiu | Code of the ownership of the educational center | codi_titularitat | Text |
| Nom titularitat | Ownership Name | Titularitat de la propietat del centre educatiu | Ownership of the educational center | nom_titularitat | Text |
| Codi Àrea Territorial | Territorial Area Code | Codi de l'Àrea Territorial del centre docent | Code of the Territorial Area of the teaching center | codi_delegaci | Text |
| Nom Àrea Territorial | Territorial Area Name | Àrea Territorial | Territorial Area | nom_delegaci | Text |
| Codi comarca | County Code | Codi comarca del centre docent | County code of the teaching center | codi_comarca | Text |
| Nom comarca | County Name | Nom comarca del centre docent | County name of the teaching center | nom_comarca | Text |
| Codi municipi_5 | Municipality Code_5 | Codificació del municipi a 5 dígits | Municipality coding with 5 digits | codi_municipi_5 | Text |
| Codi municipi_6 | Municipality Code_6 | Codificació del municipi a 6 dígits | Municipality coding with 6 digits | codi_municipi_6 | Text |
| Nom municipi | Municipality Name | Nom del municipi del centre educatiu | Name of the municipality of the educational center | nom_municipi | Text |
| Coordenades UTM X | UTM Coordinates X | ETRS89 | ETRS89 | coordenades_utm_x | Nombre |
| Coordenades UTM Y | UTM Coordinates Y | ETRS89 | ETRS89 | coordenades_utm_y | Nombre |
| Longitud | Longitude | WGS84 | WGS84 | longitud | Nombre |
| Latitud | Latitude | WGS84 | WGS84 | latitud | Nombre |
| Convocatòria | Call | Convocatòria de la preinscripció | Pre-registration call | convocatoria | Text |
| Nom ensenyament | Education Name | Nom de l'ensenyament | Name of the education | nom_ensenyament | Text |
| Règim | Regime | Diürn/Nocturn | Daytime/Nighttime | r_gim | Text |
| Torn | Shift | Matí/matí i tarda/tarda/vespre | Morning/morning and afternoon/afternoon/evening | torn | Text |
| Nivell | Level | Nivell | Level | nivell | Nombre |
| Nombre grups | Number of Groups | Nombre de grups | Number of groups | nombre_grups | Nombre |
| Nombre places | Number of Places | Nombre de places | Number of places | nombre_places | Nombre |
| Places ofertades a la preinscripció | Places Offered in Pre-registration | Places ofertades en el procés de preinscripció | Places offered in the pre-registration process | places_ofertades_a_la | Nombre |
| Assignacions | Assignments | Nombre d'assignacions total | Total number of assignments | assignacions | Nombre |
| Assignacions: 1a petició | Assignments: 1st Request | Nombre d'assignacions en primera petició | Number of assignments in first request | assginacions_1a_peticio | Nombre |
| Assignacions: altres peticions | Assignments: Other Requests | Nombre d'assignacions en la resta de peticions | Number of assignments in the rest of requests | assignacions_altres_peticions | Nombre |
| Places ofertades a la preinscripció (2a volta) | Places Offered in Pre-registration (2nd Round) | Places ofertades en el procés de preinscripció (2a volta) | Places offered in the pre-registration process (2nd round) | places_ofertades_a_la_preinscripci_2a_volta_ | Nombre |
| Assignacions (2a volta) | Assignments (2nd Round) | Assignacions (2a volta) | Assignments (2nd round) | assignacions_2a_volta_ | Nombre |
| Assignacions 1a petició (2a volta) | Assignments 1st Request (2nd Round) | Assignacions en primera petició (2a volta) | Assignments in first request (2nd round) | assignacions_1a_petici_2a_volta_ | Nombre |
| Assignacions altres peticions (2a volta) | Assignments Other Requests (2nd Round) | Assignacions en altres peticions (2a volta) | Assignments in other requests (2nd round) | assignacions_altres_peticions_2a_volta_ | Nombre |
| Georeferenciació | Georeferencing | Georeferenciació | Georeferencing | georeferenciaci_ | Punt |


