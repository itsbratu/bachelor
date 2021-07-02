"""
File which contains our class for the Repository in app
"""

from Domain.prajitura import Prajitura
from Domain.exceptii import MultiplePrajitura , NotExistent

class Repository:

    def __init__(self , filename):
        self.filename = filename
        self.prajituri = self.loadfromfile()

    def loadfromfile(self):
        """
        Functie care incarca din fisier datele despre prajituri in memorie
        :return: list_prajituri - list of objects "Prajitura"
        :raises: IOError - daca nu se poate deschide fisierul cu succes
        """
        try:
            f = open(self.filename , "r")
        except IOError:
            return []

        list_prajituri = []

        with open(self.filename , "r") as f:
            for linie in f:
                if linie!="\n":
                    atrs = linie.split(";")
                    prajitura = Prajitura(atrs[1] , float(atrs[2]) , int(atrs[3]))
                    list_prajituri.append(prajitura)

        return list_prajituri

    def savetofile(self , list_prajituri):
        """
        Functie care salveaza in fisier datele despre prajituriel din memorie
        :param: list_prajituri - lista care contine obiecte de tip "Prajitura"
        :raises: IOError - daca nu se poate deschide fisierul cu succes
        """
        try:
            f = open(self.filename , "w")
        except IOError:
            return []

        with open(self.filename , "w") as f:
            for prajitura in list_prajituri:
                linie_fisier = str(prajitura.getid()) + ";" + prajitura.getnume() + ";" + str(prajitura.getpret()) + ";" + str(prajitura.getcantitate()) + ";"
                f.write(linie_fisier)
                f.write("\n")

    def addprajitura(self , prajitura : Prajitura):
        """
        Functie care adauga in lista de prajituri un nou obiect "Prajitura"
        :param prajitura - "Prajitura" object
        :raises:MultipliePrajitura - daca exista deja prajitura in lista
        """
        for p in self.prajituri:
            if p.getnume() == prajitura.getnume():
                Prajitura.id_prajitura = Prajitura.id_prajitura -1
                raise MultiplePrajitura("Deja exista prajitura pe care doriti sa o adaugati!")

        self.prajituri.append(prajitura)
        self.savetofile(self.prajituri)

    def deleteprajitura(self , id):
        """
        Functie care sterge din lista de prajituri o prajitura dupa id
        :param id:integer number > 0
        """
        Existance = False
        for p in self.prajituri:
            if p.getid() == id:
                Existance = True
                self.prajituri.remove(p)
                self.savetofile(self.prajituri)
                break
        if Existance == False:
            raise NotExistent("Nu exista prajitura pe care doriti sa o stergeti!")

    def getall(self):
        """
        Functie care returneaza toate "Prajiturile" din lista de prajituri
        :return: self.prajituri - list of objects "Prajitura"
        """
        return self.prajituri