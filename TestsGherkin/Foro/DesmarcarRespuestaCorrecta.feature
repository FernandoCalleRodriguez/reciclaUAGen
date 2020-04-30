Feature: DesmarcarRespuestaCorrecta
	Para desmarcar una respuesta como correcta
	Como usuario
	Quiero cambiar el estado de la respuesta a no correcta

@DesmarcarRespuestaCorrecta
Scenario: Desmarcar como correcta una respuesta correcta
	Given Tengo una respuesta ya correcta
	When Desmarco la respuesta como correcta
	Then La respuesta es no correcta

@DesmarcarRespuestaCorrecta
Scenario: Desmarcar como correcta una respuesta no correcta
	Given Tengo una respuesta incorrecta
	When Desmarco la respuesta como correcta
	Then La respuesta no se puede desmarcar como correcta