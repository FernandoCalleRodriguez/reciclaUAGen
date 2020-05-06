Feature: BorrarAccionWeb
	Para borrar una accion web
	Como usuario 
	Quiero borrar la accion web

@BorrarAccionWeb
Scenario: Borrar accion web existente
	Given Hay un accion web especifica
	When Elimina la accion web
	Then Devuelvo la accion web borrada

@BorrarAccionWebNoExistente
Scenario: Borrar accion wen no existente
	Given No hay un accion web especifica
	When Elimina la accion web
	Then No se puede borrar la accion web
