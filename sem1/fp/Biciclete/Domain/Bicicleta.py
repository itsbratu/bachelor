"""
Python file unde ne declaram clasa "Bicicleta" - obiect prinicipal al acestei aplicatii
"""

class Bicicleta:

    def __init__(self , id , tip , pret):
        self.id = id #integer number greater than 0
        self.tip = tip #a basic string
        self.pret = pret #float number greater than 0

    def getid(self):
        """
        Functie care returneaza id-ul unui obiect de tip "Bicicleta"
        :return: self.id - integer number greater tha0 0
        """
        return self.id

    def gettip(self):
        """
        Functie care returneaza tipul unui obiect de tip "Bicicleta"
        :return: self.tip - basic string
        """
        return self.tip

    def getpret(self):
        """
        Functie care returneaza pretul unui obiect de tip "Bicicleta"
        :return: self.pret - float number greater than 0
        """
        return self.pret
