Feature: DeleteNivel
	Para borrar un nivel
	Como usuario
	Quiero borrar el nivel

@DeleteNivelExists
Scenario: Borrar nivel existente
	Given Hay un nivel con un id especifico
	When Elimino El nivel
	Then Se borra el nivel

	
@DeleteNivelDoesntExists
Scenario: Borrar nivel no existente
	Given No ay un nivel con un id especifico
	When Elimino El nivel
	Then no se borra el nivel