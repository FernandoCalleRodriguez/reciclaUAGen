Feature: DeleteContenedor
	Para borrar un Contenedor
	Como usuario
	Quiero borrar el Contenedor

@DeleteContenedorExists
Scenario: Borrar Contenedor existente
	Given Hay un Contenedor con un id especifico
	When Elimino El Contenedor
	Then Se borra el Contenedor

	
@DeleteContenedorDoesntExists
Scenario: Borrar Contenedor no existente
	Given No hay un Contenedor con un id especifico
	When  Entento elimino El Contenedor
	Then  no se borra el Contenedor