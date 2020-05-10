Feature: ModificarNotaInformativa
	Para modificiar una nota informativa
	Como usuario admin
	Quiero cambiar el contenido de la nota informativa

@ModificarNotaInformativaExistente
Scenario: Modificar una nota informativa existente
	Given Quiero modificar una nota informativa con la siguiente informacion
		| titulo         | cuerpo      |
		| Titulo de nota informativa modificada | Cuerpo de nota informativa modificada |
	When Modifico la nota informativa
	Then Obtengo la nueva nota informativa modificada

@ModificarNotaInformativaNoExistente
Scenario: Modificar una nota informativa no existente
	Given Quiero modificar una nota informativa no existente con la siguiente informacion
		| titulo         | cuerpo      |
		| Titulo de nota informativa modificada | Cuerpo de nota informativa modificada |
	When Modifico la nota informativa
	Then No se puede modificar la nota informativa
