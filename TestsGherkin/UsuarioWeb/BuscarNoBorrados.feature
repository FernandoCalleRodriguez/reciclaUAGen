Feature: BuscarNoBorrados
	Para buscar los usuarios no borrados
	Como usuario
	Quiero todos los usuarios no borrados

@BuscarNoBorrados
Scenario: Obtner usuarios no borrados
	Given Existen usuarios no borrados
	When Obtengo los usuarios no borrados
	Then Devuelvo el los usuario no borrados
