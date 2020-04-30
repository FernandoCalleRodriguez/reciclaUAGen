Feature: ObtenerSiRespuestaCorrecta
	Para obtener si una duda tiene respuesta correcta
	Como usuario
	Quiero obtener verdadero si la duda tiene una respuesta correcta

@ObtenerSiRespuestaCorrecta
Scenario: Obtener si respuesta correcta en una duda
	Given Tengo una duda con respuesta correcta
	When Obtengo si respuesta correcta
	Then Obtengo respuesta correcta como verdadero

@ObtenerSiRespuestaCorrecta
Scenario: Obtener si respuesta correcta en una duda sin respuesta correcta
	Given Tengo una duda sin respuesta correcta
	When Obtengo si respuesta correcta
	Then Obtengo respuesta correcta como falso