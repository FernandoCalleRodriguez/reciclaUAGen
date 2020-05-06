Feature: DeleteEdificio
	Para borrar un Edificio
	Como usuario
	Quiero borrar el Edificio

@DeleteEdificioExists
Scenario: Borrar Edificio existente
	Given Hay un Edificio con un id especifico
	When Elimino El Edificio
	Then Se borra el Edificio

	
@DeleteEdificioDoesntExists
Scenario: Borrar Edificio no existente
	Given No hay un Edificio con un id especifico
	When  Entento elimino El Edificio
	Then  no se borra el Edificio