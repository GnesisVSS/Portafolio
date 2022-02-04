from django.urls import path
from .views import *

urlpatterns = [
    path('',home, name="home"),
    #path('login_acceso/',login_acceso,name='LOGINACCESO'),
    path('clientePerfil/',clientePerfil,name='clientePerfil'),
    path('profesionalPerfil/',profesionalPerfil,name='profesionalPerfil'),
    path('cerrar_sesion/',cerrar_sesion,name='CERRARSESION'),
    path('LoginWS/',LoginWS,name='LoginWS'),
    path('LoginWSCli/',LoginWSCli,name='LoginWSCli'),
    path('asesoriasprof/',asesoriasProf,name='asesoriasProf'),
    #path('FormularioContacto/',FormularioContacto,name='FormularioContacto'),
    path('datosprf/',datosprf,name="datosprf"),
    path('solicitarAsesoria/',solicitarAsesoria,name='solicitarAsesoria'),
    #path('guardar-token/',guardar_token,name='guardar-token'),
    path('reportarAccidente/',reportarAccidente,name='reportarAccidente'),
    path('formularioContacto/',formularioContacto,name='formularioContacto'),
    path('actualizarchecklistprof/',actualizarchecklistprof,name='actualizarchecklistprof'),
]
