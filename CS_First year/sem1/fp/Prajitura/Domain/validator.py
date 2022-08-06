"""
File that contais our validator class for the "Prajitura" object
"""

from Domain.prajitura import Prajitura
from Domain.exceptii import InvalidPrajitura

class Validator:

    def __init__(self , prajitura:Prajitura):
        self.validator = prajitura

    def validare(self):
        """
        Functie care valideaza un obiect de tipul "Prajitura" din aplicatie si da raise cu mesaj corespunzator in functie de atribute
        :raises: InvalidPrajitura cu mesajul : -"Nume prajitura invalid!" daca numele prajiturii nu este un string nevid care incepe cu o litera din alfabet
                                               -"Pret prajitura invalid!" daca pretul prajiturii nu este un float pozitiv
                                               -"Cantitate prajitura invalida!" daca cantitatea prajiturii nu este un integer pozitiv mai mare ca 0
        """
        nume = self.validator.getnume()
        pret = self.validator.getpret()
        cantitate = self.validator.getcantitate()
        Errors = ""

        if len(nume) <0 or nume[0].isalpha() == False:
            Errors = Errors + "Nume prajitura invalid!" + "\n"

        try:
            pret = float(pret)
            if pret < 0:
                Errors = Errors + "Pret prajitura invalid!" + "\n"
        except ValueError:
            Errors = Errors + "Pret prajitura invalid!" + "\n"

        try:
            cantitate = int(cantitate)
            if cantitate < 0:
                Errors = Errors + "Cantitate prajitura invalida!" + "\n"
        except ValueError:
            Errors = Errors + "Cantitate prajitura invalida!" + "\n"

        if len(Errors) > 0:
            Prajitura.id_prajitura = Prajitura.id_prajitura - 1
            raise InvalidPrajitura(Errors)
