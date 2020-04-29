Feature: ValidarItem
	Para validar un item
	Como usuario
	Quiero cambiar el estado del item a validado

@ValidarItem
Scenario: Validar un item sin validar
	Given Tengo un item sin validar
	When Valido el item
	Then El item es validado

@ValidarItem
Scenario: Validar un item validado
	Given Tengo un item validado
	When Valido el item
	Then No se puede validar el item

@ValidarItem
Scenario: Validar un item descartado
	Given Tengo un item descartado
	When Valido el item
	Then No se puede validar el item