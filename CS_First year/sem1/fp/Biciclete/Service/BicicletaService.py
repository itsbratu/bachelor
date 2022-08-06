"""
Python file where we store our "BicicletaService" class for the app
"""

from Repository.BicicletaRepository import BicicletaRepository
from Exceptions.Exceptii import EmptyList

class BicicletaService:

    def __init__(self , repo : BicicletaRepository):
        self.repo = repo

    def deletebicicleta(self , tip):
        """
        Functie care sterge toate obiectele de tip "Bicicleta" din memorie , apeland functia deletebicicleta din BicicletaRepository
        :param tip - string
        """
        self.repo.deletebicicleta(tip)

    def deletemaxim(self):
        """
        Functie care sterge toate obiectele de tip "Bicicleta" din memorie care au pretul maxim
        :raises: EmptyList - daca nu exista niciun obiect de tip "Bicicleta" in memorie
        """
        list_biciclete = self.repo.getall()
        if len(list_biciclete) == 0:
            raise EmptyList("Nu exista biciclete in lista!Puteti sa adaugati accesand fisierul!")
        else:
            max_price = -1
            for b in list_biciclete:
                if b.getpret() > max_price:
                    max_price = b.getpret()

            list_delete = []
            for b in list_biciclete:
                if b.getpret() == max_price:
                    list_delete.append(b)

            for obj in list_delete:
                list_biciclete.remove(obj)

    def getall(self):
        """
        Functie care returneaza lista de obiecte "Bicicleta" din memorie , apeland functia getall din BicicletaRepository
        :return: list_biciclete - list of "Bicicleta" instances
        """
        return self.repo.getall()
