"""
Python file where we store our "Console" class for our application
"""

from Repository.BicicletaRepository import BicicletaRepository
from Service.BicicletaService import BicicletaService
from Exceptions.Exceptii import InvalidOption

class Console:

    def __init__(self , repo : BicicletaRepository , service : BicicletaService):
        self.repo = repo
        self.service = service

    def printmenu(self):
        """
        Functie care printeaza pe ecranul utilizatorului optiunile posibile in cadrul aplicatiei
        """
        print("----------MENU----------")
        print()
        print("1.Stergere biciclete de un anumit tip din lista!")
        print("2.Stergere biciclete cu pretul maxim din lista!")
        print("3.Afisare biciclete din lista curenta!")
        print()
        print("x.Iesire aplicatie")

    def getchoice(self):
        """
        Functie care permite utilizatorului alegerea unei optiuni din lista
        :return: True - daca se continua rularea aplicatiei , False - daca utilizatorul a decis sa iasa din aplicatie, din run-ul curent
        :raises: InvalidOption - daca optiunea data de catre utilizator nu este valida!
        """
        self.printmenu()
        print()
        choice = input("Va rugam alegeti o optiune din meniul de mai sus:")
        print()

        if choice == 'x':
            return False
        try:
            choice = int(choice)
            if choice not in range(1,4):
                raise InvalidOption("Optiunea pe care ati introdus-o nu exista prin lista de optiuni!")
        except ValueError:
            raise InvalidOption("Optiunea pe care ati introdus-o nu este valida!")

        if choice == 1:
            self.deletebicicleta()
            return True
        if choice == 2:
            self.deletemax()
            return True
        if choice == 3:
            self.printbiciclete()
            return True

    def deletebicicleta(self):
        """
        Functie care permite utilizatorului introducere unui tip de bicicleta care va fi sters
        """
        tip = input("Introduceti tipul bicicletei pe care doriti sa il stergeti:")
        print()
        self.service.deletebicicleta(tip)

    def deletemax(self):
        """
        Functie care permite utilizatorului stergerea a tuturor bicicletelor cu pretul maxim actual din lista
        """
        self.service.deletemaxim()
        print()

    def printbiciclete(self):
        """
        Functie care permite utilizatorului afisarea pe ecran a tuturor obiectelor de tip "Bicicleta" din lista
        """
        list_bicicleta = self.service.getall()
        if len(list_bicicleta) == 0:
            print("Nu exista nicio bicicleta in lista!")
            print()
        else:
            print("Lista de biciclete este:")
            print()
            for b in list_bicicleta:
                print(str(b.getid()) + " " + b.gettip() + " " + str(b.getpret()))