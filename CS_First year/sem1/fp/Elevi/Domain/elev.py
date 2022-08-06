"""
Python file which contains the "Elev" class which we use in our app
"""

class Elev():

    def __init__(self , nume , prenume , nrcls , numecls):
        self.nume = nume
        self.prenume = prenume
        self.nrcls = nrcls
        self.numecls = numecls

    def getnume(self):
        """
        Functie care returneaza numele unui obiect de tip "Elev"
        :return: self.nume - string
        """
        return self.nume

    def getprenume(self):
        """
        Functie care returneaza prenumele unui obiect de tip "Elev"
        :return: self.prenume - string
        """
        return self.prenume

    def getnrcls(self):
        """
        Functie care returneaza numarul clasei unui obiect de tip "Elev"
        :return: self.nrcls - integer between 1 and 12 including
        """
        return self.nrcls

    def getnumecls(self):
        """
        Functie care returneaza numele clasei unui obiect de tip "Elev"
        :return: self.numecls - letter 'A' , 'B' , 'C' or 'D'
        """
        return self.numecls