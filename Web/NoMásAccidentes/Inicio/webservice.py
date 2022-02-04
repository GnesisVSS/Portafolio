from zeep import Client
 
import json

cliente = Client('http://localhost:61887/Service1.svc?wsdl')

prueba=cliente.service.datosprf("STEVEN")
print(prueba)