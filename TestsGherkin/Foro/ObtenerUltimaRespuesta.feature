Feature: ObtenerUltimaRespuesta
	Para obtener la ultima respuesta
	Como usuario
	Quiero obtener la ultima respuesta publicada en una duda

@ObtenerUltimaRespuesta
Scenario: Obtener la última respuesta de una duda
	Given Tengo una duda con respuesta
	When Obtengo la ultima respuesta
	Then Obtengo la ultima respuesta de la duda

@ObtenerUltimaRespuesta
Scenario: Obtener la última respuesta de una duda sin respuestas
	Given Tengo una duda sin respuestas
	When Obtengo la ultima respuesta
	Then No obtengo ninguna respuesta