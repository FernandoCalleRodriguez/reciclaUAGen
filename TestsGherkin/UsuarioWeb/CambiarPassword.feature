Feature: CambiarPassword
	Para cambiar la contraseña
	Como usuario web
	Quiero obtener el usuario con la nueva contraseña

@Cambiarpassword
Scenario: Cambiar contraseña existe usuario 
	Given Hay un usuario con id 32769
	When Cambiar la contraseña del usuario
	And Obtener el usuario
	Then obtengo el usuario con la nueva contrasena

@Cambiarpassword
Scenario: Cambiar contraseña no existe usuario 
	Given No existe el web  usuario -1
	When Cambiar la contraseña del usuario
	And Obtener el usuario
	Then No se puede obtener el usuario