"""
Python file where we store our custom exceptions for the app
"""

class InvalidPrajitura(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class MultiplePrajitura(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class InvalidCommand(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class NotExistent(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class InvalidID(Exception):
    def __init__(self , msg):
        super().__init__(msg)