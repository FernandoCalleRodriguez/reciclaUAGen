Feature: obtenerUsuarioPorEmail
	Para buscar el usuario por el email
	Como usuario
	Quiero obtener el usuario con ese email

@mytag
Scenario: Test obtenerUsuarioPorEmail
	Given Hay un usuario con email "usu1@ua.es"
	When Busco el usuario por ese email
	Then Devuelvo el ususario