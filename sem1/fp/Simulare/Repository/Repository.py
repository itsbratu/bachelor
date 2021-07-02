"""
Python file where we store our class "PicturaRepository"
"""

from Domain.Muzeu import Pictura

class PicturaRepository:

    def __init__(self , filename):
        self.filename = filename
        self.picturi = self.loadfromfile()

    def loadfromfile(self):
        """
        Functie care incarca datele din fisierul "self.filename.txt" in lista din memorie
        :return: list_picturi - list of "Pictura" objects or [] is the function can not open the file
        """
        try:
            f = open(self.filename , "r")
        except IOError:
            return []

        list_picturi = []

        with open(self.filename , "r") as f:
            for linie in f:
                if linie!="\n":
                    atrs = linie.split(";")
                    pictura = Pictura(int(atrs[0]) , atrs[1] , atrs[2] , int(atrs[3]))
                    list_picturi.append(pictura)

        return list_picturi

    def getall(self):
        """
        Functie care preia toate obiectele de tip "Pictura" tip memorie si le returneaza ca lista
        :return: list_picturi - list of "Pictura" objects
        """
        return self.picturi