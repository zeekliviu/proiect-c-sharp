import requests as req
import json
from bs4 import BeautifulSoup

final = {}  # dictionarul final, de forma 
            #{oras_in_care_exista_cazare: {tip_cazare_disponibil_in_acel_oras (nu toate orasele au hoteluri sau vile, de exemplu): 
            # [cladiri_de_tip_cazare_din_oras (aici vor fi doar Vila X, Vila Y, Vila Z daca tip_cazare = Vile etc.)]}}

for item in {"pensiuni", "hoteluri", "case", "vile"}:  # pentru fiecare tip de cazare
    cities_with_places = {}  # dictionarul cu orasele in care se afla tipul de cazare curent si link-urile tuturor
    # statiunilor din orasul respectiv
    URL = f"https://www.tourismguide.ro/{item}.html"  # URL-ul pentru tipul de cazare curent
    html_content = req.get(URL).text  # se preia continutul HTML al paginii
    soup = BeautifulSoup(html_content, "html.parser")  # se parseaza continutul HTML
    buildings_table = soup.find("div", attrs={"class": "contentFromEditor"})  # se preia tabelul cu toate locatiile
    # din html-ul parsat
    buildings_rows = buildings_table.find_all("tr")  # se preiau toate randurile din tabel (fiecare rand reprezinta
    # cate o zona cu o lista de statiuni, ex: item = hoteluri, buildings_rows = [Cazare Hoteluri Valea Prahovei: {
    # statiuni Valea Prahovei}, Cazare Hoteluri
    # Litoral: {statiuni Litoral}, Cazare Hoteluri Transilvania: {statiuni Transilvania}...])
    for row in buildings_rows:  # pentru fiecare zona
        cells = row.find_all("td")  # se preiau toate celulele din rand (fiecare celula reprezinta o statiune,
        # ex: item = hoteluri, building_rows = Cazare Hoteluri Valea Prahovei: {statiuni din Valea Prahovei} -> cells
        # = {Hoteluri Sinaia	Hoteluri Busteni	Hoteluri Azuga	Hoteluri Predeal
        # Hoteluri Breaza	Hoteluri Paraul Rece	Hoteluri Campina	Hoteluri Timisu de Jos
        # Hoteluri Timisu de Sus	Hoteluri Moroeni}
        for cell in cells:  # pentru fiecare localitate din zona
            anchor = cell.find("a")  # se gaseste link-ul aferent paginii cu cladirile din statiunea respectiva
            if anchor is not None:  # daca link-ul exista
                href = anchor.get("href")  # se preia href-ul link-ului, ex: /html/orase/Brasov/Hotel_Timisu de Jos.php
                text_href = str(href)  # se transforma href in string pentru a putea inlocui spatiile cu „%20”,
                # ca sa poata fi folosit in URL, ex: /html/orase/Brasov/Hotel_Timisu%20de%20Jos.php
                text_href = text_href.replace(" ", "%20")  # se inlocuiesc spatiile cu „%20” pentru a putea fi
                # folosit in URL
                text_href = "https://www.tourismguide.ro" + text_href  # se adauga prefixul
                # "https://www.tourismguide.ro" pentru a forma link-ul fiecarei statiuni din fiecare localitate
                text = anchor.text.title()  # se formeaza cheia pentru dictionarul cu orasele si cazarile din
                # localitatea respectiva
                text = ' '.join(text.split(" ")[1:])  # daca text era „Hoteluri Timisu de Jos”, se elimina
                # „Hoteluri”, iar cheia va fi „Timisu De Jos” (pentru ca se foloseste metoda title() care face prima
                # litera mare)
                cities_with_places[text] = text_href  # se adauga in dictionarul cu orasele si link-urile tuturor
                # statiunilor din orasul respectiv

    buildings_from_cities = {}  # dictionarul cu toate cladirile din fiecare oras

    for entry in cities_with_places:  # pentru fiecare oras din dictionarul cu orasele si link-urile tuturor statiunilor
        html_content = req.get(cities_with_places[entry]).text  # se preia continutul HTML al paginii
        soup = BeautifulSoup(html_content, "html.parser")  # se parseaza continutul HTML
        buildings_table = soup.find("table", attrs={"id": "thNewPlacesList"})  # se preia tabelul cu toate cladirile
        buildings_rows = buildings_table.find_all("tr")  # se preiau toate randurile din tabel (fiecare rand reprezinta
        # cate o cladire, ex: item = hoteluri, entry = Timisu De Jos, buildings_rows = [Hotel All Times Timisu de Jos]
        buildings = []  # lista cu toate denumirile din orasul respectiv
        for row in buildings_rows:  # pentru fiecare cladire din orasul respectiv
            building_name = row.find("td", attrs={"class": "unitsListItemTeaser"}).find("a").find("span").text # se
            # preia numele cladirii
            buildings.append(building_name)  # se adauga numele cladirii in lista cu toate denumirile din orasul curent
        buildings_from_cities[entry] = buildings  # se adauga in dictionarul cu toate cladirile din fiecare oras

    for key in buildings_from_cities:  # pentru fiecare oras din dictionarul (oras, lista cu toate cladirile din oras),
        # ex: key = Timisu De Jos, buildings_from_cities = {Timisu De Jos: [Hotel All Times Timisu de Jos]},
        # se adauga la dictionarul final care va fi de forma {oras: {tip_cazare: [cladiri_de_tip_cazare_din_oras]}}
        if key in final:
            final[key][item.title()] = buildings_from_cities[key]
        else:
            final[key] = {item.title(): buildings_from_cities[key]}
    print(f"S-au preluat toate {item}le.")

with open("final.json", "w") as file:  # se scrie dictionarul final in fisierul final.json
    json.dump(final, file, indent=4)
