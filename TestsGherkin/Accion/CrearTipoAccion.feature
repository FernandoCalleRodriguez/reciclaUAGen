Feature: CrearTipoAccion
	Para crear un nuevo tipo de accion
	Como usuario
	Quiero crear un nuevo tipo de accion

@CrearNuevoTipoAccion
Scenario: Crear un nuevo tipo de accion
	Given Quiero crear un nuevo tipo de accion con estas caracteristicas
		| puntuacion         | nombre      |
		| 100 | Accion doble |
	When Creo el nuevo tipo de accion
	Then Obtengo el nuevo tipo de accion
