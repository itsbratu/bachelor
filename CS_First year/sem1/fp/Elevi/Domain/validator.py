"""
Python file which stores the validator object for our "Elev" instance
"""

from Domain.elev import Elev
from Exceptions.exceptii import InvalidElev

class Validator:

    def __init__(self , elev:Elev):
        self.elev = elev

    def validare(self):
        """
        Functie care valideaza un obiect de tipul "Elev"
        :raises: InvalidElev with the message : -"Nume elev invalid!" if the name is null or it does not start with an alphabetic letter
                                                -"Prenume elev invalid!" if the prenume is null or it does not start with an alphabetic letter
                                                -"Nr. clasa elev invalid!" if the class number is not an integer between 1 and 12
                                                -"Nume clasa elev invalida!" if the name of the class if not the letter 'A' , 'B' , 'C' or 'D'
        """
        nume = self.elev.getnume()
        prenume = self.elev.getprenume()
        nrcls = self.elev.getnrcls()
        numecls = self.elev.getnumecls()
        Errors = ""

        if len(nume) == 0:
            Errors = Errors + "Nume elev invalid!" + "\n"
        else:
            for c in nume:
                if c.isalpha() == False:
                    Errors = Errors + "Nume elev invalid!" + "\n"
                    break

        if len(prenume) == 0:
            Errors = Errors + "Prenume elev invalid!" + "\n"
        else:
            for c in prenume:
                if c.isalpha() == False:
                    Errors = Errors + "Prenume elev invalid!" + "\n"
                    break

        try:
            nrcls = int(nrcls)
            if nrcls not in range(1,13):
                Errors = Errors + "Nr. clasa elev invalid!" + "\n"
        except ValueError:
            Errors = Errors + "Nr. clasa elev invalid!" + "\n"

        if numecls not in "ABCD":
            Errors = Errors + "Nume clasa elev invalida!" + "\n"

        if len(Errors) > 0:
            raise InvalidElev(Errors)