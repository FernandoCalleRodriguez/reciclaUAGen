Feature: BorrarNotaInformativa
	Para borrar una nota informativa
	Como usuario admin 
	Quiero borrar la nota informativa

@BorrarNotaInformativa
Scenario: Borrar nota informativa existente
	Given Hay una nota informativa especifica
	When Elimino la nota informativa
	Then Devuelvo la nota informativa borrada

@BorrarNotaInformativaNoExistente
Scenario: Borrar nota informativa no existente
	Given No existe la nota informativa especifica
	When Elimino la nota informativa
	Then No se puede borrar la nota informativa
