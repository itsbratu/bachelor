"""
Python file which contains the "Prajitura" class for our application
"""

class Prajitura:

    id_prajitura = 0

    def __init__(self , nume , pret , cantitate):
        self.id = Prajitura.id_prajitura + 1
        self.nume = nume
        self.pret = pret
        self.cantitate = cantitate
        Prajitura.id_prajitura = Prajitura.id_prajitura + 1

    def getid(self):
        """
        Functie care returneaza id-ul unei prajituri
        :return: self.id - integer value > 0
        """
        return self.id

    def getnume(self):
        """
        Functie care returneaza numele unei prajituri
        :return: self.nume - string
        """
        return self.nume

    def getpret(self):
        """
        Functie care returneaza pretul unei prajituri
        :return: self.pret - float value > 0
        """
        return self.pret

    def getcantitate(self):
        """
        Functie care returneaza cantitatea unei prajituri
        :return: self.cantitate - integer value > 0
        """
        return self.cantitate