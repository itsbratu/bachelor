from Domain.prajitura import Prajitura
from Repository.Repository import Repository
from Service.Service import Service
from UI.UIcontroller import UI

repo = Repository("test.txt")
service =Service(repo)
ui = UI(repo , service)

while True:
    try:
        result = ui.getchoice()
        if not result:
            break
    except Exception as e:
        print(str(e) + "\n")

print("Multumim ca ati utilizat aplicatia!")