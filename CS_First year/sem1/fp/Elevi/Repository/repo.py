"""
Python file that contains the class for our ElevRepository in which we store our "Elev" instances
"""

from Domain.elev import Elev
from Exceptions.exceptii import ExistentElev

class Repository:

    def __init__(self , filename):
        self.filename = filename
        self.elevi = self.loadfromfile()

    def loadfromfile(self):
        """
        Functie care incarca din fisierul text "filename" obiectele "Elev" in memorie,in lista self.elevi
        :return: list_elevi - list of "Elev" instances
        """
        try:
            f = open(self.filename , "r")
        except IOError:
            return []

        list_elevi = []

        with open(self.filename , "r") as f:
            for linie in f:
                if linie != "\n":
                    atrs = linie.split(";")
                    elev = Elev(atrs[0] , atrs[1] , int(atrs[2]) , atrs[3])
                    list_elevi.append(elev)

        return list_elevi

    def storetofile(self , list_elevi):
        """
        Functie care incarca in fisierul text "filename" obiecte "Elev: din memorie
        """
        try:
            f = open(self.filename , "w")
        except IOError:
            return []

        with open(self.filename, "w") as f:
            for elev in list_elevi:
                string_line = elev.getnume() + ";" + elev.getprenume() + ";" + str(elev.getnrcls()) + ";" + elev.getnumecls() + ";"
                f.write(string_line)
                f.write("\n")

    def addelev(self , elev:Elev):
        """
        Functie care adauga un elev in lista de elevi "Elev" instance
        :param elev - "Elev" object
        :raises: ExistentElev - daca deja exista elevul pe care dorim sa il adaugam in lista
        """
        for e in self.elevi:
            if e.getnume() == elev.getnume() and e.getprenume() == elev.getprenume() and e.getnrcls() == elev.getnrcls() and e.getnumecls() == elev.getnumecls():
                raise ExistentElev("Elevul pe care doriti sa il adaugati deja exista in lista!")
        self.elevi.append(elev)
        self.storetofile(self.elevi)

    def getall(self):
        """
        Functie care returneaza intreaga lista de elevi, "Elev instance"
        :return: list_elevi - list of "Elev" instances
        """
        return self.elevi