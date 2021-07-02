"""
Python file in which we store our service class for the app
"""

from Domain.elev import Elev
from Domain.validator import Validator
from Repository.repo import Repository

class Service:

    def __init__(self , repo:Repository):
        self.repo = repo

    def addelev(self , elev:Elev):
        """
        Functie care valideaza si in caz afiramtiv adauga un elev in lista
        :raises: InvalidElev - daca elevul introdus de catre utilizator nu este valid
        """
        validator = Validator(elev)
        validator.validare()

        self.repo.addelev(elev)

    def reportcls(self , nrcls , numecls):
        """
        Functie care returneaza lista elevilor dintr-o anumita clasa din scoala
        :param nrcls - integer between 1 and 12
        :param numecls - letter 'A','B','C' or 'D'
        :return: list_elevi - list of 'Elev' objects
        """
        elev_ideal = Elev("Bratu" , "Ionut" , nrcls , numecls)
        validator = Validator(elev_ideal)
        validator.validare()

        list_all = self.repo.getall()
        list_return = []

        for e in list_all:
            if e.getnrcls() == int(nrcls) and e.getnumecls() == numecls:
                list_return.append(e)

        return list_return

    def ordonareelevi(self):
        """
        Functie care retunreaza lista elevilor din scoala ordonata dupa nume+prenume
        :return: list_elevi - list of "Elev" instances
        """
        list_first = self.repo.getall()
        name_ord = sorted(list_first , key=lambda Elev:(Elev.nume,Elev.prenume) , reverse=False)

        return name_ord

    def getall(self):
        """
        Functie care preia intreaga lista de elevi din repo-ul de elevi
        :return: list_elevi - list of "Elev" instances
        """
        list_elevi = self.repo.getall()
        return list_elevi