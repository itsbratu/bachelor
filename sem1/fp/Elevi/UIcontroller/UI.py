"""
Python file which contains the class for the UI in the app
"""

from Domain.elev import Elev
from Repository.repo import Repository
from Service.service import Service
from Exceptions.exceptii import InvalidChoice

class UI:

    def __init__(self , repo:Repository , service:Service):
        self.repo = repo
        self.service =service

    def printmenu(self):
        """
        Functie care da print pe ecran la meniul utilizatorului
        """
        print("--------MENU--------")
        print("0.Afisare elevi din lista!")
        print("1.Adaugare elev in lista!")
        print("2.Afisare elevi dintr-o clasa!")
        print("3.Afisare elevi alfabetic din scoala!")
        print("4.EXIT")
        print()

    def getchoice(self):
        """
        Functie care permite utilizatorului alegerea unei optiuni din meniu
        :return:
        """
        print()
        self.printmenu()
        print()
        choice = input("Va rugam introduceti o optiune:")
        try:
            choice = int(choice)
        except ValueError:
            raise InvalidChoice("Optiunea introdusa nu este valida!")

        if choice not in range(0,5):
            raise InvalidChoice("Nu exista optiunea introdusa!")

        if choice == 0:
            self.printelevi()
            return True
        if choice == 1:
            self.addelev()
            return True
        if choice == 2:
            self.reportelevi()
            return True
        if choice == 3:
            self.ordonarealfabetica()
            return True
        if choice == 4:
            return False

    def printelevi(self):
        """
        Functie care afiseaza pe ecran elevii din lista de elevi
        """
        list_print = self.service.getall()
        if len(list_print) == 0:
            print()
            print("Nu exista elevi in scoala!")
        else:
            print("Elevii din scoala sunt:")
            print()
            for elev in list_print:
                print(elev.getnume() + " " + elev.getprenume() + " " + str(elev.getnrcls()) + elev.getnumecls())

    def addelev(self):
        """
        Functie care permite utilizatorului introducerea de la tastatura a unui elev si adaugarea acestuia in lista
        """
        nume = input("Nume elev:")
        prenume = input("Prenume elev:")
        nrcls = input("Numarul clasa elev:")
        numecls = input("Nume clasa elev:")
        print()

        elev = Elev(nume , prenume , nrcls , numecls)
        self.service.addelev(elev)

    def reportelevi(self):
        """
        Functie care permite utilizatorului obtinerea unui raport legat de toti elevii dintr-o clasa a scolii
        """
        nrcls = input("Numar clasa:")
        numecls = input("Nume clasa:")
        print()
        list_clasa = self.service.reportcls(nrcls , numecls)

        if len(list_clasa) == 0:
            print("Nu exista elevi in aceasta clasa!")
        else:
            print("Elevii din clasa {}{} sunt:".format(nrcls , numecls))
            print()
            for elev in list_clasa:
                print(elev.getnume() + " " + elev.getprenume() + " " + str(elev.getnrcls()) + elev.getnumecls())

    def ordonarealfabetica(self):
        """
        Functie care furnizeaza utilizatorului lista de elevi din scoala ordonata alfabetic
        """
        print()
        list_elevi = self.service.ordonareelevi()
        if len(list_elevi) ==0:
            print("Nu exista elevi in scoala!")
        else:
            print("Elevii din scoala ordonati alfabetic sunt:")
            print()

            for elev in list_elevi:
                print(elev.getnume() + " " + elev.getprenume() + " " + str(elev.getnrcls()) + elev.getnumecls())