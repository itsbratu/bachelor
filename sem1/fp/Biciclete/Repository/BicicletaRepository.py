"""
Pyhon file care contine clasa BicicletaRepository unde o sa ne stocam datele despre obiectele "Bicicleta" in memorie
"""

from Domain.Bicicleta import Bicicleta
from Exceptions.Exceptii import NotExistent

class BicicletaRepository:

    def __init__(self , filename):
        self.filename = filename
        self.biciclete = self.loadfromfile()

    def loadfromfile(self):
        """
        Functie care preia din fisierul self.filename.txt obiectele de tip "Bicicleta" introduse corect de catre utilizator
        :return: list_biciclete - list of "Bicicleta" instances sau [] daca nu s-a putut deschide cu succes fisierul
        """
        try:
            f = open(self.filename , "r")
        except IOError:
            return []

        list_biciclete = []

        with open(self.filename , "r") as f:
            for linie in f:
                atrs = linie.split(";")
                bicicleta = Bicicleta(int(atrs[0]) , atrs[1] , float(atrs[2]))
                list_biciclete.append(bicicleta)

        return list_biciclete

    def savetofile(self , list_biciclete):
        """
        Functie care scrie peste in fisierul self.filename.txt obiectele de tipul "Bicicleta" din lista aflata in memorie
        :param list_biciclete - list of "Bicicleta" objects or [] daca nu s-a putut deschide cu succes fisierul
        """
        try:
            f = open(self.filename , "w")
        except IOError:
            return []
        with open(self.filename , "w") as f:
            for obj in list_biciclete:
                add_line = str(obj.getid()) + ";" + obj.gettip() + ";" + str(obj.getpret()) + ";"
                f.write(add_line)
                f.write("\n")

    def deletebicicleta(self , tip):
        """
        Functie care sterge un obiect de tip "Bicicleta" din lista dupa campul tip al acesteia
        :raises: NotExistent - daca nu exista nicio bicicleta de tipul indicat
        """
        existent = False
        for b in self.biciclete:
            if b.gettip() == tip:
                existent = True
                break
        if existent == False:
            raise NotExistent("Nu exista nicio bicicleta de acest tip!Puteti sa adaugati accesand fisierul!")
        else:
            obj_delete = []
            for b in self.biciclete:
                if b.gettip() == tip:
                    obj_delete.append(b)

            for obj in obj_delete:
                self.biciclete.remove(obj)
            self.savetofile(self.biciclete)

    def getall(self):
        """
        Functie care returneaza lista de obiecte "Bicicleta" curenta din memorie
        :return: list_bicicleta - list of "Bicicleta" objects
        """
        self.savetofile(self.biciclete)
        return self.biciclete