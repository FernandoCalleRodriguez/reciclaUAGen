Feature: CrearNotaInformativa
	Para crear una nueva nota informativa
	Como usuario admin 
	Quiero crear una nota informativa

@CrearNuevaNotaInformativa
Scenario: Crear una nueva nota informativa
	Given Quiero crear una nueva nota informativa que contenga
		| titulo         | cuerpo      |
		| Titulo de nota informativa | Cuerpo de nota informativa |
	When Creo la nota informativa
	Then Obtengo la nueva nota informativa