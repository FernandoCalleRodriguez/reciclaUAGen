Feature: ObtenerNotasInformativas
	Para obtener las notas informativas
	Como usuario
	Quiero obtener una lista de las notas informativas


@ObtenerNotasInformativas
Scenario: Existen notas informativas
	Given Tengo notas informativas
	When Obtengo las notas informativas
	Then Obtengo una lista de las notas informativas
