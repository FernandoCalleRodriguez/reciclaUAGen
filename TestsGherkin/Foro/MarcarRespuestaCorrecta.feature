Feature: MarcarRespuestaCorrecta
	Para marcar una respuesta como correcta
	Como usuario
	Quiero cambiar el estado de la respuesta a correcta

@MarcarRespuestaCorrecta
Scenario: Marcar como correcta una respuesta no correcta
	Given Tengo una respuesta no correcta
	When Marco la respuesta como correcta
	Then La respuesta es correcta

@MarcarRespuestaCorrecta
Scenario: Marcar como correcta una respuesta correcta
	Given Tengo una respuesta correcta
	When Marco la respuesta como correcta
	Then La respuesta no se puede marcar como correcta