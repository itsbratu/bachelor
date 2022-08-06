"""
Python file where we store our class "PicturaService"
"""

from Domain.Muzeu import Pictura
from Repository.Repository import PicturaRepository
from Exceptions.Exceptii import InvalidCamera , InvalidSubstring
class PicturaService:

    def __init__(self , repo:PicturaRepository):
        self.repo = repo

    def containsstring(self , s1 , s2):
        """
        Functie care verifica daca substring se afla ca subsecventa in string
        :param s1 - string
        :param s2 - string
        :return: True - daca se afla ca subsecventa , False in caz contrar
        """
        if s1.find(s2) == -1:
            return False
        else:
            return True

    def picturistring(self , substring):
        """
        Functie care returneaza lista de picturi care contin un substring , ordonate dupa autor
        :param substring - string
        :return:list_picturi
        """
        for s in substring:
            if s.isalpha() == False:
                raise InvalidSubstring("String introdus de utilizator invalid!")

        list_picturi = self.repo.getall()
        list_string = []

        for p in list_picturi:
            rez = self.containsstring(p.getdenumire() , substring)
            if rez == True:
                list_string.append(p)

        list_sorted = sorted(list_string , key = lambda Pictura:Pictura.autor , reverse=True)
        return list_sorted

    def autoricamera(self , camera):
        """
        Functie care returneaza o lista de autori care au picturi expuse intr-o anumita camera introdusa de catre utilizator
        :param camera - integer > 0
        :return: list_autori - o lista de string-uri care reprezinta numele autorilor
        :raises: InvalidCamera - daca nu exista autori care au picturi in acea camera sau daca camera este invalida
        """
        list_picturi = self.repo.getall()
        try:
            camera = int(camera)
            exists = False
            for p in list_picturi:
                if p.getnr() == camera:
                    exists = True

            if exists == False:
                raise InvalidCamera("Nu exista autori care sa aiba opere expuse in aceasta camera!")

        except ValueError:
            raise InvalidCamera("Numele introdus pentru camera invalid!")

        list_autori = []

        for p in list_picturi:
            if p.getnr() == camera and p.getautor() not in list_autori:
                list_autori.append(p.getautor())

        return list_autori

    def getall(self):
        """
        Functie care returneaza toate obiectele de tip "Pictura" din memorie
        :return:list_picturi
        """
        return self.repo.getall()