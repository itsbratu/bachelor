"""
Python file that contains our class for the Service in our app
"""

from Domain.prajitura import Prajitura
from Domain.validator import Validator
from Repository.Repository import Repository

class Service:

    def __init__(self , repo : Repository):
        self.Repository = repo

    def addprajitura(self , prajitura : Prajitura):
        """
        Functie care apeleaza repo-ul pentru a adauga o prajitura in memorie
        :param: prajitra - "Prajitura" object
        :raises: InvalidPrajitura daca datele introduse pentru prajitura sunt invalide
        """
        validator = Validator(prajitura)
        validator.validare()

        self.Repository.addprajitura(prajitura)

    def deleteprajitura(self , id):
        """
        Functie care apeleaza repo-ul pentru a sterge o prajitura in memorie
        :param id - string
        :raises: InvalidPrajitura daca id-ul introdus pentru prajitura nu este valid
        """
        self.Repository.deleteprajitura(id)

    def ordonarepret(self):
        """
        Functie care returneaza lista de prajituri ordonata dupa pret
        :return:list_prajituri - list of "Prajitura" object sorted by price
        """
        list_current = self.Repository.getall()
        list_sorted = sorted(list_current , key=lambda Prajitura:Prajitura.pret , reverse=True)
        return list_sorted

    def getall(self):
        """
        Functie care preia toate prajiturile aflate in memorie din Repository
        :return: list_prajituri - list of "Prajitura" objects
        """
        list_prajituri = self.Repository.getall()
        return list_prajituri