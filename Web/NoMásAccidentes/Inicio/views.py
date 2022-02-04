from typing import Text
from django.db import connection
from django.db.models.expressions import When
from django.shortcuts import redirect, render

import smtplib

from django.contrib.auth.decorators import login_required, permission_required, user_passes_test
from django.contrib.auth.models import User
from django.contrib.auth import authenticate, logout, login as auth_login
from django.utils.translation import to_locale
from zeep import Client

from django.views.decorators.http import require_http_methods
from django.views.decorators.csrf import csrf_exempt
from django.http import HttpResponse, HttpResponseBadRequest
from django.core import serializers
import json

from fcm_django.models import FCMDevice


# Create your views here.

cliente = Client('http://localhost:61887/Service1.svc?wsdl')


#@csrf_exempt
#@require_http_methods(['POST'])
#def guardar_token(request):
#    body = request.body.decode('utf-8')
#    bodyDict = json.loads(body)
#
#   token = bodyDict['token']
#    existe = FCMDevice.objects.filter(registratrion_id = token, active = True)

#    if len(existe) > 0:
#        return HttpResponseBadRequest(json.dumps({'Mensaje':'El Token ya existe'}))


#    dispositivo = FCMDevice()
#    dispositivo.registration_id = token
#    dispositivo.active = True

    #solo si esta autenticado
#    try:
#        dispositivo.save()
#        return HttpResponse(json.dumps({'Mensaje':'Token guardado'}))
#    except:
#        return HttpResponseBadRequest(json.dumps({'Mensaje':'No se ha guardado'}))






def home(request):
    return render(request, 'Inicio/home.html')


def listado_prof(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_datosprof", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_cliente(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_datoscli", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_asesorias(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_asesoriasprof", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_capacitaciones(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_capacitacionesprf", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_visitas(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_visitasprof", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_clientes(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_clientesprf", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def listado_checklist(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_checklistprof", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


@login_required(login_url='/')
def clientePerfil(request):
    return render(request, 'Inicio/clientePerfil.html')


@login_required(login_url='/')
def profesionalPerfil(request):

    return render(request, 'Inicio/profesionalPerfil.html')


def LoginWS(request):
    if request.POST:
        user = request.POST.get("txtuser")
        password = request.POST.get("txtpassword")
        data = {
            'datosprof': listado_prof(in_var=user),
            'asesoriasprof': listado_asesorias(in_var=user),
            'capacitacionesprf': listado_capacitaciones(in_var=user),
            'visitasprof': listado_visitas(in_var=user),
            'checklistprof': listado_checklist(in_var=user)
            # 'clientesprf':listado_clientes(in_var=user)
        }

        if cliente.service.Login(user, password):
            return render(request, "Inicio/profesionalPerfil.html", data)
        else:
            variable = {'msg': 'No existe'}

    return redirect(to='home')


def actualizarchecklistprof(request):
    in_var="11"
    if request.POST:
        com1=request.POST.get("checkComentario1")
        com2=request.POST.get("checkComentario2")
        com3=request.POST.get("checkComentario3")
        comext1=request.POST.get("checkComentarioExt1")
        comext2=request.POST.get("checkComentarioExt2")
        comext3=request.POST.get("checkComentarioExt3")

        django_cursor = connection.cursor()
        cursor = django_cursor.connection.cursor()

        cursor.callproc("sp_actualizarchecklistprof", [in_var,com1,com2,com3,comext1,comext2,comext3])

    return redirect(to='home')


def solicitarAsesoria(request):
    if request.POST:

        rutemp = request.POST.get("asesRutEmpresa")
        nombemp = request.POST.get("asesNombreEmpresa")
        fono = request.POST.get("asesFono")
        mail = request.POST.get("asesEmail")
        subject="Solicita Asesoria - Gestion NMA"


        #CONEXION
        message = ('subject: {}\n\n{}'.format(subject,'Se ha solicitado una asesoria para el cliente:\n \tRUT Empresa: '+rutemp+'\n \tNombre Empresa: '+nombemp+'\n \tTelefono: '+fono+ '\n \tEmail: '+ mail, Text))
        server = smtplib.SMTP('smtp.gmail.com',587)
        server.starttls()
        server.login('ilianjimex@gmail.com','Venomsnake99')
        server.sendmail('ilianjimex@gmail.com','karenlvergara@gmail.com',message)
        server.quit()

        
    return redirect(to='home')


def reportarAccidente(request):
    if request.POST:
        rutemp=request.POST.get("reporteRutEmpresa")
        nombemp=request.POST.get("reporteNombreEmpresa")
        fono= request.POST.get("reporteFono")
        mail=request.POST.get("reporteEmail")
        desc=request.POST.get("reporteDescAccidente")
        subject="Notificacion Accidente - Gestion NMA"

        #CONEXION
        message = ('subject: {}\n\n{}'.format(subject,'Se ha reportado un accidente de parte del cliente:\n \tRUT Empresa: '+rutemp+'\n \tNombre Empresa: '+nombemp+'\n \tTelefono: '+fono+'\n \tEmail: '+ mail+'\n \tDescripcion del accidente: '+desc+'\n \n SE SOLICITA CONTACTAR A LA BREVEDAD', Text))
        server = smtplib.SMTP('smtp.gmail.com',587)
        server.starttls()
        server.login('ilianjimex@gmail.com','Venomsnake99')
        server.sendmail('ilianjimex@gmail.com','karenlvergara@gmail.com',message)
        server.quit()

    return redirect(to='home')


def formularioContacto(request):
    if request.POST:
        nombre=request.POST.get("contactoNombre")
        mail=request.POST.get("contactoEmail")
        fono=request.POST.get("contactoFono")
        empresa=request.POST.get("contactoEmpresa")
        mensaje=request.POST.get("contactoMensaje")
        subject="Solicitud Contacto - Gestion NMA"

        #CONEXION
        message = ('subject: {}\n\n{}'.format(subject,'Se ha generado una solicitud de contacto para:\n \tNombre: '+nombre+'\n \tEmail: '+mail+'\n \tTelefono: '+fono+'\n \tEmpresa: '+ empresa+'\n \tMensaje: '+mensaje, Text))
        server = smtplib.SMTP('smtp.gmail.com',587)
        server.starttls()
        server.login('ilianjimex@gmail.com','Venomsnake99')
        server.sendmail('ilianjimex@gmail.com','karenlvergara@gmail.com',message)
        server.quit()

    return redirect(to='home')



def listado_contratos(in_var):
    django_cursor = connection.cursor()
    cursor = django_cursor.connection.cursor()
    out_cur = django_cursor.connection.cursor()

    cursor.callproc("sp_contratoscli", [out_cur, in_var])
    lista = []
    for fila in out_cur:
        lista.append(fila)
    return lista


def LoginWSCli(request):
    if request.POST:
        user2 = request.POST.get("txtuser")
        password2 = request.POST.get("txtpassword")
        data = {
            'datoscli': listado_cliente(in_var=password2),
            'contratoscli': listado_contratos(in_var=password2)
        }
        if cliente.service.LoginCli(user2, password2):
            return render(request, "Inicio/clientePerfil.html", data)
        else:
            variable = {'msg': 'No existe'}
    return redirect(to='home')


def asesoriasProf(request):
    if request.POST:
        if cliente.service.asesoriasProf():
            return render(request)
        else:
            variable = {'o'}
    return render(request)


def datosprf(request):
    return render(request, 'Inicio/home.html')


def test():
    cliente.service.datosprf()


@login_required(login_url='/')
def cerrar_sesion(request):
    logout(request)
    return redirect(to='home')
