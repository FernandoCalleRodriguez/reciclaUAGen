Feature: ValidarPunto
	Para validar un punto
	Como usuario
	Quiero cambiar el estado del punto a validado

Scenario: Validar un punto sin validar
	Given Tengo un punto sin validar
	When Valido el punto
	Then El punto es validado

Scenario: Validar un punto validado
	Given Tengo un punto validado
	When Valido el punto
	Then No se puede validar el punto

Scenario: Validar un punto descartado
	Given Tengo un punto descartado
	When Valido el punto
	Then No se puede validar el punto